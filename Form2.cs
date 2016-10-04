using System.Windows.Forms;

namespace KerSSH
{
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ajout du texte dans la textbox de log
        /// </summary>
        /// <param name="text">Texte à ajouter</param>
        public void setText(string text)
        {
            log.AppendText(text + "\r\n");
            log.Refresh();
        }

        /// <summary>
        /// Permet de définir la valeur de la barre de progression
        /// </summary>
        /// <param name="value">Valeur à donner</param>
        public void setProgress(int value)
        {
            this.progressBar1.Value = value;
        }
    }
}
