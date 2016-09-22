using System;
using System.Linq;
using System.Windows.Forms;
using System.Management.Automation;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;
using System.Net;
using Renci.SshNet;

namespace KerSSH
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            checkedListBox1.Items.Clear();

            string domain = Domain.GetComputerDomain().Name;
            string dns = "CICNTP12";
            PowerShell powerShell = PowerShell.Create();
            string script = "(Get-DnsServerResourceRecord -ZoneName " + domain + " -RRType A -ComputerName " + dns + " | Where-Object {$_.HostName -like \"*" + pattern.Text + "*\"}).HostName";
            powerShell.AddScript(script);
            var results = powerShell.Invoke();

            foreach (var item in results)
            {
                checkedListBox1.Items.Add(item.ToString());
            }

            if (powerShell.Streams.Error.Count > 0)
            {
                Console.WriteLine("{0} errors", powerShell.Streams.Error.Count);
            }

            Cursor.Current = Cursors.Default;
        }

        private void pattern_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                Console.WriteLine("ENTRE");
                button1.PerformClick();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var item in checkedListBox1.CheckedItems)
            {

                string user = username.Text;
                string pass = password.Text;

                SshClient ssh = new SshClient(item.ToString(), user, pass);
                ssh.Connect();
                var steam = ssh.CreateShellStream("term", 80, 24, 800, 600, 1024);
                var reader = new System.IO.StreamReader(steam);
                var writer = new System.IO.StreamWriter(steam);
                writer.AutoFlush = true;
                while (steam.Length == 0)
                {
                    System.Threading.Thread.Sleep(500);
                }
                var line = reader.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = reader.ReadLine();
                }

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
                        Console.WriteLine(line);
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
                    Console.WriteLine(line);
                    line = reader.ReadLine();
                }

                ssh.Disconnect();
            }
        }
    }
}
