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
            btnModifier = new Button();
            btArchiver = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvVehicules).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsVehicules).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(93, 32);
            label1.Name = "label1";
            label1.Size = new Size(213, 31);
            label1.TabIndex = 1;
            label1.Text = "Liste des Véhicules";
            // 
            // dgvVehicules
            // 
            dgvVehicules.AllowUserToAddRows = false;
            dgvVehicules.AllowUserToDeleteRows = false;
            dgvVehicules.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVehicules.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVehicules.Location = new Point(80, 99);
            dgvVehicules.Margin = new Padding(3, 4, 3, 4);
            dgvVehicules.Name = "dgvVehicules";
            dgvVehicules.RowHeadersVisible = false;
            dgvVehicules.RowHeadersWidth = 51;
            dgvVehicules.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVehicules.Size = new Size(826, 395);
            dgvVehicules.TabIndex = 2;
            // 
            // btnFermer
            // 
            btnFermer.BackColor = Color.Black;
            btnFermer.FlatStyle = FlatStyle.Popup;
            btnFermer.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFermer.ForeColor = Color.White;
            btnFermer.Location = new Point(837, 520);
            btnFermer.Name = "btnFermer";
            btnFermer.Size = new Size(135, 57);
            btnFermer.TabIndex = 5;
            btnFermer.Text = "FERMER";
            btnFermer.UseVisualStyleBackColor = false;
            btnFermer.Click += btnFermer_Click;
            // 
            // btnModifier
            // 
            btnModifier.BackColor = Color.Black;
            btnModifier.FlatStyle = FlatStyle.Popup;
            btnModifier.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnModifier.ForeColor = Color.White;
            btnModifier.Location = new Point(435, 520);
            btnModifier.Name = "btnModifier";
            btnModifier.Size = new Size(135, 57);
            btnModifier.TabIndex = 6;
            btnModifier.Text = "MODIFIER";
            btnModifier.UseVisualStyleBackColor = false;
            btnModifier.Click += btnModifier_Click;
            // 
            // btArchiver
            // 
            btArchiver.BackColor = Color.Black;
            btArchiver.FlatStyle = FlatStyle.Popup;
            btArchiver.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btArchiver.ForeColor = Color.White;
            btArchiver.Location = new Point(80, 520);
            btArchiver.Name = "btArchiver";
            btArchiver.Size = new Size(135, 57);
            btArchiver.TabIndex = 7;
            btArchiver.Text = "SUPPRIMER";
            btArchiver.UseVisualStyleBackColor = false;
            btArchiver.Click += btArchiver_Click;
            // 
            // FormListeVehicules
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1049, 608);
            Controls.Add(btArchiver);
            Controls.Add(btnModifier);
            Controls.Add(btnFermer);
            Controls.Add(dgvVehicules);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
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
        private Button btnModifier;
        private Button btArchiver;
    }
}