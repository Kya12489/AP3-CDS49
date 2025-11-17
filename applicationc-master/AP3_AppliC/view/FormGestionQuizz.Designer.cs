namespace AP3_AppliC.view
{
    partial class FormGestionQuizz
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
            tbQuestion = new TextBox();
            tbReponse2 = new TextBox();
            tbReponse1 = new TextBox();
            tbReponse3 = new TextBox();
            cbCategory = new ComboBox();
            btAction = new Button();
            textBox1 = new TextBox();
            pbImageQuestion = new PictureBox();
            btAjoutImage = new Button();
            ((System.ComponentModel.ISupportInitialize)pbImageQuestion).BeginInit();
            SuspendLayout();
            // 
            // tbQuestion
            // 
            tbQuestion.Location = new Point(24, 47);
            tbQuestion.Margin = new Padding(3, 2, 3, 2);
            tbQuestion.Multiline = true;
            tbQuestion.Name = "tbQuestion";
            tbQuestion.PlaceholderText = "Question";
            tbQuestion.Size = new Size(564, 47);
            tbQuestion.TabIndex = 0;
            // 
            // tbReponse2
            // 
            tbReponse2.Location = new Point(24, 170);
            tbReponse2.Margin = new Padding(3, 2, 3, 2);
            tbReponse2.Multiline = true;
            tbReponse2.Name = "tbReponse2";
            tbReponse2.PlaceholderText = "Réponse 2";
            tbReponse2.Size = new Size(564, 47);
            tbReponse2.TabIndex = 1;
            // 
            // tbReponse1
            // 
            tbReponse1.Location = new Point(24, 119);
            tbReponse1.Margin = new Padding(3, 2, 3, 2);
            tbReponse1.Multiline = true;
            tbReponse1.Name = "tbReponse1";
            tbReponse1.PlaceholderText = "Réponse 1";
            tbReponse1.Size = new Size(564, 47);
            tbReponse1.TabIndex = 2;
            // 
            // tbReponse3
            // 
            tbReponse3.Location = new Point(24, 221);
            tbReponse3.Margin = new Padding(3, 2, 3, 2);
            tbReponse3.Multiline = true;
            tbReponse3.Name = "tbReponse3";
            tbReponse3.PlaceholderText = "Réponse 3 (optionnelle)";
            tbReponse3.Size = new Size(564, 47);
            tbReponse3.TabIndex = 3;
            // 
            // cbCategory
            // 
            cbCategory.FormattingEnabled = true;
            cbCategory.Location = new Point(24, 354);
            cbCategory.Margin = new Padding(3, 2, 3, 2);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(371, 23);
            cbCategory.TabIndex = 4;
            // 
            // btAction
            // 
            btAction.Location = new Point(439, 422);
            btAction.Margin = new Padding(3, 2, 3, 2);
            btAction.Name = "btAction";
            btAction.Size = new Size(82, 22);
            btAction.TabIndex = 5;
            btAction.Text = "VALIDER";
            btAction.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(24, 272);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Réponse 4 (optionnelle)";
            textBox1.Size = new Size(564, 47);
            textBox1.TabIndex = 6;
            // 
            // pbImageQuestion
            // 
            pbImageQuestion.BackgroundImage = Properties.Resources.Logo;
            pbImageQuestion.Location = new Point(685, 80);
            pbImageQuestion.Name = "pbImageQuestion";
            pbImageQuestion.Size = new Size(139, 137);
            pbImageQuestion.TabIndex = 7;
            pbImageQuestion.TabStop = false;
            // 
            // btAjoutImage
            // 
            btAjoutImage.Location = new Point(720, 272);
            btAjoutImage.Name = "btAjoutImage";
            btAjoutImage.Size = new Size(75, 23);
            btAjoutImage.TabIndex = 8;
            btAjoutImage.Text = "AJOUTER";
            btAjoutImage.UseVisualStyleBackColor = true;
            // 
            // FormGestionQuizz
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(934, 495);
            Controls.Add(btAjoutImage);
            Controls.Add(pbImageQuestion);
            Controls.Add(textBox1);
            Controls.Add(btAction);
            Controls.Add(cbCategory);
            Controls.Add(tbReponse3);
            Controls.Add(tbReponse1);
            Controls.Add(tbReponse2);
            Controls.Add(tbQuestion);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormGestionQuizz";
            Text = "FormGestionQuizz";
            Load += FormGestionQuizz_Load;
            ((System.ComponentModel.ISupportInitialize)pbImageQuestion).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbQuestion;
        private TextBox tbReponse2;
        private TextBox tbReponse1;
        private TextBox tbReponse3;
        private ComboBox cbCategory;
        private Button btAction;
        private TextBox textBox1;
        private PictureBox pbImageQuestion;
        private Button btAjoutImage;
    }
}