namespace AP3_AppliC
{
    partial class FormMoniteurs
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            cbListeMoniteurs = new ComboBox();
            bsMoniteurs = new BindingSource(components);
            gbInfos = new GroupBox();
            tbEmail = new TextBox();
            tbPrenom = new TextBox();
            tbNom = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            btnFermer = new Button();
            btnAction = new Button();
            ((System.ComponentModel.ISupportInitialize)bsMoniteurs).BeginInit();
            gbInfos.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(46, 29);
            label1.Name = "label1";
            label1.Size = new Size(212, 25);
            label1.TabIndex = 2;
            label1.Text = "Gestion des Moniteurs";
            // 
            // cbListeMoniteurs
            // 
            cbListeMoniteurs.DropDownStyle = ComboBoxStyle.DropDownList;
            cbListeMoniteurs.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbListeMoniteurs.FormattingEnabled = true;
            cbListeMoniteurs.Location = new Point(211, 69);
            cbListeMoniteurs.Margin = new Padding(3, 2, 3, 2);
            cbListeMoniteurs.Name = "cbListeMoniteurs";
            cbListeMoniteurs.Size = new Size(372, 29);
            cbListeMoniteurs.TabIndex = 3;
            cbListeMoniteurs.SelectedIndexChanged += cbListeMoniteurs_SelectedIndexChanged;
            // 
            // bsMoniteurs
            // 
            bsMoniteurs.CurrentChanged += bsMoniteurs_CurrentChanged;
            // 
            // gbInfos
            // 
            gbInfos.Controls.Add(tbEmail);
            gbInfos.Controls.Add(tbPrenom);
            gbInfos.Controls.Add(tbNom);
            gbInfos.Controls.Add(label4);
            gbInfos.Controls.Add(label3);
            gbInfos.Controls.Add(label2);
            gbInfos.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbInfos.Location = new Point(54, 137);
            gbInfos.Margin = new Padding(3, 2, 3, 2);
            gbInfos.Name = "gbInfos";
            gbInfos.Padding = new Padding(3, 2, 3, 2);
            gbInfos.Size = new Size(685, 161);
            gbInfos.TabIndex = 4;
            gbInfos.TabStop = false;
            gbInfos.Text = "Informations sur un moniteur";
            gbInfos.Visible = false;
            // 
            // tbEmail
            // 
            tbEmail.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbEmail.Location = new Point(157, 104);
            tbEmail.Margin = new Padding(3, 2, 3, 2);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(310, 26);
            tbEmail.TabIndex = 5;
            // 
            // tbPrenom
            // 
            tbPrenom.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbPrenom.Location = new Point(157, 66);
            tbPrenom.Margin = new Padding(3, 2, 3, 2);
            tbPrenom.Name = "tbPrenom";
            tbPrenom.Size = new Size(310, 26);
            tbPrenom.TabIndex = 4;
            // 
            // tbNom
            // 
            tbNom.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbNom.Location = new Point(157, 29);
            tbNom.Margin = new Padding(3, 2, 3, 2);
            tbNom.Name = "tbNom";
            tbNom.Size = new Size(310, 26);
            tbNom.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(60, 104);
            label4.Name = "label4";
            label4.Size = new Size(41, 19);
            label4.TabIndex = 2;
            label4.Text = "Email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(60, 66);
            label3.Name = "label3";
            label3.Size = new Size(57, 19);
            label3.TabIndex = 1;
            label3.Text = "Prénom";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(60, 28);
            label2.Name = "label2";
            label2.Size = new Size(39, 19);
            label2.TabIndex = 0;
            label2.Text = "Nom";
            // 
            // btnFermer
            // 
            btnFermer.BackColor = Color.Black;
            btnFermer.FlatStyle = FlatStyle.Popup;
            btnFermer.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFermer.ForeColor = Color.White;
            btnFermer.Location = new Point(621, 328);
            btnFermer.Margin = new Padding(3, 2, 3, 2);
            btnFermer.Name = "btnFermer";
            btnFermer.Size = new Size(118, 43);
            btnFermer.TabIndex = 5;
            btnFermer.Text = "FERMER";
            btnFermer.UseVisualStyleBackColor = false;
            btnFermer.Click += btnFermer_Click;
            // 
            // btnAction
            // 
            btnAction.BackColor = Color.Black;
            btnAction.FlatStyle = FlatStyle.Popup;
            btnAction.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAction.ForeColor = SystemColors.ControlLightLight;
            btnAction.Location = new Point(54, 328);
            btnAction.Margin = new Padding(3, 2, 3, 2);
            btnAction.Name = "btnAction";
            btnAction.Size = new Size(122, 43);
            btnAction.TabIndex = 6;
            btnAction.Text = "AJOUTER";
            btnAction.UseVisualStyleBackColor = false;
            btnAction.Click += btnAction_Click;
            // 
            // FormMoniteurs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(798, 425);
            Controls.Add(btnAction);
            Controls.Add(btnFermer);
            Controls.Add(gbInfos);
            Controls.Add(cbListeMoniteurs);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormMoniteurs";
            Text = "FormMoniteurs";
            Load += FormMoniteurs_Load;
            ((System.ComponentModel.ISupportInitialize)bsMoniteurs).EndInit();
            gbInfos.ResumeLayout(false);
            gbInfos.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cbListeMoniteurs;
        private BindingSource bsMoniteurs;
        private GroupBox gbInfos;
        private Button btnFermer;
        private TextBox tbEmail;
        private TextBox tbPrenom;
        private TextBox tbNom;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button btnAction;
    }
}