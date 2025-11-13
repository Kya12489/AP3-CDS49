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
            pnlCalendrier = new Panel();
            lblMoisAnnee = new Label();
            SuspendLayout();
            // 
            // pnlCalendrier
            // 
            pnlCalendrier.Location = new Point(37, 56);
            pnlCalendrier.Name = "pnlCalendrier";
            pnlCalendrier.Size = new Size(721, 352);
            pnlCalendrier.TabIndex = 0;
            // 
            // lblMoisAnnee
            // 
            lblMoisAnnee.AutoSize = true;
            lblMoisAnnee.Location = new Point(422, 22);
            lblMoisAnnee.Name = "lblMoisAnnee";
            lblMoisAnnee.Size = new Size(50, 20);
            lblMoisAnnee.TabIndex = 1;
            lblMoisAnnee.Text = "label1";
            // 
            // FormListeLecon
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblMoisAnnee);
            Controls.Add(pnlCalendrier);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormListeLecon";
            Text = "FormListeLecon";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlCalendrier;
        private Label lblMoisAnnee;
    }
}