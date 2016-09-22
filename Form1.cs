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
            string domain = Domain.GetComputerDomain().Name;
            string dns = "CICNTP12";
            PowerShell powerShell = PowerShell.Create();
            string script = "(Get-DnsServerResourceRecord -ZoneName " + domain + " -RRType A -ComputerName " + dns + " | Where-Object {$_.HostName -like \"disbian*\"}).HostName";
            powerShell.AddScript(script);
            var results = powerShell.Invoke();

            foreach (var item in results)
            {
                listView1.Items.Add(item.ToString());
            }

            if (powerShell.Streams.Error.Count > 0)
            {
                Console.WriteLine("{0} errors", powerShell.Streams.Error.Count);
            }

            string server = "";
            string username = "";
            string password = "";

            SshClient ssh = new SshClient(server, username, password);
            ssh.Connect();
            Console.WriteLine(ssh.RunCommand(textBox1.Text).Result);
            ssh.Disconnect();
        }
    }
}
