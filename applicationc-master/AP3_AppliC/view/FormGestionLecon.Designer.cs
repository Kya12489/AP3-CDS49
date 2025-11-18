namespace AP3_AppliC.view
{
    partial class FormGestionLecon
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
            cbEleve = new ComboBox();
            cbMoniteur = new ComboBox();
            cbVehicule = new ComboBox();
            dtpLecon = new DateTimePicker();
            lblEleve = new Label();
            lblMoniteur = new Label();
            lblVehicule = new Label();
            btAjout = new Button();
            bsEleve = new BindingSource(components);
            bsMoniteur = new BindingSource(components);
            bsVehicule = new BindingSource(components);
            cbLieu = new ComboBox();
            lblLieu = new Label();
            ((System.ComponentModel.ISupportInitialize)bsEleve).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsMoniteur).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsVehicule).BeginInit();
            SuspendLayout();
            // 
            // cbEleve
            // 
            cbEleve.FormattingEnabled = true;
            cbEleve.Location = new Point(360, 83);
            cbEleve.Name = "cbEleve";
            cbEleve.Size = new Size(121, 23);
            cbEleve.TabIndex = 0;
            // 
            // cbMoniteur
            // 
            cbMoniteur.FormattingEnabled = true;
            cbMoniteur.Location = new Point(360, 128);
            cbMoniteur.Name = "cbMoniteur";
            cbMoniteur.Size = new Size(121, 23);
            cbMoniteur.TabIndex = 1;
            // 
            // cbVehicule
            // 
            cbVehicule.FormattingEnabled = true;
            cbVehicule.Location = new Point(360, 176);
            cbVehicule.Name = "cbVehicule";
            cbVehicule.Size = new Size(121, 23);
            cbVehicule.TabIndex = 2;
            // 
            // dtpLecon
            // 
            dtpLecon.Location = new Point(326, 262);
            dtpLecon.Name = "dtpLecon";
            dtpLecon.Size = new Size(200, 23);
            dtpLecon.TabIndex = 3;
            // 
            // lblEleve
            // 
            lblEleve.AutoSize = true;
            lblEleve.Location = new Point(224, 86);
            lblEleve.Name = "lblEleve";
            lblEleve.Size = new Size(34, 15);
            lblEleve.TabIndex = 4;
            lblEleve.Text = "Elève";
            // 
            // lblMoniteur
            // 
            lblMoniteur.AutoSize = true;
            lblMoniteur.Location = new Point(224, 131);
            lblMoniteur.Name = "lblMoniteur";
            lblMoniteur.Size = new Size(56, 15);
            lblMoniteur.TabIndex = 5;
            lblMoniteur.Text = "Moniteur";
            // 
            // lblVehicule
            // 
            lblVehicule.AutoSize = true;
            lblVehicule.Location = new Point(224, 184);
            lblVehicule.Name = "lblVehicule";
            lblVehicule.Size = new Size(51, 15);
            lblVehicule.TabIndex = 6;
            lblVehicule.Text = "Véhicule";
            // 
            // btAjout
            // 
            btAjout.Location = new Point(382, 311);
            btAjout.Name = "btAjout";
            btAjout.Size = new Size(76, 28);
            btAjout.TabIndex = 7;
            btAjout.Text = "AJOUTER";
            btAjout.UseVisualStyleBackColor = true;
            btAjout.Click += btAjout_Click;
            // 
            // cbLieu
            // 
            cbLieu.FormattingEnabled = true;
            cbLieu.Location = new Point(360, 221);
            cbLieu.Name = "cbLieu";
            cbLieu.Size = new Size(121, 23);
            cbLieu.TabIndex = 8;
            // 
            // lblLieu
            // 
            lblLieu.AutoSize = true;
            lblLieu.Location = new Point(224, 224);
            lblLieu.Name = "lblLieu";
            lblLieu.Size = new Size(29, 15);
            lblLieu.TabIndex = 9;
            lblLieu.Text = "Lieu";
            // 
            // FormGestionLecon
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(898, 404);
            Controls.Add(lblLieu);
            Controls.Add(cbLieu);
            Controls.Add(btAjout);
            Controls.Add(lblVehicule);
            Controls.Add(lblMoniteur);
            Controls.Add(lblEleve);
            Controls.Add(dtpLecon);
            Controls.Add(cbVehicule);
            Controls.Add(cbMoniteur);
            Controls.Add(cbEleve);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormGestionLecon";
            Text = "FormGestionLecon";
            ((System.ComponentModel.ISupportInitialize)bsEleve).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsMoniteur).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsVehicule).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbEleve;
        private ComboBox cbMoniteur;
        private ComboBox cbVehicule;
        private DateTimePicker dtpLecon;
        private Label lblEleve;
        private Label lblMoniteur;
        private Label lblVehicule;
        private Button btAjout;
        private BindingSource bsEleve;
        private BindingSource bsMoniteur;
        private BindingSource bsVehicule;
        private ComboBox cbLieu;
        private Label lblLieu;
    }
}