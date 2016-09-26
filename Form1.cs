using System;
using System.Windows.Forms;
using System.Management.Automation;
using System.DirectoryServices.ActiveDirectory;
using Renci.SshNet;
using System.Net.NetworkInformation;
using System.IO;

namespace KerSSH
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listView1.CheckBoxes = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            listView1.Clear();

            string domain = Domain.GetComputerDomain().Name;
            string dns = "CICNTP12";
            PowerShell powerShell = PowerShell.Create();
            string script = "(Get-DnsServerResourceRecord -ZoneName " + domain + " -RRType A -ComputerName " + dns + " | Where-Object {$_.HostName -like \"*" + pattern.Text + "*\"}).HostName";
            powerShell.AddScript(script);
            var results = powerShell.Invoke();

            foreach (var item in results)
            {
                Ping myPing = new Ping();
                PingReply reply = myPing.Send(item.ToString(), 100);
                var tmp = listView1.Items.Add(item.ToString());
                if (reply.Status == IPStatus.Success)
                {
                    tmp.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    tmp.ForeColor = System.Drawing.Color.Red;
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
                button1.PerformClick();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = 0;
            Cursor.Current = Cursors.WaitCursor;

            if ((username.Text == "") || (password.Text == ""))
            {
                MessageBox.Show("Vous devez renseigner les champs utilisateur et mot de passe", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
            else
            {
                Form2 form2 = new Form2();
                form2.Show();
                TextBox log = form2.getTextBox();
                string user = username.Text;
                string pass = password.Text;
                // Pour chaque item choisi dans la liste
                foreach (ListViewItem item in listView1.CheckedItems)
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

                        while (steam.Length == 0)
                        {
                            System.Threading.Thread.Sleep(500);
                        }
                        var line = reader.ReadLine();
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

                        writer.WriteLine(textBox1.Text);
                        while (steam.Length == 0)
                        {
                            System.Threading.Thread.Sleep(500);
                        }

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
                        i++;
                        // Mise à jour de la barre de progression
                        int progression;
                        progression = (int)(((decimal)i / (decimal)listView1.CheckedItems.Count) * 100);
                        form2.setProgress(progression);
                    }

                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            this.count.Text = listView1.CheckedItems.Count + "/" + listView1.Items.Count;
        }
    }
}
