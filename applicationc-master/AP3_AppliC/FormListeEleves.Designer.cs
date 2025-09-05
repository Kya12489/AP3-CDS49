namespace AP3_AppliC
{
    partial class FormListeEleves
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
            dgvEleves = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            voirSesForfaitsToolStripMenuItem = new ToolStripMenuItem();
            attribuerUnForfaitToolStripMenuItem = new ToolStripMenuItem();
            bsEleves = new BindingSource(components);
            dgvForfaits = new DataGridView();
            bsForfaitsparEleve = new BindingSource(components);
            label2 = new Label();
            btnFermer = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEleves).BeginInit();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bsEleves).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvForfaits).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsForfaitsparEleve).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(70, 48);
            label1.Name = "label1";
            label1.Size = new Size(177, 31);
            label1.TabIndex = 0;
            label1.Text = "Liste des Elèves";
            // 
            // dgvEleves
            // 
            dgvEleves.AllowUserToAddRows = false;
            dgvEleves.AllowUserToDeleteRows = false;
            dgvEleves.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvEleves.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEleves.ContextMenuStrip = contextMenuStrip1;
            dgvEleves.Location = new Point(70, 106);
            dgvEleves.MultiSelect = false;
            dgvEleves.Name = "dgvEleves";
            dgvEleves.ReadOnly = true;
            dgvEleves.RowHeadersWidth = 51;
            dgvEleves.Size = new Size(880, 373);
            dgvEleves.TabIndex = 1;
            dgvEleves.CellContentClick += dgvEleves_CellContentClick;
            dgvEleves.CellMouseClick += dgvEleves_CellMouseClick;
            dgvEleves.Click += dgvEleves_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { voirSesForfaitsToolStripMenuItem, attribuerUnForfaitToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(203, 52);
            // 
            // voirSesForfaitsToolStripMenuItem
            // 
            voirSesForfaitsToolStripMenuItem.Name = "voirSesForfaitsToolStripMenuItem";
            voirSesForfaitsToolStripMenuItem.Size = new Size(202, 24);
            voirSesForfaitsToolStripMenuItem.Text = "Voir ses forfaits";
            voirSesForfaitsToolStripMenuItem.Click += voirSesForfaitsToolStripMenuItem_Click;
            // 
            // attribuerUnForfaitToolStripMenuItem
            // 
            attribuerUnForfaitToolStripMenuItem.Name = "attribuerUnForfaitToolStripMenuItem";
            attribuerUnForfaitToolStripMenuItem.Size = new Size(202, 24);
            attribuerUnForfaitToolStripMenuItem.Text = "Attribuer un forfait";
            attribuerUnForfaitToolStripMenuItem.Click += attribuerUnForfaitToolStripMenuItem_Click;
            // 
            // dgvForfaits
            // 
            dgvForfaits.AllowUserToAddRows = false;
            dgvForfaits.AllowUserToDeleteRows = false;
            dgvForfaits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvForfaits.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvForfaits.Location = new Point(634, 177);
            dgvForfaits.Name = "dgvForfaits";
            dgvForfaits.ReadOnly = true;
            dgvForfaits.RowHeadersWidth = 51;
            dgvForfaits.Size = new Size(399, 188);
            dgvForfaits.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(70, 513);
            label2.Name = "label2";
            label2.Size = new Size(680, 28);
            label2.TabIndex = 3;
            label2.Text = "click droit sur l'élève sélectionné pour voir ses forfaits ou en attribuer un.";
            // 
            // btnFermer
            // 
            btnFermer.BackColor = Color.Black;
            btnFermer.FlatStyle = FlatStyle.Popup;
            btnFermer.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFermer.ForeColor = Color.White;
            btnFermer.Location = new Point(815, 499);
            btnFermer.Name = "btnFermer";
            btnFermer.Size = new Size(135, 57);
            btnFermer.TabIndex = 4;
            btnFermer.Text = "FERMER";
            btnFermer.UseVisualStyleBackColor = false;
            btnFermer.Click += btnFermer_Click;
            // 
            // FormListeEleves
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 128, 0);
            ClientSize = new Size(1045, 591);
            Controls.Add(btnFermer);
            Controls.Add(label2);
            Controls.Add(dgvForfaits);
            Controls.Add(dgvEleves);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormListeEleves";
            Text = "Liste des Elèves";
            Load += FormListeEleves_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEleves).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)bsEleves).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvForfaits).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsForfaitsparEleve).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvEleves;
        private BindingSource bsEleves;
        private DataGridView dgvForfaits;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem voirSesForfaitsToolStripMenuItem;
        private BindingSource bsForfaitsparEleve;
        private Label label2;
        private Button btnFermer;
        private ToolStripMenuItem attribuerUnForfaitToolStripMenuItem;
    }
}