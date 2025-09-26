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
            ajouterToolStripMenuItem = new ToolStripMenuItem();
            quitterToolStripMenuItem = new ToolStripMenuItem();
            panelPrincipal = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(255, 128, 0);
            menuStrip1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.ImeMode = ImeMode.NoControl;
            menuStrip1.Items.AddRange(new ToolStripItem[] { gestionDesElèvesToolStripMenuItem, gestionDesConducteursToolStripMenuItem, gestionDesForfaitsToolStripMenuItem, quitterToolStripMenuItem });
            menuStrip1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.RightToLeft = RightToLeft.No;
            menuStrip1.ShowItemToolTips = true;
            menuStrip1.Size = new Size(934, 27);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // gestionDesElèvesToolStripMenuItem
            // 
            gestionDesElèvesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listeToolStripMenuItem, inscriptionToolStripMenuItem });
            gestionDesElèvesToolStripMenuItem.Name = "gestionDesElèvesToolStripMenuItem";
            gestionDesElèvesToolStripMenuItem.Size = new Size(136, 23);
            gestionDesElèvesToolStripMenuItem.Text = "Gestion des Elèves";
            gestionDesElèvesToolStripMenuItem.TextDirection = ToolStripTextDirection.Horizontal;
            // 
            // listeToolStripMenuItem
            // 
            listeToolStripMenuItem.Name = "listeToolStripMenuItem";
            listeToolStripMenuItem.Size = new Size(264, 24);
            listeToolStripMenuItem.Text = "Liste et Attribution de forfaits";
            listeToolStripMenuItem.Click += listeToolStripMenuItem_Click;
            // 
            // inscriptionToolStripMenuItem
            // 
            inscriptionToolStripMenuItem.Name = "inscriptionToolStripMenuItem";
            inscriptionToolStripMenuItem.Size = new Size(264, 24);
            inscriptionToolStripMenuItem.Text = "Inscription";
            inscriptionToolStripMenuItem.Click += inscriptionToolStripMenuItem_Click;
            // 
            // gestionDesConducteursToolStripMenuItem
            // 
            gestionDesConducteursToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listeToolStripMenuItem1, ajoutToolStripMenuItem, modificationToolStripMenuItem });
            gestionDesConducteursToolStripMenuItem.Name = "gestionDesConducteursToolStripMenuItem";
            gestionDesConducteursToolStripMenuItem.Size = new Size(162, 23);
            gestionDesConducteursToolStripMenuItem.Text = "Gestion des Moniteurs";
            // 
            // listeToolStripMenuItem1
            // 
            listeToolStripMenuItem1.Name = "listeToolStripMenuItem1";
            listeToolStripMenuItem1.Size = new Size(180, 24);
            listeToolStripMenuItem1.Text = "Liste";
            listeToolStripMenuItem1.Click += listeToolStripMenuItem1_Click;
            // 
            // ajoutToolStripMenuItem
            // 
            ajoutToolStripMenuItem.Name = "ajoutToolStripMenuItem";
            ajoutToolStripMenuItem.Size = new Size(180, 24);
            ajoutToolStripMenuItem.Text = "Ajout";
            ajoutToolStripMenuItem.Click += ajoutToolStripMenuItem_Click;
            // 
            // modificationToolStripMenuItem
            // 
            modificationToolStripMenuItem.Name = "modificationToolStripMenuItem";
            modificationToolStripMenuItem.Size = new Size(180, 24);
            modificationToolStripMenuItem.Text = "Modification";
            modificationToolStripMenuItem.Click += modificationToolStripMenuItem_Click;
            // 
            // gestionDesForfaitsToolStripMenuItem
            // 
            gestionDesForfaitsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listeToolStripMenuItem3, ajouterToolStripMenuItem });
            gestionDesForfaitsToolStripMenuItem.Name = "gestionDesForfaitsToolStripMenuItem";
            gestionDesForfaitsToolStripMenuItem.Size = new Size(145, 23);
            gestionDesForfaitsToolStripMenuItem.Text = "Gestion des Forfaits";
            // 
            // listeToolStripMenuItem3
            // 
            listeToolStripMenuItem3.Name = "listeToolStripMenuItem3";
            listeToolStripMenuItem3.Size = new Size(203, 24);
            listeToolStripMenuItem3.Text = "Liste et Suppression";
            listeToolStripMenuItem3.Click += listeToolStripMenuItem3_Click;
            // 
            // ajouterToolStripMenuItem
            // 
            ajouterToolStripMenuItem.Name = "ajouterToolStripMenuItem";
            ajouterToolStripMenuItem.Size = new Size(203, 24);
            ajouterToolStripMenuItem.Text = "Ajouter";
            ajouterToolStripMenuItem.Click += ajouterToolStripMenuItem_Click;
            // 
            // quitterToolStripMenuItem
            // 
            quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            quitterToolStripMenuItem.Size = new Size(66, 23);
            quitterToolStripMenuItem.Text = "Quitter";
            quitterToolStripMenuItem.Click += qUITTERToolStripMenuItem_Click;
            // 
            // panelPrincipal
            // 
            panelPrincipal.BackColor = Color.White;
            panelPrincipal.BackgroundImage = Properties.Resources.logo_cds49;
            panelPrincipal.BackgroundImageLayout = ImageLayout.Zoom;
            panelPrincipal.BorderStyle = BorderStyle.Fixed3D;
            panelPrincipal.Location = new Point(0, 24);
            panelPrincipal.Margin = new Padding(4);
            panelPrincipal.Name = "panelPrincipal";
            panelPrincipal.Size = new Size(934, 495);
            panelPrincipal.TabIndex = 1;
            // 
            // FormMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(934, 519);
            ControlBox = false;
            Controls.Add(panelPrincipal);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 2, 3, 2);
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
        private ToolStripMenuItem quitterToolStripMenuItem;
        private Panel panelPrincipal;
        private ToolStripMenuItem gestionDesForfaitsToolStripMenuItem;
        private ToolStripMenuItem listeToolStripMenuItem3;
        private ToolStripMenuItem modificationToolStripMenuItem;
        private ToolStripMenuItem ajouterToolStripMenuItem;
    }
}