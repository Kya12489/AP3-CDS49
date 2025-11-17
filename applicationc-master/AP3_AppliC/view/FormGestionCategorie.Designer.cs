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
            dgvCategorie = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCategorie).BeginInit();
            SuspendLayout();
            // 
            // dgvCategorie
            // 
            dgvCategorie.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategorie.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategorie.Location = new Point(82, 53);
            dgvCategorie.Name = "dgvCategorie";
            dgvCategorie.RowHeadersVisible = false;
            dgvCategorie.Size = new Size(463, 239);
            dgvCategorie.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(119, 340);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "AJOUTER";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(435, 340);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "MODIFIER";
            button2.UseVisualStyleBackColor = true;
            // 
            // FormGestionCategorie
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(918, 456);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dgvCategorie);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormGestionCategorie";
            Text = "FormGestionCategorie";
            Load += FormGestionCategorie_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCategorie).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvCategorie;
        private Button button1;
        private Button button2;
    }
}