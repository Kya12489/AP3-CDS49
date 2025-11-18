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
            tbReponse4 = new TextBox();
            pbImageQuestion = new PictureBox();
            btAjoutImage = new Button();
            checkBoxRep1 = new CheckBox();
            checkBoxRep2 = new CheckBox();
            checkBoxRep3 = new CheckBox();
            checkBoxRep4 = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pbImageQuestion).BeginInit();
            SuspendLayout();
            // 
            // tbQuestion
            // 
            tbQuestion.Location = new Point(27, 63);
            tbQuestion.Multiline = true;
            tbQuestion.Name = "tbQuestion";
            tbQuestion.PlaceholderText = "Question";
            tbQuestion.Size = new Size(644, 61);
            tbQuestion.TabIndex = 0;
            // 
            // tbReponse2
            // 
            tbReponse2.Location = new Point(27, 227);
            tbReponse2.Multiline = true;
            tbReponse2.Name = "tbReponse2";
            tbReponse2.PlaceholderText = "Réponse 2";
            tbReponse2.Size = new Size(644, 61);
            tbReponse2.TabIndex = 2;
            // 
            // tbReponse1
            // 
            tbReponse1.Location = new Point(27, 159);
            tbReponse1.Multiline = true;
            tbReponse1.Name = "tbReponse1";
            tbReponse1.PlaceholderText = "Réponse 1";
            tbReponse1.Size = new Size(644, 61);
            tbReponse1.TabIndex = 1;
            // 
            // tbReponse3
            // 
            tbReponse3.Location = new Point(27, 295);
            tbReponse3.Multiline = true;
            tbReponse3.Name = "tbReponse3";
            tbReponse3.PlaceholderText = "Réponse 3 (optionnelle)";
            tbReponse3.Size = new Size(644, 61);
            tbReponse3.TabIndex = 3;
            tbReponse3.TextChanged += tbReponse3_TextChanged;
            // 
            // cbCategory
            // 
            cbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCategory.FormattingEnabled = true;
            cbCategory.Location = new Point(27, 472);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(423, 28);
            cbCategory.TabIndex = 4;
            // 
            // btAction
            // 
            btAction.Location = new Point(502, 563);
            btAction.Name = "btAction";
            btAction.Size = new Size(94, 29);
            btAction.TabIndex = 5;
            btAction.Text = "VALIDER";
            btAction.UseVisualStyleBackColor = true;
            btAction.Click += btAction_Click;
            // 
            // tbReponse4
            // 
            tbReponse4.Location = new Point(27, 363);
            tbReponse4.Multiline = true;
            tbReponse4.Name = "tbReponse4";
            tbReponse4.PlaceholderText = "Réponse 4 (optionnelle)";
            tbReponse4.Size = new Size(644, 61);
            tbReponse4.TabIndex = 4;
            tbReponse4.TextChanged += tbReponse4_TextChanged;
            // 
            // pbImageQuestion
            // 
            pbImageQuestion.BackgroundImage = Properties.Resources.Logo;
            pbImageQuestion.BackgroundImageLayout = ImageLayout.Center;
            pbImageQuestion.ErrorImage = Properties.Resources.Logo;
            pbImageQuestion.Location = new Point(783, 107);
            pbImageQuestion.Margin = new Padding(3, 4, 3, 4);
            pbImageQuestion.Name = "pbImageQuestion";
            pbImageQuestion.Size = new Size(159, 183);
            pbImageQuestion.TabIndex = 7;
            pbImageQuestion.TabStop = false;
            // 
            // btAjoutImage
            // 
            btAjoutImage.Location = new Point(823, 363);
            btAjoutImage.Margin = new Padding(3, 4, 3, 4);
            btAjoutImage.Name = "btAjoutImage";
            btAjoutImage.Size = new Size(86, 31);
            btAjoutImage.TabIndex = 8;
            btAjoutImage.Text = "AJOUTER";
            btAjoutImage.UseVisualStyleBackColor = true;
            // 
            // checkBoxRep1
            // 
            checkBoxRep1.AutoSize = true;
            checkBoxRep1.Location = new Point(677, 182);
            checkBoxRep1.Name = "checkBoxRep1";
            checkBoxRep1.Size = new Size(18, 17);
            checkBoxRep1.TabIndex = 9;
            checkBoxRep1.UseVisualStyleBackColor = true;
            // 
            // checkBoxRep2
            // 
            checkBoxRep2.AutoSize = true;
            checkBoxRep2.Location = new Point(677, 247);
            checkBoxRep2.Name = "checkBoxRep2";
            checkBoxRep2.Size = new Size(18, 17);
            checkBoxRep2.TabIndex = 10;
            checkBoxRep2.UseVisualStyleBackColor = true;
            // 
            // checkBoxRep3
            // 
            checkBoxRep3.AutoSize = true;
            checkBoxRep3.Location = new Point(677, 317);
            checkBoxRep3.Name = "checkBoxRep3";
            checkBoxRep3.Size = new Size(18, 17);
            checkBoxRep3.TabIndex = 11;
            checkBoxRep3.UseVisualStyleBackColor = true;
            // 
            // checkBoxRep4
            // 
            checkBoxRep4.AutoSize = true;
            checkBoxRep4.Location = new Point(677, 386);
            checkBoxRep4.Name = "checkBoxRep4";
            checkBoxRep4.Size = new Size(18, 17);
            checkBoxRep4.TabIndex = 12;
            checkBoxRep4.UseVisualStyleBackColor = true;
            // 
            // FormGestionQuizz
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1067, 660);
            Controls.Add(checkBoxRep4);
            Controls.Add(checkBoxRep3);
            Controls.Add(checkBoxRep2);
            Controls.Add(checkBoxRep1);
            Controls.Add(btAjoutImage);
            Controls.Add(pbImageQuestion);
            Controls.Add(tbReponse4);
            Controls.Add(btAction);
            Controls.Add(cbCategory);
            Controls.Add(tbReponse3);
            Controls.Add(tbReponse1);
            Controls.Add(tbReponse2);
            Controls.Add(tbQuestion);
            FormBorderStyle = FormBorderStyle.None;
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
        private TextBox tbReponse4;
        private PictureBox pbImageQuestion;
        private Button btAjoutImage;
        private CheckBox checkBoxRep1;
        private CheckBox checkBoxRep2;
        private CheckBox checkBoxRep3;
        private CheckBox checkBoxRep4;
    }
}