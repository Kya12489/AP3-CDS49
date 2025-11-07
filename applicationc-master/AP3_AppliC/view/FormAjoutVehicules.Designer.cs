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
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(80, 48);
            label1.Name = "label1";
            label1.Size = new Size(183, 25);
            label1.TabIndex = 1;
            label1.Text = "Ajout des Véhicules";
            // 
            // tbNbPassagers
            // 
            tbNbPassagers.Location = new Point(327, 95);
            tbNbPassagers.Name = "tbNbPassagers";
            tbNbPassagers.PlaceholderText = "Nombre Passagers";
            tbNbPassagers.Size = new Size(113, 23);
            tbNbPassagers.TabIndex = 2;
            // 
            // tbImmatriculation
            // 
            tbImmatriculation.Location = new Point(327, 164);
            tbImmatriculation.Name = "tbImmatriculation";
            tbImmatriculation.PlaceholderText = "Immatriculation";
            tbImmatriculation.Size = new Size(113, 23);
            tbImmatriculation.TabIndex = 3;
            // 
            // tbDesignation
            // 
            tbDesignation.Location = new Point(327, 212);
            tbDesignation.Name = "tbDesignation";
            tbDesignation.PlaceholderText = "Designation";
            tbDesignation.Size = new Size(113, 23);
            tbDesignation.TabIndex = 4;
            // 
            // cbType
            // 
            cbType.FormattingEnabled = true;
            cbType.Location = new Point(327, 274);
            cbType.Name = "cbType";
            cbType.Size = new Size(113, 23);
            cbType.TabIndex = 5;
            // 
            // FormAjoutVehicules
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(918, 456);
            Controls.Add(cbType);
            Controls.Add(tbDesignation);
            Controls.Add(tbImmatriculation);
            Controls.Add(tbNbPassagers);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
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
    }
}