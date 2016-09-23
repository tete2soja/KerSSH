using System.Windows.Forms;

namespace KerSSH
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public TextBox getTextBox()
        {
            return this.log;
        }

        public void setText(string text)
        {
            log.AppendText(text + "\r\n");
            log.Refresh();
        }
    }
}
