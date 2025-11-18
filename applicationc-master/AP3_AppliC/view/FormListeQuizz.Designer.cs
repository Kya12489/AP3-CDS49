namespace AP3_AppliC.view
{
    partial class FormListeQuizz
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
            dgvQuestion = new DataGridView();
            contextMenuStrip = new ContextMenuStrip(components);
            voirSesReponseToolStripMenuItem = new ToolStripMenuItem();
            bsQuestion = new BindingSource(components);
            dgvReponse = new DataGridView();
            bsReponse = new BindingSource(components);
            cbRechercheCategorie = new ComboBox();
            btGestionCat = new Button();
            btSupp = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvQuestion).BeginInit();
            contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bsQuestion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvReponse).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsReponse).BeginInit();
            SuspendLayout();
            // 
            // dgvQuestion
            // 
            dgvQuestion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvQuestion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvQuestion.ContextMenuStrip = contextMenuStrip;
            dgvQuestion.Location = new Point(10, 47);
            dgvQuestion.Name = "dgvQuestion";
            dgvQuestion.RowHeadersVisible = false;
            dgvQuestion.RowHeadersWidth = 51;
            dgvQuestion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvQuestion.Size = new Size(912, 386);
            dgvQuestion.TabIndex = 0;
            dgvQuestion.CellContentClick += dgvQuestion_CellContentClick;
            dgvQuestion.CellMouseClick += dgvQuestion_CellMouseClick;
            dgvQuestion.Click += dgvQuestion_Click;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.ImageScalingSize = new Size(20, 20);
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { voirSesReponseToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip1";
            contextMenuStrip.Size = new Size(164, 26);
            // 
            // voirSesReponseToolStripMenuItem
            // 
            voirSesReponseToolStripMenuItem.Name = "voirSesReponseToolStripMenuItem";
            voirSesReponseToolStripMenuItem.Size = new Size(163, 22);
            voirSesReponseToolStripMenuItem.Text = "Voir ses réponses";
            voirSesReponseToolStripMenuItem.Click += voirSesReponseToolStripMenuItem_Click;
            // 
            // dgvReponse
            // 
            dgvReponse.AllowUserToAddRows = false;
            dgvReponse.AllowUserToDeleteRows = false;
            dgvReponse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReponse.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReponse.Location = new Point(465, 72);
            dgvReponse.Margin = new Padding(3, 2, 3, 2);
            dgvReponse.Name = "dgvReponse";
            dgvReponse.ReadOnly = true;
            dgvReponse.RowHeadersVisible = false;
            dgvReponse.RowHeadersWidth = 51;
            dgvReponse.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReponse.Size = new Size(468, 125);
            dgvReponse.TabIndex = 3;
            // 
            // cbRechercheCategorie
            // 
            cbRechercheCategorie.FormattingEnabled = true;
            cbRechercheCategorie.Location = new Point(610, 15);
            cbRechercheCategorie.Margin = new Padding(3, 2, 3, 2);
            cbRechercheCategorie.Name = "cbRechercheCategorie";
            cbRechercheCategorie.Size = new Size(243, 23);
            cbRechercheCategorie.TabIndex = 4;
            cbRechercheCategorie.SelectedIndexChanged += cbRechercheCategorie_SelectedIndexChanged;
            // 
            // btGestionCat
            // 
            btGestionCat.Location = new Point(704, 449);
            btGestionCat.Name = "btGestionCat";
            btGestionCat.Size = new Size(149, 23);
            btGestionCat.TabIndex = 5;
            btGestionCat.Text = "Gestion Catégorie";
            btGestionCat.UseVisualStyleBackColor = true;
            btGestionCat.Click += btGestionCat_Click;
            // 
            // btSupp
            // 
            btSupp.Location = new Point(74, 449);
            btSupp.Name = "btSupp";
            btSupp.Size = new Size(93, 23);
            btSupp.TabIndex = 6;
            btSupp.Text = "SUPPRIMER";
            btSupp.UseVisualStyleBackColor = true;
            btSupp.Click += btSupp_Click;
            // 
            // FormListeQuizz
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(934, 495);
            Controls.Add(btSupp);
            Controls.Add(btGestionCat);
            Controls.Add(cbRechercheCategorie);
            Controls.Add(dgvReponse);
            Controls.Add(dgvQuestion);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormListeQuizz";
            Text = "FormListeQuizz";
            Load += FormListeQuizz_Load;
            ((System.ComponentModel.ISupportInitialize)dgvQuestion).EndInit();
            contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)bsQuestion).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvReponse).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsReponse).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvQuestion;
        private BindingSource bsQuestion;
        private DataGridView dgvReponse;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem voirSesReponseToolStripMenuItem;
        private BindingSource bsReponse;
        private ComboBox cbRechercheCategorie;
        private Button btGestionCat;
        private Button btSupp;
    }
}