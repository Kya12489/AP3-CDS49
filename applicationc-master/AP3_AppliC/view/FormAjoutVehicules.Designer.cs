namespace AP3_AppliC.view
{
    partial class FormAjoutVehicules
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
            tbNbPassagers = new TextBox();
            tbImmatriculation = new TextBox();
            tbDesignation = new TextBox();
            cbType = new ComboBox();
            btAjouter = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(91, 64);
            label1.Name = "label1";
            label1.Size = new Size(223, 31);
            label1.TabIndex = 1;
            label1.Text = "Ajout des Véhicules";
            // 
            // tbNbPassagers
            // 
            tbNbPassagers.Location = new Point(374, 127);
            tbNbPassagers.Margin = new Padding(3, 4, 3, 4);
            tbNbPassagers.Name = "tbNbPassagers";
            tbNbPassagers.PlaceholderText = "Nombre Passagers";
            tbNbPassagers.Size = new Size(129, 27);
            tbNbPassagers.TabIndex = 2;
            // 
            // tbImmatriculation
            // 
            tbImmatriculation.Location = new Point(374, 219);
            tbImmatriculation.Margin = new Padding(3, 4, 3, 4);
            tbImmatriculation.Name = "tbImmatriculation";
            tbImmatriculation.PlaceholderText = "Immatriculation";
            tbImmatriculation.Size = new Size(129, 27);
            tbImmatriculation.TabIndex = 3;
            // 
            // tbDesignation
            // 
            tbDesignation.Location = new Point(374, 283);
            tbDesignation.Margin = new Padding(3, 4, 3, 4);
            tbDesignation.Name = "tbDesignation";
            tbDesignation.PlaceholderText = "Designation";
            tbDesignation.Size = new Size(129, 27);
            tbDesignation.TabIndex = 4;
            // 
            // cbType
            // 
            cbType.FormattingEnabled = true;
            cbType.Location = new Point(374, 365);
            cbType.Margin = new Padding(3, 4, 3, 4);
            cbType.Name = "cbType";
            cbType.Size = new Size(129, 28);
            cbType.TabIndex = 5;
            // 
            // btAjouter
            // 
            btAjouter.Location = new Point(391, 433);
            btAjouter.Name = "btAjouter";
            btAjouter.Size = new Size(94, 29);
            btAjouter.TabIndex = 13;
            btAjouter.Text = "Ajouter";
            btAjouter.UseVisualStyleBackColor = true;
            // 
            // FormAjoutVehicules
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1049, 608);
            Controls.Add(btAjouter);
            Controls.Add(cbType);
            Controls.Add(tbDesignation);
            Controls.Add(tbImmatriculation);
            Controls.Add(tbNbPassagers);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormAjoutVehicules";
            Text = "FormAjoutVehicules";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbNbPassagers;
        private TextBox tbImmatriculation;
        private TextBox tbDesignation;
        private ComboBox cbType;
        private Button btAjouter;
    }
}