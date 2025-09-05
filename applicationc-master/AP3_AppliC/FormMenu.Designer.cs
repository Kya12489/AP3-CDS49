namespace AP3_AppliC
{
    partial class FormMenu
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
            menuStrip1 = new MenuStrip();
            gestionDesElèvesToolStripMenuItem = new ToolStripMenuItem();
            listeToolStripMenuItem = new ToolStripMenuItem();
            inscriptionToolStripMenuItem = new ToolStripMenuItem();
            gestionDesConducteursToolStripMenuItem = new ToolStripMenuItem();
            listeToolStripMenuItem1 = new ToolStripMenuItem();
            ajoutToolStripMenuItem = new ToolStripMenuItem();
            modificationToolStripMenuItem = new ToolStripMenuItem();
            gestionDesForfaitsToolStripMenuItem = new ToolStripMenuItem();
            listeToolStripMenuItem3 = new ToolStripMenuItem();
            qUITTERToolStripMenuItem = new ToolStripMenuItem();
            panelPrincipal = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(255, 128, 0);
            menuStrip1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { gestionDesElèvesToolStripMenuItem, gestionDesConducteursToolStripMenuItem, gestionDesForfaitsToolStripMenuItem, qUITTERToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1067, 31);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // gestionDesElèvesToolStripMenuItem
            // 
            gestionDesElèvesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listeToolStripMenuItem, inscriptionToolStripMenuItem });
            gestionDesElèvesToolStripMenuItem.Name = "gestionDesElèvesToolStripMenuItem";
            gestionDesElèvesToolStripMenuItem.Size = new Size(165, 27);
            gestionDesElèvesToolStripMenuItem.Text = "Gestion des Elèves";
            // 
            // listeToolStripMenuItem
            // 
            listeToolStripMenuItem.Name = "listeToolStripMenuItem";
            listeToolStripMenuItem.Size = new Size(319, 28);
            listeToolStripMenuItem.Text = "Liste et Attribution de forfaits";
            listeToolStripMenuItem.Click += listeToolStripMenuItem_Click;
            // 
            // inscriptionToolStripMenuItem
            // 
            inscriptionToolStripMenuItem.Name = "inscriptionToolStripMenuItem";
            inscriptionToolStripMenuItem.Size = new Size(319, 28);
            inscriptionToolStripMenuItem.Text = "Inscription";
            inscriptionToolStripMenuItem.Click += inscriptionToolStripMenuItem_Click;
            // 
            // gestionDesConducteursToolStripMenuItem
            // 
            gestionDesConducteursToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listeToolStripMenuItem1, ajoutToolStripMenuItem, modificationToolStripMenuItem });
            gestionDesConducteursToolStripMenuItem.Name = "gestionDesConducteursToolStripMenuItem";
            gestionDesConducteursToolStripMenuItem.Size = new Size(196, 27);
            gestionDesConducteursToolStripMenuItem.Text = "Gestion des Moniteurs";
            // 
            // listeToolStripMenuItem1
            // 
            listeToolStripMenuItem1.Name = "listeToolStripMenuItem1";
            listeToolStripMenuItem1.Size = new Size(191, 28);
            listeToolStripMenuItem1.Text = "Liste";
            listeToolStripMenuItem1.Click += listeToolStripMenuItem1_Click;
            // 
            // ajoutToolStripMenuItem
            // 
            ajoutToolStripMenuItem.Name = "ajoutToolStripMenuItem";
            ajoutToolStripMenuItem.Size = new Size(191, 28);
            ajoutToolStripMenuItem.Text = "Ajout";
            ajoutToolStripMenuItem.Click += ajoutToolStripMenuItem_Click;
            // 
            // modificationToolStripMenuItem
            // 
            modificationToolStripMenuItem.Name = "modificationToolStripMenuItem";
            modificationToolStripMenuItem.Size = new Size(191, 28);
            modificationToolStripMenuItem.Text = "Modification";
            modificationToolStripMenuItem.Click += modificationToolStripMenuItem_Click;
            // 
            // gestionDesForfaitsToolStripMenuItem
            // 
            gestionDesForfaitsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listeToolStripMenuItem3 });
            gestionDesForfaitsToolStripMenuItem.Name = "gestionDesForfaitsToolStripMenuItem";
            gestionDesForfaitsToolStripMenuItem.Size = new Size(175, 27);
            gestionDesForfaitsToolStripMenuItem.Text = "Gestion des Forfaits";
            gestionDesForfaitsToolStripMenuItem.Click += gestionDesForfaitsToolStripMenuItem_Click;
            // 
            // listeToolStripMenuItem3
            // 
            listeToolStripMenuItem3.Name = "listeToolStripMenuItem3";
            listeToolStripMenuItem3.Size = new Size(245, 28);
            listeToolStripMenuItem3.Text = "Liste et Suppression";
            listeToolStripMenuItem3.Click += listeToolStripMenuItem3_Click;
            // 
            // qUITTERToolStripMenuItem
            // 
            qUITTERToolStripMenuItem.Name = "qUITTERToolStripMenuItem";
            qUITTERToolStripMenuItem.Size = new Size(92, 27);
            qUITTERToolStripMenuItem.Text = "QUITTER";
            qUITTERToolStripMenuItem.Click += qUITTERToolStripMenuItem_Click;
            // 
            // panelPrincipal
            // 
            panelPrincipal.BackColor = Color.White;
            panelPrincipal.BackgroundImage = Properties.Resources.logo_cds49;
            panelPrincipal.BackgroundImageLayout = ImageLayout.Zoom;
            panelPrincipal.BorderStyle = BorderStyle.Fixed3D;
            panelPrincipal.Location = new Point(0, 43);
            panelPrincipal.Margin = new Padding(4, 5, 4, 5);
            panelPrincipal.Name = "panelPrincipal";
            panelPrincipal.Size = new Size(1067, 651);
            panelPrincipal.TabIndex = 1;
            // 
            // FormMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1067, 692);
            ControlBox = false;
            Controls.Add(panelPrincipal);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FormMenu";
            Text = "CDS 49 Administration";
            Load += FormMenu_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem gestionDesElèvesToolStripMenuItem;
        private ToolStripMenuItem listeToolStripMenuItem;
        private ToolStripMenuItem inscriptionToolStripMenuItem;
        private ToolStripMenuItem gestionDesConducteursToolStripMenuItem;
        private ToolStripMenuItem listeToolStripMenuItem1;
        private ToolStripMenuItem ajoutToolStripMenuItem;
        private ToolStripMenuItem qUITTERToolStripMenuItem;
        private Panel panelPrincipal;
        private ToolStripMenuItem gestionDesForfaitsToolStripMenuItem;
        private ToolStripMenuItem listeToolStripMenuItem3;
        private ToolStripMenuItem modificationToolStripMenuItem;
    }
}