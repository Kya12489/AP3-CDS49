namespace AP3_AppliC.view
{
    partial class FormGestionVehicules
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
            lblTitre = new Label();
            tbNbPassagers = new TextBox();
            tbImmatriculation = new TextBox();
            tbDesignation = new TextBox();
            cbType = new ComboBox();
            btAction = new Button();
            btnFermer = new Button();
            SuspendLayout();
            // 
            // lblTitre
            // 
            lblTitre.AutoSize = true;
            lblTitre.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitre.Location = new Point(121, 115);
            lblTitre.Name = "lblTitre";
            lblTitre.Size = new Size(223, 31);
            lblTitre.TabIndex = 2;
            lblTitre.Text = "Ajout des Véhicules";
            // 
            // tbNbPassagers
            // 
            tbNbPassagers.Location = new Point(399, 171);
            tbNbPassagers.Margin = new Padding(3, 4, 3, 4);
            tbNbPassagers.Name = "tbNbPassagers";
            tbNbPassagers.PlaceholderText = "Nombre Passagers";
            tbNbPassagers.Size = new Size(129, 27);
            tbNbPassagers.TabIndex = 3;
            // 
            // tbImmatriculation
            // 
            tbImmatriculation.Location = new Point(399, 237);
            tbImmatriculation.Margin = new Padding(3, 4, 3, 4);
            tbImmatriculation.Name = "tbImmatriculation";
            tbImmatriculation.PlaceholderText = "Immatriculation";
            tbImmatriculation.Size = new Size(129, 27);
            tbImmatriculation.TabIndex = 4;
            tbImmatriculation.TextChanged += tbImmatriculation_TextChanged;
            tbImmatriculation.KeyPress += tbImmatriculation_KeyPress;
            // 
            // tbDesignation
            // 
            tbDesignation.Location = new Point(399, 310);
            tbDesignation.Margin = new Padding(3, 4, 3, 4);
            tbDesignation.Name = "tbDesignation";
            tbDesignation.PlaceholderText = "Designation";
            tbDesignation.Size = new Size(129, 27);
            tbDesignation.TabIndex = 5;
            // 
            // cbType
            // 
            cbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbType.FormattingEnabled = true;
            cbType.Location = new Point(399, 380);
            cbType.Margin = new Padding(3, 4, 3, 4);
            cbType.Name = "cbType";
            cbType.Size = new Size(129, 28);
            cbType.TabIndex = 6;
            // 
            // btAction
            // 
            btAction.Location = new Point(416, 451);
            btAction.Name = "btAction";
            btAction.Size = new Size(94, 29);
            btAction.TabIndex = 14;
            btAction.Text = "AJOUTER";
            btAction.UseVisualStyleBackColor = true;
            btAction.Click += btAjouter_Click;
            // 
            // btnFermer
            // 
            btnFermer.BackColor = Color.Black;
            btnFermer.FlatStyle = FlatStyle.Popup;
            btnFermer.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFermer.ForeColor = Color.White;
            btnFermer.Location = new Point(850, 502);
            btnFermer.Name = "btnFermer";
            btnFermer.Size = new Size(135, 57);
            btnFermer.TabIndex = 15;
            btnFermer.Text = "FERMER";
            btnFermer.UseVisualStyleBackColor = false;
            btnFermer.Click += btnFermer_Click;
            // 
            // FormGestionVehicules
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1049, 608);
            Controls.Add(btnFermer);
            Controls.Add(btAction);
            Controls.Add(cbType);
            Controls.Add(tbDesignation);
            Controls.Add(tbImmatriculation);
            Controls.Add(tbNbPassagers);
            Controls.Add(lblTitre);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormGestionVehicules";
            Text = "FormGestionVehicules";
            Load += FormGestionVehicules_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitre;
        private TextBox tbNbPassagers;
        private TextBox tbImmatriculation;
        private TextBox tbDesignation;
        private ComboBox cbType;
        private Button btAction;
        private Button btnFermer;
    }
}