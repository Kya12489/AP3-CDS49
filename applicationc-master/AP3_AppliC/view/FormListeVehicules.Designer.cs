namespace AP3_AppliC.view
{
    partial class FormListeVehicules
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
            dgvVehicules = new DataGridView();
            btnFermer = new Button();
            bsVehicules = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dgvVehicules).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsVehicules).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(81, 24);
            label1.Name = "label1";
            label1.Size = new Size(174, 25);
            label1.TabIndex = 1;
            label1.Text = "Liste des Véhicules";
            // 
            // dgvVehicules
            // 
            dgvVehicules.AllowUserToAddRows = false;
            dgvVehicules.AllowUserToDeleteRows = false;
            dgvVehicules.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVehicules.Location = new Point(70, 74);
            dgvVehicules.Name = "dgvVehicules";
            dgvVehicules.RowHeadersVisible = false;
            dgvVehicules.Size = new Size(723, 296);
            dgvVehicules.TabIndex = 2;
            // 
            // btnFermer
            // 
            btnFermer.BackColor = Color.Black;
            btnFermer.FlatStyle = FlatStyle.Popup;
            btnFermer.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFermer.ForeColor = Color.White;
            btnFermer.Location = new Point(732, 390);
            btnFermer.Margin = new Padding(3, 2, 3, 2);
            btnFermer.Name = "btnFermer";
            btnFermer.Size = new Size(118, 43);
            btnFermer.TabIndex = 5;
            btnFermer.Text = "FERMER";
            btnFermer.UseVisualStyleBackColor = false;
            btnFermer.Click += btnFermer_Click;
            // 
            // FormListeVehicules
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(918, 456);
            Controls.Add(btnFermer);
            Controls.Add(dgvVehicules);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormListeVehicules";
            Text = "FormListeVehicules";
            Load += FormListeVehicules_Load;
            ((System.ComponentModel.ISupportInitialize)dgvVehicules).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsVehicules).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvVehicules;
        private Button btnFermer;
        private BindingSource bsVehicules;
    }
}