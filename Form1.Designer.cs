namespace KerSSH
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pattern = new System.Windows.Forms.TextBox();
            this.rootaccess = new System.Windows.Forms.CheckBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(212, 13);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(394, 349);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(192, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Récuper la liste";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(212, 368);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(183, 44);
            this.button2.TabIndex = 3;
            this.button2.Text = "Lancer le script";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // pattern
            // 
            this.pattern.Location = new System.Drawing.Point(13, 13);
            this.pattern.Name = "pattern";
            this.pattern.Size = new System.Drawing.Size(191, 20);
            this.pattern.TabIndex = 4;
            this.pattern.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pattern_KeyDown);
            // 
            // rootaccess
            // 
            this.rootaccess.AutoSize = true;
            this.rootaccess.Location = new System.Drawing.Point(401, 385);
            this.rootaccess.Name = "rootaccess";
            this.rootaccess.Size = new System.Drawing.Size(86, 17);
            this.rootaccess.TabIndex = 5;
            this.rootaccess.Text = "Root access";
            this.rootaccess.UseVisualStyleBackColor = true;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(12, 69);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(194, 349);
            this.checkedListBox1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 425);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.rootaccess);
            this.Controls.Add(this.pattern);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "KerSSH";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox pattern;
        private System.Windows.Forms.CheckBox rootaccess;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}

