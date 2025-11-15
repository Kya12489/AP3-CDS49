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
            dgvQuestion.Location = new Point(41, 45);
            dgvQuestion.Margin = new Padding(3, 4, 3, 4);
            dgvQuestion.Name = "dgvQuestion";
            dgvQuestion.RowHeadersVisible = false;
            dgvQuestion.RowHeadersWidth = 51;
            dgvQuestion.Size = new Size(950, 469);
            dgvQuestion.TabIndex = 0;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.ImageScalingSize = new Size(20, 20);
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { voirSesReponseToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip1";
            contextMenuStrip.Size = new Size(192, 28);
            // 
            // voirSesReponseToolStripMenuItem
            // 
            voirSesReponseToolStripMenuItem.Name = "voirSesReponseToolStripMenuItem";
            voirSesReponseToolStripMenuItem.Size = new Size(191, 24);
            voirSesReponseToolStripMenuItem.Text = "Voir ses réponses";
            voirSesReponseToolStripMenuItem.Click += voirSesReponseToolStripMenuItem_Click;
            // 
            // dgvReponse
            // 
            dgvReponse.AllowUserToAddRows = false;
            dgvReponse.AllowUserToDeleteRows = false;
            dgvReponse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReponse.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReponse.Location = new Point(544, 99);
            dgvReponse.Name = "dgvReponse";
            dgvReponse.ReadOnly = true;
            dgvReponse.RowHeadersVisible = false;
            dgvReponse.RowHeadersWidth = 51;
            dgvReponse.Size = new Size(473, 301);
            dgvReponse.TabIndex = 3;
            // 
            // FormListeQuizz
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1031, 556);
            Controls.Add(dgvReponse);
            Controls.Add(dgvQuestion);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
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
    }
}