namespace AP3_AppliC.view
{
    partial class FormListeLecon
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
            dgvLecon = new DataGridView();
            btSupp = new Button();
            btModif = new Button();
            btAjout = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvLecon).BeginInit();
            SuspendLayout();
            // 
            // dgvLecon
            // 
            dgvLecon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLecon.Location = new Point(100, 22);
            dgvLecon.Name = "dgvLecon";
            dgvLecon.Size = new Size(711, 333);
            dgvLecon.TabIndex = 4;
            // 
            // btSupp
            // 
            btSupp.Location = new Point(100, 384);
            btSupp.Name = "btSupp";
            btSupp.Size = new Size(82, 23);
            btSupp.TabIndex = 5;
            btSupp.Text = "SUPPRIMER";
            btSupp.UseVisualStyleBackColor = true;
            // 
            // btModif
            // 
            btModif.Location = new Point(423, 384);
            btModif.Name = "btModif";
            btModif.Size = new Size(75, 23);
            btModif.TabIndex = 6;
            btModif.Text = "MODIFIER";
            btModif.UseVisualStyleBackColor = true;
            // 
            // btAjout
            // 
            btAjout.Location = new Point(736, 384);
            btAjout.Name = "btAjout";
            btAjout.Size = new Size(75, 23);
            btAjout.TabIndex = 7;
            btAjout.Text = "AJOUTER";
            btAjout.UseVisualStyleBackColor = true;
            // 
            // FormListeLecon
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 443);
            Controls.Add(btAjout);
            Controls.Add(btModif);
            Controls.Add(btSupp);
            Controls.Add(dgvLecon);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormListeLecon";
            Text = "FormListeLecon";
            ((System.ComponentModel.ISupportInitialize)dgvLecon).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panelMoniteursDispo;
        private Panel panelVehicule;
        private DataGridView dgvLecon;
        private Button btSupp;
        private Button btModif;
        private Button btAjout;
    }
}