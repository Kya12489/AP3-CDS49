namespace AP3_AppliC.view
{
    partial class FormGestionCategorie
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
            dgvCategorie = new DataGridView();
            btAjouter = new Button();
            btModifier = new Button();
            bsCategorie = new BindingSource(components);
            btSupprimer = new Button();
            btRetour = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCategorie).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsCategorie).BeginInit();
            SuspendLayout();
            // 
            // dgvCategorie
            // 
            dgvCategorie.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategorie.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategorie.Location = new Point(30, 54);
            dgvCategorie.Margin = new Padding(3, 4, 3, 4);
            dgvCategorie.Name = "dgvCategorie";
            dgvCategorie.RowHeadersVisible = false;
            dgvCategorie.RowHeadersWidth = 51;
            dgvCategorie.Size = new Size(984, 436);
            dgvCategorie.TabIndex = 0;
            // 
            // btAjouter
            // 
            btAjouter.Location = new Point(907, 530);
            btAjouter.Margin = new Padding(3, 4, 3, 4);
            btAjouter.Name = "btAjouter";
            btAjouter.Size = new Size(86, 31);
            btAjouter.TabIndex = 1;
            btAjouter.Text = "AJOUTER";
            btAjouter.UseVisualStyleBackColor = true;
            btAjouter.Click += btAjouter_Click;
            // 
            // btModifier
            // 
            btModifier.Location = new Point(470, 530);
            btModifier.Margin = new Padding(3, 4, 3, 4);
            btModifier.Name = "btModifier";
            btModifier.Size = new Size(86, 31);
            btModifier.TabIndex = 2;
            btModifier.Text = "MODIFIER";
            btModifier.UseVisualStyleBackColor = true;
            btModifier.Click += btModifier_Click;
            // 
            // btSupprimer
            // 
            btSupprimer.Location = new Point(43, 532);
            btSupprimer.Name = "btSupprimer";
            btSupprimer.Size = new Size(94, 29);
            btSupprimer.TabIndex = 3;
            btSupprimer.Text = "SUPPRIMER";
            btSupprimer.UseVisualStyleBackColor = true;
            btSupprimer.Click += btSupprimer_Click;
            // 
            // btRetour
            // 
            btRetour.Location = new Point(30, 12);
            btRetour.Name = "btRetour";
            btRetour.Size = new Size(94, 29);
            btRetour.TabIndex = 4;
            btRetour.Text = "RETOUR";
            btRetour.UseVisualStyleBackColor = true;
            btRetour.Click += btRetour_Click;
            // 
            // FormGestionCategorie
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1049, 608);
            Controls.Add(btRetour);
            Controls.Add(btSupprimer);
            Controls.Add(btModifier);
            Controls.Add(btAjouter);
            Controls.Add(dgvCategorie);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormGestionCategorie";
            Text = "FormGestionCategorie";
            Load += FormGestionCategorie_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCategorie).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsCategorie).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvCategorie;
        private Button btAjouter;
        private Button btModifier;
        private BindingSource bsCategorie;
        private Button btSupprimer;
        private Button btRetour;
    }
}