namespace AP3_AppliC.view
{
    partial class FormInscriptionEleve
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            tbNom = new TextBox();
            tbPrenom = new TextBox();
            tbEmail = new TextBox();
            tbMdp = new TextBox();
            dtpNaissance = new DateTimePicker();
            tbNumTel = new TextBox();
            btAjouter = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(118, 56);
            label1.Name = "label1";
            label1.Size = new Size(42, 20);
            label1.TabIndex = 0;
            label1.Text = "Nom";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(109, 112);
            label2.Name = "label2";
            label2.Size = new Size(60, 20);
            label2.TabIndex = 1;
            label2.Text = "Prénom";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(118, 162);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 2;
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(94, 207);
            label4.Name = "label4";
            label4.Size = new Size(98, 20);
            label4.TabIndex = 3;
            label4.Text = "Mot de passe";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(82, 258);
            label5.Name = "label5";
            label5.Size = new Size(129, 20);
            label5.TabIndex = 4;
            label5.Text = "Date de naissance";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(68, 315);
            label6.Name = "label6";
            label6.Size = new Size(155, 20);
            label6.TabIndex = 5;
            label6.Text = "Numero de téléphone";
            // 
            // tbNom
            // 
            tbNom.Location = new Point(286, 56);
            tbNom.Name = "tbNom";
            tbNom.PlaceholderText = "Nom";
            tbNom.Size = new Size(174, 27);
            tbNom.TabIndex = 6;
            // 
            // tbPrenom
            // 
            tbPrenom.Location = new Point(286, 109);
            tbPrenom.Name = "tbPrenom";
            tbPrenom.PlaceholderText = "Prenom";
            tbPrenom.Size = new Size(174, 27);
            tbPrenom.TabIndex = 7;
            // 
            // tbEmail
            // 
            tbEmail.Location = new Point(286, 159);
            tbEmail.Name = "tbEmail";
            tbEmail.PlaceholderText = "Email";
            tbEmail.Size = new Size(174, 27);
            tbEmail.TabIndex = 8;
            // 
            // tbMdp
            // 
            tbMdp.Location = new Point(286, 207);
            tbMdp.Name = "tbMdp";
            tbMdp.PasswordChar = '*';
            tbMdp.PlaceholderText = "Mot de passe";
            tbMdp.Size = new Size(174, 27);
            tbMdp.TabIndex = 9;
            // 
            // dtpNaissance
            // 
            dtpNaissance.Location = new Point(231, 258);
            dtpNaissance.Name = "dtpNaissance";
            dtpNaissance.Size = new Size(250, 27);
            dtpNaissance.TabIndex = 10;
            // 
            // tbNumTel
            // 
            tbNumTel.Location = new Point(286, 308);
            tbNumTel.Name = "tbNumTel";
            tbNumTel.PlaceholderText = "Numero de téléphone";
            tbNumTel.Size = new Size(174, 27);
            tbNumTel.TabIndex = 11;
            // 
            // btAjouter
            // 
            btAjouter.Location = new Point(240, 391);
            btAjouter.Name = "btAjouter";
            btAjouter.Size = new Size(94, 29);
            btAjouter.TabIndex = 12;
            btAjouter.Text = "Ajouter";
            btAjouter.UseVisualStyleBackColor = true;
            btAjouter.Click += btAjouter_Click;
            // 
            // FormInscriptionEleve
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(894, 520);
            Controls.Add(btAjouter);
            Controls.Add(tbNumTel);
            Controls.Add(dtpNaissance);
            Controls.Add(tbMdp);
            Controls.Add(tbEmail);
            Controls.Add(tbPrenom);
            Controls.Add(tbNom);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormInscriptionEleve";
            Text = "FormInscriptionEleve";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox tbNom;
        private TextBox tbPrenom;
        private TextBox tbEmail;
        private TextBox tbMdp;
        private DateTimePicker dtpNaissance;
        private TextBox tbNumTel;
        private Button btAjouter;
    }
}