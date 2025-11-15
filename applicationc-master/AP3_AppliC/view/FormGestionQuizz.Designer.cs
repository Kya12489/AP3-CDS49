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
            SuspendLayout();
            // 
            // tbQuestion
            // 
            tbQuestion.Location = new Point(27, 76);
            tbQuestion.Name = "tbQuestion";
            tbQuestion.PlaceholderText = "Question";
            tbQuestion.Size = new Size(852, 27);
            tbQuestion.TabIndex = 0;
            // 
            // tbReponse2
            // 
            tbReponse2.Location = new Point(27, 214);
            tbReponse2.Name = "tbReponse2";
            tbReponse2.PlaceholderText = "Réponse 2";
            tbReponse2.Size = new Size(852, 27);
            tbReponse2.TabIndex = 1;
            // 
            // tbReponse1
            // 
            tbReponse1.Location = new Point(27, 171);
            tbReponse1.Name = "tbReponse1";
            tbReponse1.PlaceholderText = "Réponse 1";
            tbReponse1.Size = new Size(852, 27);
            tbReponse1.TabIndex = 2;
            // 
            // tbReponse3
            // 
            tbReponse3.Location = new Point(27, 262);
            tbReponse3.Name = "tbReponse3";
            tbReponse3.PlaceholderText = "Réponse 3";
            tbReponse3.Size = new Size(852, 27);
            tbReponse3.TabIndex = 3;
            // 
            // cbCategory
            // 
            cbCategory.FormattingEnabled = true;
            cbCategory.Location = new Point(27, 324);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(423, 28);
            cbCategory.TabIndex = 4;
            // 
            // btAction
            // 
            btAction.Location = new Point(437, 416);
            btAction.Name = "btAction";
            btAction.Size = new Size(94, 29);
            btAction.TabIndex = 5;
            btAction.Text = "VALIDER";
            btAction.UseVisualStyleBackColor = true;
            // 
            // FormGestionQuizz
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1013, 509);
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
    }
}