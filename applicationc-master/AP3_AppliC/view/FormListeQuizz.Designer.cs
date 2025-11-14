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
            dgvQuizz = new DataGridView();
            bsQuizz = new BindingSource(components);
            dgvReponse = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            voirSesForfaitsToolStripMenuItem = new ToolStripMenuItem();
            attribuerUnForfaitToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dgvQuizz).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsQuizz).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvReponse).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvQuizz
            // 
            dgvQuizz.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvQuizz.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvQuizz.Location = new Point(36, 34);
            dgvQuizz.Name = "dgvQuizz";
            dgvQuizz.RowHeadersVisible = false;
            dgvQuizz.Size = new Size(831, 352);
            dgvQuizz.TabIndex = 0;
            // 
            // dgvReponse
            // 
            dgvReponse.AllowUserToAddRows = false;
            dgvReponse.AllowUserToDeleteRows = false;
            dgvReponse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvReponse.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReponse.Location = new Point(476, 74);
            dgvReponse.Margin = new Padding(3, 2, 3, 2);
            dgvReponse.Name = "dgvReponse";
            dgvReponse.ReadOnly = true;
            dgvReponse.RowHeadersWidth = 51;
            dgvReponse.Size = new Size(414, 226);
            dgvReponse.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { voirSesForfaitsToolStripMenuItem, attribuerUnForfaitToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(181, 70);
            // 
            // voirSesForfaitsToolStripMenuItem
            // 
            voirSesForfaitsToolStripMenuItem.Name = "voirSesForfaitsToolStripMenuItem";
            voirSesForfaitsToolStripMenuItem.Size = new Size(180, 22);
            voirSesForfaitsToolStripMenuItem.Text = "Voir ses forfaits";
            // 
            // attribuerUnForfaitToolStripMenuItem
            // 
            attribuerUnForfaitToolStripMenuItem.Name = "attribuerUnForfaitToolStripMenuItem";
            attribuerUnForfaitToolStripMenuItem.Size = new Size(180, 22);
            attribuerUnForfaitToolStripMenuItem.Text = "Attribuer un forfait";
            // 
            // FormListeQuizz
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(902, 417);
            Controls.Add(dgvReponse);
            Controls.Add(dgvQuizz);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormListeQuizz";
            Text = "FormListeQuizz";
            Load += FormListeQuizz_Load;
            ((System.ComponentModel.ISupportInitialize)dgvQuizz).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsQuizz).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvReponse).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvQuizz;
        private BindingSource bsQuizz;
        private DataGridView dgvReponse;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem voirSesForfaitsToolStripMenuItem;
        private ToolStripMenuItem attribuerUnForfaitToolStripMenuItem;
    }
}