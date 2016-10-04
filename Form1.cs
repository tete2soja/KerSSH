using System;
using System.Windows.Forms;
using System.Management.Automation;
using System.DirectoryServices.ActiveDirectory;
using Renci.SshNet;
using System.Net.NetworkInformation;
using System.IO;
using System.Collections.ObjectModel;

namespace KerSSH
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.listPC.CheckBoxes = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pattern.Text.Equals(""))
            {
                MessageBox.Show("Vous devez renseigner un filtre", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            listPC.Clear();

            string domain = Domain.GetComputerDomain().Name;
            string dns = "CICNTP12";
            // Utilisation de la commande Get-DnsServerResourceRecord pour
            // recupérer l'ensemble des champs dans le DNS
            PowerShell powerShell = PowerShell.Create();
            string script = "(Get-DnsServerResourceRecord -ZoneName " + domain + " -RRType A -ComputerName " + dns + " | Where-Object {$_.HostName -like \"*" + pattern.Text + "*\"}).HostName";
            powerShell.AddScript(script);
            Collection<PSObject> results = powerShell.Invoke();

            foreach (var entry in results)
            {
                // Ajout de l'item dans la liste
                ListViewItem newItem = listPC.Items.Add(entry.ToString());

                // Test de connexion sur le poste
                Ping myPing = new Ping();
                try
                {
                    PingReply reply = myPing.Send(entry.ToString(), 100);
                    if (reply.Status == IPStatus.Success)
                    {
                        // Le poste répond correctement
                        newItem.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        // Le poste n'est pas connecté
                        newItem.ForeColor = System.Drawing.Color.Red;
                    }
                }
                catch (PingException)
                {
                    newItem.ForeColor = System.Drawing.Color.Gray;
                }
            }

            if (powerShell.Streams.Error.Count > 0)
            {
                Console.WriteLine("{0} errors", powerShell.Streams.Error.Count);
            }

            Cursor.Current = Cursors.Default;
        }

        private void pattern_KeyDown(object sender, KeyEventArgs e)
        {
            // Permet d'utiliser la touche "ENTREE"
            if (e.KeyValue == 13)
            {
                this.getList.PerformClick();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Gestion de la progression
            int count = 0;
            int progression;

            if (listPC.CheckedItems.Count == 0)
            {
                MessageBox.Show("Vous devez sélectionner au moins un PC dans la liste", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            if ((username.Text == "") || (password.Text == ""))
            {
                MessageBox.Show("Vous devez renseigner les champs utilisateur et mot de passe", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            if (commands.Text == "")
            {
                MessageBox.Show("Vous devez renseigner la ou les lignes de commandes", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            Form2 form2 = new Form2();
            form2.Show();
            string user = username.Text;
            string pass = password.Text;
            // Pour chaque item choisi dans la liste
            foreach (ListViewItem item in listPC.CheckedItems)
            {
                try
                {
                    // Création de la connexion SSH
                    SshClient ssh = new SshClient(item.Text, user, pass);
                    ssh.Connect();
                    // Création des flux du terminal
                    ShellStream steam = ssh.CreateShellStream("term", 80, 24, 800, 600, 1024);
                    StreamReader reader = new StreamReader(steam);
                    StreamWriter writer = new StreamWriter(steam);
                    writer.AutoFlush = true;

                    // Permet de passer le motd
                    while (steam.Length == 0)
                    {
                        System.Threading.Thread.Sleep(500);
                    }
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        line = reader.ReadLine();
                    }

                    // Active le root si la case est cochée
                    if (rootaccess.Checked)
                    {
                        writer.WriteLine("su -");
                        while (steam.Length == 0)
                        {
                            System.Threading.Thread.Sleep(500);
                        }

                        line = reader.ReadLine();
                        while (line != null)
                        {
                            line = reader.ReadLine();
                        }

                        writer.WriteLine(rootpassword.Text);
                        while (steam.Length == 0)
                        {
                            System.Threading.Thread.Sleep(500);
                        }

                        line = reader.ReadLine();
                        while (line != null)
                        {
                            line = reader.ReadLine();
                        }
                    }

                    // Envoie de la commande
                    writer.WriteLine(commands.Text);
                    while (steam.Length == 0)
                    {
                        System.Threading.Thread.Sleep(500);
                    }

                    // Affiche le résultat de la commande
                    line = reader.ReadLine();
                    while (line != null)
                    {
                        form2.setText(line);
                        System.Threading.Thread.Sleep(250);
                        line = reader.ReadLine();
                    }

                    // Ferme la connexion SSH
                    ssh.Disconnect();
                }
                catch (Renci.SshNet.Common.SshAuthenticationException)
                {
                    // Identifiants invalides
                    MessageBox.Show("Les identifiants fournis sont invalides", "Erreur de connexion",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
                catch (System.Net.Sockets.SocketException)
                {
                    // Connexion impossible
                    MessageBox.Show("L'ordinateur " + item.Text + " présente un problème réseau", "Erreur de connexion",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
                catch (InvalidOperationException)
                {
                    // Connexion déjà établie
                    MessageBox.Show("La connexion est déjà établie", "Erreur de connexion",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
                finally
                {
                    // Mise à jour de la barre de progression
                    count++;
                    // Cast en decimal sinon pas de virgule lors de la division
                    progression = (int)(((decimal)count / (decimal)listPC.CheckedItems.Count) * 100);
                    form2.setProgress(progression);
                }

            }
            Cursor.Current = Cursors.Default;
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            this.count.Text = listPC.CheckedItems.Count + "/" + listPC.Items.Count;
        }

        private void rootaccess_CheckedChanged(object sender, EventArgs e)
        {
            if (rootaccess.Checked == true)
            {
                this.rootpassword.Enabled = true;
            }
            else
            {
                this.rootpassword.Enabled = false;
            }
        }
    }
}
