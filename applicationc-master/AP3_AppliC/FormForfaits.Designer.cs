namespace AP3_AppliC
{
    partial class FormForfaits
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
            cbForfaits = new ComboBox();
            label1 = new Label();
            bsForfaits = new BindingSource(components);
            lbDetails = new ListBox();
            btnSupprimer = new Button();
            btnFermer = new Button();
            ((System.ComponentModel.ISupportInitialize)bsForfaits).BeginInit();
            SuspendLayout();
            // 
            // cbForfaits
            // 
            cbForfaits.DropDownStyle = ComboBoxStyle.DropDownList;
            cbForfaits.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbForfaits.FormattingEnabled = true;
            cbForfaits.Location = new Point(82, 88);
            cbForfaits.Name = "cbForfaits";
            cbForfaits.Size = new Size(614, 36);
            cbForfaits.TabIndex = 0;
            cbForfaits.SelectedIndexChanged += cbForfaits_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(82, 38);
            label1.Name = "label1";
            label1.Size = new Size(227, 31);
            label1.TabIndex = 1;
            label1.Text = "Gestion des Forfaits";
            // 
            // bsForfaits
            // 
            bsForfaits.CurrentChanged += bsForfaits_CurrentChanged;
            // 
            // lbDetails
            // 
            lbDetails.FormattingEnabled = true;
            lbDetails.HorizontalScrollbar = true;
            lbDetails.Location = new Point(82, 160);
            lbDetails.Name = "lbDetails";
            lbDetails.Size = new Size(761, 184);
            lbDetails.TabIndex = 2;
            lbDetails.Visible = false;
            // 
            // btnSupprimer
            // 
            btnSupprimer.BackColor = Color.Black;
            btnSupprimer.FlatStyle = FlatStyle.Popup;
            btnSupprimer.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSupprimer.ForeColor = SystemColors.ControlLightLight;
            btnSupprimer.Location = new Point(84, 364);
            btnSupprimer.Name = "btnSupprimer";
            btnSupprimer.Size = new Size(140, 57);
            btnSupprimer.TabIndex = 3;
            btnSupprimer.Text = "SUPPRIMER";
            btnSupprimer.UseVisualStyleBackColor = false;
            btnSupprimer.Visible = false;
            btnSupprimer.Click += btnSupprimer_Click;
            // 
            // btnFermer
            // 
            btnFermer.BackColor = Color.Black;
            btnFermer.FlatStyle = FlatStyle.Popup;
            btnFermer.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFermer.ForeColor = Color.White;
            btnFermer.Location = new Point(708, 364);
            btnFermer.Name = "btnFermer";
            btnFermer.Size = new Size(135, 57);
            btnFermer.TabIndex = 5;
            btnFermer.Text = "FERMER";
            btnFermer.UseVisualStyleBackColor = false;
            btnFermer.Click += btnFermer_Click;
            // 
            // FormForfaits
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 128, 0);
            ClientSize = new Size(966, 450);
            Controls.Add(btnFermer);
            Controls.Add(btnSupprimer);
            Controls.Add(lbDetails);
            Controls.Add(label1);
            Controls.Add(cbForfaits);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormForfaits";
            Text = "FormForfaits";
            Load += FormForfaits_Load;
            ((System.ComponentModel.ISupportInitialize)bsForfaits).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbForfaits;
        private Label label1;
        private BindingSource bsForfaits;
        private ListBox lbDetails;
        private Button btnSupprimer;
        private Button btnFermer;
    }
}