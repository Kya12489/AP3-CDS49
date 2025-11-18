namespace AP3_AppliC.view
{
    partial class FormChangementMdp
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
            btnAnnuler = new Button();
            label1 = new Label();
            labelNomEleve = new Label();
            label2 = new Label();
            tbMdp = new TextBox();
            btnAttribuer = new Button();
            SuspendLayout();
            // 
            // btnAnnuler
            // 
            btnAnnuler.BackColor = Color.Black;
            btnAnnuler.FlatStyle = FlatStyle.Popup;
            btnAnnuler.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAnnuler.ForeColor = Color.White;
            btnAnnuler.Location = new Point(142, 274);
            btnAnnuler.Margin = new Padding(3, 2, 3, 2);
            btnAnnuler.Name = "btnAnnuler";
            btnAnnuler.Size = new Size(118, 43);
            btnAnnuler.TabIndex = 7;
            btnAnnuler.Text = "ANNULER";
            btnAnnuler.UseVisualStyleBackColor = false;
            btnAnnuler.Click += btnAnnuler_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 34);
            label1.Name = "label1";
            label1.Size = new Size(213, 21);
            label1.TabIndex = 8;
            label1.Text = "Changement mot de passe :";
            // 
            // labelNomEleve
            // 
            labelNomEleve.AutoSize = true;
            labelNomEleve.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelNomEleve.Location = new Point(37, 78);
            labelNomEleve.Name = "labelNomEleve";
            labelNomEleve.Size = new Size(54, 21);
            labelNomEleve.TabIndex = 9;
            labelNomEleve.Text = "label2";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 119);
            label2.Name = "label2";
            label2.Size = new Size(134, 15);
            label2.TabIndex = 11;
            label2.Text = "Nouveau mot de passe :";
            // 
            // tbMdp
            // 
            tbMdp.Location = new Point(72, 156);
            tbMdp.Margin = new Padding(3, 2, 3, 2);
            tbMdp.Name = "tbMdp";
            tbMdp.PasswordChar = '*';
            tbMdp.PlaceholderText = "Mot de passe";
            tbMdp.Size = new Size(153, 23);
            tbMdp.TabIndex = 12;
            // 
            // btnAttribuer
            // 
            btnAttribuer.BackColor = Color.Black;
            btnAttribuer.FlatStyle = FlatStyle.Popup;
            btnAttribuer.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAttribuer.ForeColor = Color.White;
            btnAttribuer.Location = new Point(88, 196);
            btnAttribuer.Margin = new Padding(3, 2, 3, 2);
            btnAttribuer.Name = "btnAttribuer";
            btnAttribuer.Size = new Size(118, 43);
            btnAttribuer.TabIndex = 13;
            btnAttribuer.Text = "ATTRIBUER";
            btnAttribuer.UseVisualStyleBackColor = false;
            btnAttribuer.Click += btnAttribuer_Click;
            // 
            // FormChangementMdp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(298, 338);
            Controls.Add(btnAttribuer);
            Controls.Add(tbMdp);
            Controls.Add(label2);
            Controls.Add(labelNomEleve);
            Controls.Add(label1);
            Controls.Add(btnAnnuler);
            Name = "FormChangementMdp";
            Text = "FormChangementMdp";
            Load += FormChangementMdp_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAnnuler;
        private Label label1;
        private Label labelNomEleve;
        private Label label2;
        private TextBox tbMdp;
        private Button btnAttribuer;
    }
}