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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.commands = new System.Windows.Forms.TextBox();
            this.getList = new System.Windows.Forms.Button();
            this.startScript = new System.Windows.Forms.Button();
            this.pattern = new System.Windows.Forms.TextBox();
            this.rootaccess = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.rootpassword = new System.Windows.Forms.TextBox();
            this.listPC = new System.Windows.Forms.ListView();
            this.count = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // commands
            // 
            this.commands.Location = new System.Drawing.Point(212, 39);
            this.commands.Multiline = true;
            this.commands.Name = "commands";
            this.commands.Size = new System.Drawing.Size(417, 323);
            this.commands.TabIndex = 5;
            // 
            // getList
            // 
            this.getList.Location = new System.Drawing.Point(12, 39);
            this.getList.Name = "getList";
            this.getList.Size = new System.Drawing.Size(192, 23);
            this.getList.TabIndex = 2;
            this.getList.Text = "Récuper la liste";
            this.getList.UseVisualStyleBackColor = true;
            this.getList.Click += new System.EventHandler(this.button1_Click);
            // 
            // startScript
            // 
            this.startScript.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startScript.Location = new System.Drawing.Point(212, 368);
            this.startScript.Name = "startScript";
            this.startScript.Size = new System.Drawing.Size(183, 44);
            this.startScript.TabIndex = 8;
            this.startScript.Text = "Lancer le script";
            this.startScript.UseVisualStyleBackColor = true;
            this.startScript.Click += new System.EventHandler(this.button2_Click);
            // 
            // pattern
            // 
            this.pattern.Location = new System.Drawing.Point(13, 13);
            this.pattern.Name = "pattern";
            this.pattern.Size = new System.Drawing.Size(191, 20);
            this.pattern.TabIndex = 1;
            this.pattern.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pattern_KeyDown);
            // 
            // rootaccess
            // 
            this.rootaccess.AutoSize = true;
            this.rootaccess.Location = new System.Drawing.Point(401, 385);
            this.rootaccess.Name = "rootaccess";
            this.rootaccess.Size = new System.Drawing.Size(86, 17);
            this.rootaccess.TabIndex = 6;
            this.rootaccess.Text = "Root access";
            this.rootaccess.UseVisualStyleBackColor = true;
            this.rootaccess.CheckedChanged += new System.EventHandler(this.rootaccess_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(219, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Utilisateur";
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(278, 13);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(100, 20);
            this.username.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(398, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Mot de passe";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(475, 13);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(100, 20);
            this.password.TabIndex = 4;
            this.password.UseSystemPasswordChar = true;
            // 
            // rootpassword
            // 
            this.rootpassword.Enabled = false;
            this.rootpassword.Location = new System.Drawing.Point(493, 383);
            this.rootpassword.Name = "rootpassword";
            this.rootpassword.Size = new System.Drawing.Size(136, 20);
            this.rootpassword.TabIndex = 7;
            this.rootpassword.UseSystemPasswordChar = true;
            // 
            // listPC
            // 
            this.listPC.Location = new System.Drawing.Point(13, 68);
            this.listPC.Name = "listPC";
            this.listPC.Size = new System.Drawing.Size(191, 344);
            this.listPC.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listPC.TabIndex = 12;
            this.listPC.UseCompatibleStateImageBehavior = false;
            this.listPC.View = System.Windows.Forms.View.List;
            this.listPC.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listView1_ItemChecked);
            // 
            // count
            // 
            this.count.AutoSize = true;
            this.count.Location = new System.Drawing.Point(594, 16);
            this.count.Name = "count";
            this.count.Size = new System.Drawing.Size(0, 13);
            this.count.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 425);
            this.Controls.Add(this.count);
            this.Controls.Add(this.listPC);
            this.Controls.Add(this.rootpassword);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.username);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rootaccess);
            this.Controls.Add(this.pattern);
            this.Controls.Add(this.startScript);
            this.Controls.Add(this.getList);
            this.Controls.Add(this.commands);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KerSSH";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox commands;
        private System.Windows.Forms.Button getList;
        private System.Windows.Forms.Button startScript;
        private System.Windows.Forms.TextBox pattern;
        private System.Windows.Forms.CheckBox rootaccess;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox rootpassword;
        private System.Windows.Forms.ListView listPC;
        private System.Windows.Forms.Label count;
    }
}

