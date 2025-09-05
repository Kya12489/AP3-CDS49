namespace AP3_AppliC
{
    partial class FormAttribuerForfait
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
            cbForfaits = new ComboBox();
            bsForfaits = new BindingSource(components);
            btnAnnuler = new Button();
            btnAttribuer = new Button();
            labelNomEleve = new Label();
            ((System.ComponentModel.ISupportInitialize)bsForfaits).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(38, 57);
            label1.Name = "label1";
            label1.Size = new Size(225, 28);
            label1.TabIndex = 0;
            label1.Text = "Choisir un forfait pour :";
            // 
            // cbForfaits
            // 
            cbForfaits.DropDownStyle = ComboBoxStyle.DropDownList;
            cbForfaits.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cbForfaits.FormattingEnabled = true;
            cbForfaits.Location = new Point(38, 171);
            cbForfaits.Name = "cbForfaits";
            cbForfaits.Size = new Size(273, 36);
            cbForfaits.TabIndex = 1;
            // 
            // btnAnnuler
            // 
            btnAnnuler.BackColor = Color.Black;
            btnAnnuler.FlatStyle = FlatStyle.Popup;
            btnAnnuler.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAnnuler.ForeColor = Color.White;
            btnAnnuler.Location = new Point(176, 381);
            btnAnnuler.Name = "btnAnnuler";
            btnAnnuler.Size = new Size(135, 57);
            btnAnnuler.TabIndex = 6;
            btnAnnuler.Text = "ANNULER";
            btnAnnuler.UseVisualStyleBackColor = false;
            btnAnnuler.Click += btnFermer_Click;
            // 
            // btnAttribuer
            // 
            btnAttribuer.BackColor = Color.Black;
            btnAttribuer.FlatStyle = FlatStyle.Popup;
            btnAttribuer.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAttribuer.ForeColor = Color.White;
            btnAttribuer.Location = new Point(104, 242);
            btnAttribuer.Name = "btnAttribuer";
            btnAttribuer.Size = new Size(135, 57);
            btnAttribuer.TabIndex = 7;
            btnAttribuer.Text = "ATTRIBUER";
            btnAttribuer.UseVisualStyleBackColor = false;
            btnAttribuer.Click += btnAttribuer_Click;
            // 
            // labelNomEleve
            // 
            labelNomEleve.AutoSize = true;
            labelNomEleve.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelNomEleve.Location = new Point(38, 106);
            labelNomEleve.Name = "labelNomEleve";
            labelNomEleve.Size = new Size(66, 28);
            labelNomEleve.TabIndex = 8;
            labelNomEleve.Text = "label2";
            // 
            // FormAttribuerForfait
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkKhaki;
            ClientSize = new Size(340, 450);
            Controls.Add(labelNomEleve);
            Controls.Add(btnAttribuer);
            Controls.Add(btnAnnuler);
            Controls.Add(cbForfaits);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "FormAttribuerForfait";
            Text = "Attribuer un Forfait";
            Load += FormAttribuerForfait_Load;
            ((System.ComponentModel.ISupportInitialize)bsForfaits).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cbForfaits;
        private BindingSource bsForfaits;
        private Button btnAnnuler;
        private Button btnAttribuer;
        private Label labelNomEleve;
    }
}