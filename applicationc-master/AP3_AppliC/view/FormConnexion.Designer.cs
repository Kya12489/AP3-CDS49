namespace AP3_AppliC.view
{
    partial class FormConnexion
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
            btConnexion = new Button();
            tbLogin = new TextBox();
            tbPassword = new TextBox();
            lblLogin = new Label();
            lblpassword = new Label();
            SuspendLayout();
            // 
            // btConnexion
            // 
            btConnexion.Location = new Point(323, 319);
            btConnexion.Name = "btConnexion";
            btConnexion.Size = new Size(100, 23);
            btConnexion.TabIndex = 0;
            btConnexion.Text = "se connecter";
            btConnexion.UseVisualStyleBackColor = true;
            btConnexion.Click += btConnexion_Click;
            // 
            // tbLogin
            // 
            tbLogin.Location = new Point(284, 119);
            tbLogin.Name = "tbLogin";
            tbLogin.Size = new Size(178, 23);
            tbLogin.TabIndex = 1;
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(284, 218);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(178, 23);
            tbPassword.TabIndex = 2;
            tbPassword.UseSystemPasswordChar = true;
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Location = new Point(346, 101);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(61, 15);
            lblLogin.TabIndex = 3;
            lblLogin.Text = "Identifiant";
            // 
            // lblpassword
            // 
            lblpassword.AutoSize = true;
            lblpassword.Location = new Point(346, 200);
            lblpassword.Name = "lblpassword";
            lblpassword.Size = new Size(77, 15);
            lblpassword.TabIndex = 4;
            lblpassword.Text = "Mot de passe";
            // 
            // FormConnexion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblpassword);
            Controls.Add(lblLogin);
            Controls.Add(tbPassword);
            Controls.Add(tbLogin);
            Controls.Add(btConnexion);
            Name = "FormConnexion";
            Text = "FormConnexion";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btConnexion;
        private TextBox tbLogin;
        private TextBox tbPassword;
        private Label lblLogin;
        private Label lblpassword;
    }
}