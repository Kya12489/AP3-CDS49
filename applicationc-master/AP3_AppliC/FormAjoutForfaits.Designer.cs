namespace AP3_AppliC
{
    partial class FormAjoutForfaits
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tbLibelleForfait = new TextBox();
            tbDescrForfait = new TextBox();
            tbContenueForfait = new TextBox();
            tbPrixForfait = new TextBox();
            tbNbheures = new TextBox();
            tbPrixhoraireForfait = new TextBox();
            label1 = new Label();
            btnAjouterForfait = new Button();
            btnFermerAjoutForfait = new Button();
            gbInfosForfait = new GroupBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            gbInfosForfait.SuspendLayout();
            SuspendLayout();
            // 
            // tbLibelleForfait
            // 
            tbLibelleForfait.Location = new Point(171, 24);
            tbLibelleForfait.Name = "tbLibelleForfait";
            tbLibelleForfait.Size = new Size(362, 26);
            tbLibelleForfait.TabIndex = 1;
            // 
            // tbDescrForfait
            // 
            tbDescrForfait.Location = new Point(171, 56);
            tbDescrForfait.Name = "tbDescrForfait";
            tbDescrForfait.Size = new Size(362, 26);
            tbDescrForfait.TabIndex = 2;
            // 
            // tbContenueForfait
            // 
            tbContenueForfait.Location = new Point(171, 88);
            tbContenueForfait.Name = "tbContenueForfait";
            tbContenueForfait.Size = new Size(362, 26);
            tbContenueForfait.TabIndex = 3;
            // 
            // tbPrixForfait
            // 
            tbPrixForfait.Location = new Point(171, 120);
            tbPrixForfait.Name = "tbPrixForfait";
            tbPrixForfait.Size = new Size(362, 26);
            tbPrixForfait.TabIndex = 4;
            // 
            // tbNbheures
            // 
            tbNbheures.Location = new Point(171, 152);
            tbNbheures.Name = "tbNbheures";
            tbNbheures.Size = new Size(362, 26);
            tbNbheures.TabIndex = 5;
            // 
            // tbPrixhoraireForfait
            // 
            tbPrixhoraireForfait.Location = new Point(171, 184);
            tbPrixhoraireForfait.Name = "tbPrixhoraireForfait";
            tbPrixhoraireForfait.Size = new Size(362, 26);
            tbPrixhoraireForfait.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(72, 28);
            label1.Name = "label1";
            label1.Size = new Size(152, 25);
            label1.TabIndex = 7;
            label1.Text = "Ajout de Forfait";
            // 
            // btnAjouterForfait
            // 
            btnAjouterForfait.BackColor = Color.Black;
            btnAjouterForfait.FlatStyle = FlatStyle.Popup;
            btnAjouterForfait.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAjouterForfait.ForeColor = SystemColors.ControlLightLight;
            btnAjouterForfait.Location = new Point(72, 284);
            btnAjouterForfait.Margin = new Padding(3, 2, 3, 2);
            btnAjouterForfait.Name = "btnAjouterForfait";
            btnAjouterForfait.Size = new Size(122, 43);
            btnAjouterForfait.TabIndex = 8;
            btnAjouterForfait.Text = "AJOUTER";
            btnAjouterForfait.UseVisualStyleBackColor = false;
            btnAjouterForfait.Click += btnAjouterForfait_Click;
            // 
            // btnFermerAjoutForfait
            // 
            btnFermerAjoutForfait.BackColor = Color.Black;
            btnFermerAjoutForfait.FlatStyle = FlatStyle.Popup;
            btnFermerAjoutForfait.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFermerAjoutForfait.ForeColor = Color.White;
            btnFermerAjoutForfait.Location = new Point(639, 284);
            btnFermerAjoutForfait.Margin = new Padding(3, 2, 3, 2);
            btnFermerAjoutForfait.Name = "btnFermerAjoutForfait";
            btnFermerAjoutForfait.Size = new Size(118, 43);
            btnFermerAjoutForfait.TabIndex = 9;
            btnFermerAjoutForfait.Text = "FERMER";
            btnFermerAjoutForfait.UseVisualStyleBackColor = false;
            btnFermerAjoutForfait.Click += btnFermerAjoutForfait_Click;
            // 
            // gbInfosForfait
            // 
            gbInfosForfait.Controls.Add(label7);
            gbInfosForfait.Controls.Add(label6);
            gbInfosForfait.Controls.Add(label5);
            gbInfosForfait.Controls.Add(label4);
            gbInfosForfait.Controls.Add(label3);
            gbInfosForfait.Controls.Add(label2);
            gbInfosForfait.Controls.Add(tbLibelleForfait);
            gbInfosForfait.Controls.Add(tbNbheures);
            gbInfosForfait.Controls.Add(tbDescrForfait);
            gbInfosForfait.Controls.Add(tbContenueForfait);
            gbInfosForfait.Controls.Add(tbPrixhoraireForfait);
            gbInfosForfait.Controls.Add(tbPrixForfait);
            gbInfosForfait.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbInfosForfait.Location = new Point(72, 55);
            gbInfosForfait.Margin = new Padding(3, 2, 3, 2);
            gbInfosForfait.Name = "gbInfosForfait";
            gbInfosForfait.Padding = new Padding(3, 2, 3, 2);
            gbInfosForfait.Size = new Size(685, 217);
            gbInfosForfait.TabIndex = 10;
            gbInfosForfait.TabStop = false;
            gbInfosForfait.Text = "Informations sur un forfait";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(13, 187);
            label7.Name = "label7";
            label7.Size = new Size(89, 19);
            label7.TabIndex = 12;
            label7.Text = "Prix horaire";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 155);
            label6.Name = "label6";
            label6.Size = new Size(126, 19);
            label6.TabIndex = 11;
            label6.Text = "Nombre d'heures";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 123);
            label5.Name = "label5";
            label5.Size = new Size(82, 19);
            label5.TabIndex = 10;
            label5.Text = "Prix forfait";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 91);
            label4.Name = "label4";
            label4.Size = new Size(72, 19);
            label4.TabIndex = 9;
            label4.Text = "Contenue";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 59);
            label3.Name = "label3";
            label3.Size = new Size(85, 19);
            label3.TabIndex = 8;
            label3.Text = "Description";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 27);
            label2.Name = "label2";
            label2.Size = new Size(53, 19);
            label2.TabIndex = 7;
            label2.Text = "Libelle";
            // 
            // FormAjoutForfaits
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 128, 0);
            ClientSize = new Size(845, 338);
            Controls.Add(gbInfosForfait);
            Controls.Add(btnFermerAjoutForfait);
            Controls.Add(btnAjouterForfait);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormAjoutForfaits";
            Text = "FormAjoutForfaits";
            gbInfosForfait.ResumeLayout(false);
            gbInfosForfait.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox tbLibelleForfait;
        private TextBox tbDescrForfait;
        private TextBox tbContenueForfait;
        private TextBox tbPrixForfait;
        private TextBox tbNbheures;
        private TextBox tbPrixhoraireForfait;
        private Label label1;
        private Button btnAjouterForfait;
        private Button btnFermerAjoutForfait;
        private GroupBox gbInfosForfait;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
    }
}