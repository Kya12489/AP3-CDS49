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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
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
            vehiculeToolStripMenuItem = new ToolStripMenuItem();
            listeToolStripMenuItem2 = new ToolStripMenuItem();
            ajouterToolStripMenuItem1 = new ToolStripMenuItem();
            ToolStripMenuItem = new ToolStripMenuItem();
            listeToolStripMenuItem4 = new ToolStripMenuItem();
            ajouterToolStripMenuItem2 = new ToolStripMenuItem();
            quitterToolStripMenuItem1 = new ToolStripMenuItem();
            deconnexionToolStripMenuItem = new ToolStripMenuItem();
            quizToolStripMenuItem = new ToolStripMenuItem();
            listeToolStripMenuItem5 = new ToolStripMenuItem();
            ajouterToolStripMenuItem3 = new ToolStripMenuItem();
            panelPrincipal = new Panel();
            chartProportionForfait = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartInscritEleve = new System.Windows.Forms.DataVisualization.Charting.Chart();
            menuStrip1.SuspendLayout();
            panelPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartProportionForfait).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartInscritEleve).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.AutoSize = false;
            menuStrip1.BackColor = Color.FromArgb(255, 128, 0);
            menuStrip1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.ImeMode = ImeMode.NoControl;
            menuStrip1.Items.AddRange(new ToolStripItem[] { gestionDesElèvesToolStripMenuItem, gestionDesConducteursToolStripMenuItem, gestionDesForfaitsToolStripMenuItem, vehiculeToolStripMenuItem, ToolStripMenuItem, quitterToolStripMenuItem1, deconnexionToolStripMenuItem, quizToolStripMenuItem });
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
            gestionDesElèvesToolStripMenuItem.Size = new Size(59, 23);
            gestionDesElèvesToolStripMenuItem.Text = "Elèves";
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
            gestionDesConducteursToolStripMenuItem.Size = new Size(85, 23);
            gestionDesConducteursToolStripMenuItem.Text = "Moniteurs";
            // 
            // listeToolStripMenuItem1
            // 
            listeToolStripMenuItem1.Name = "listeToolStripMenuItem1";
            listeToolStripMenuItem1.Size = new Size(159, 24);
            listeToolStripMenuItem1.Text = "Liste";
            listeToolStripMenuItem1.Click += listeToolStripMenuItem1_Click;
            // 
            // ajoutToolStripMenuItem
            // 
            ajoutToolStripMenuItem.Name = "ajoutToolStripMenuItem";
            ajoutToolStripMenuItem.Size = new Size(159, 24);
            ajoutToolStripMenuItem.Text = "Ajout";
            ajoutToolStripMenuItem.Click += ajoutToolStripMenuItem_Click;
            // 
            // modificationToolStripMenuItem
            // 
            modificationToolStripMenuItem.Name = "modificationToolStripMenuItem";
            modificationToolStripMenuItem.Size = new Size(159, 24);
            modificationToolStripMenuItem.Text = "Modification";
            modificationToolStripMenuItem.Click += modificationToolStripMenuItem_Click;
            // 
            // gestionDesForfaitsToolStripMenuItem
            // 
            gestionDesForfaitsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listeToolStripMenuItem3, ajouterToolStripMenuItem });
            gestionDesForfaitsToolStripMenuItem.Name = "gestionDesForfaitsToolStripMenuItem";
            gestionDesForfaitsToolStripMenuItem.Size = new Size(68, 23);
            gestionDesForfaitsToolStripMenuItem.Text = "Forfaits";
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
            // vehiculeToolStripMenuItem
            // 
            vehiculeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listeToolStripMenuItem2, ajouterToolStripMenuItem1 });
            vehiculeToolStripMenuItem.Name = "vehiculeToolStripMenuItem";
            vehiculeToolStripMenuItem.Size = new Size(80, 23);
            vehiculeToolStripMenuItem.Text = "Véhicules";
            // 
            // listeToolStripMenuItem2
            // 
            listeToolStripMenuItem2.Name = "listeToolStripMenuItem2";
            listeToolStripMenuItem2.Size = new Size(124, 24);
            listeToolStripMenuItem2.Text = "Liste";
            listeToolStripMenuItem2.Click += listeToolStripMenuItem2_Click;
            // 
            // ajouterToolStripMenuItem1
            // 
            ajouterToolStripMenuItem1.Name = "ajouterToolStripMenuItem1";
            ajouterToolStripMenuItem1.Size = new Size(124, 24);
            ajouterToolStripMenuItem1.Text = "Ajouter";
            ajouterToolStripMenuItem1.Click += ajouterToolStripMenuItem1_Click;
            // 
            // ToolStripMenuItem
            // 
            ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listeToolStripMenuItem4, ajouterToolStripMenuItem2 });
            ToolStripMenuItem.Name = "ToolStripMenuItem";
            ToolStripMenuItem.Size = new Size(58, 23);
            ToolStripMenuItem.Text = "Leçon";
            // 
            // listeToolStripMenuItem4
            // 
            listeToolStripMenuItem4.Name = "listeToolStripMenuItem4";
            listeToolStripMenuItem4.Size = new Size(180, 24);
            listeToolStripMenuItem4.Text = "Liste";
            listeToolStripMenuItem4.Click += listeToolStripMenuItem4_Click;
            // 
            // ajouterToolStripMenuItem2
            // 
            ajouterToolStripMenuItem2.Name = "ajouterToolStripMenuItem2";
            ajouterToolStripMenuItem2.Size = new Size(180, 24);
            ajouterToolStripMenuItem2.Text = "Ajouter";
            ajouterToolStripMenuItem2.Click += ajouterToolStripMenuItem2_Click;
            // 
            // quitterToolStripMenuItem1
            // 
            quitterToolStripMenuItem1.Alignment = ToolStripItemAlignment.Right;
            quitterToolStripMenuItem1.Name = "quitterToolStripMenuItem1";
            quitterToolStripMenuItem1.Size = new Size(66, 23);
            quitterToolStripMenuItem1.Text = "Quitter";
            quitterToolStripMenuItem1.Click += quitterToolStripMenuItem1quitterToolStripMenuItem1_Click;
            // 
            // deconnexionToolStripMenuItem
            // 
            deconnexionToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            deconnexionToolStripMenuItem.Name = "deconnexionToolStripMenuItem";
            deconnexionToolStripMenuItem.Size = new Size(103, 23);
            deconnexionToolStripMenuItem.Text = "Deconnexion";
            deconnexionToolStripMenuItem.Click += quitterToolStripMenuItem1_Click;
            // 
            // quizToolStripMenuItem
            // 
            quizToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listeToolStripMenuItem5, ajouterToolStripMenuItem3 });
            quizToolStripMenuItem.Name = "quizToolStripMenuItem";
            quizToolStripMenuItem.Size = new Size(58, 23);
            quizToolStripMenuItem.Text = "Quizz";
            // 
            // listeToolStripMenuItem5
            // 
            listeToolStripMenuItem5.Name = "listeToolStripMenuItem5";
            listeToolStripMenuItem5.Size = new Size(124, 24);
            listeToolStripMenuItem5.Text = "Liste";
            listeToolStripMenuItem5.Click += listeToolStripMenuItem5_Click;
            // 
            // ajouterToolStripMenuItem3
            // 
            ajouterToolStripMenuItem3.Name = "ajouterToolStripMenuItem3";
            ajouterToolStripMenuItem3.Size = new Size(124, 24);
            ajouterToolStripMenuItem3.Text = "Ajouter";
            ajouterToolStripMenuItem3.Click += ajouterToolStripMenuItem3_Click;
            // 
            // panelPrincipal
            // 
            panelPrincipal.BackColor = Color.White;
            panelPrincipal.BackgroundImage = Properties.Resources.logo_cds49;
            panelPrincipal.BackgroundImageLayout = ImageLayout.Zoom;
            panelPrincipal.BorderStyle = BorderStyle.Fixed3D;
            panelPrincipal.Controls.Add(chartProportionForfait);
            panelPrincipal.Controls.Add(chartInscritEleve);
            panelPrincipal.Location = new Point(0, 24);
            panelPrincipal.Margin = new Padding(4, 4, 4, 4);
            panelPrincipal.Name = "panelPrincipal";
            panelPrincipal.Size = new Size(934, 495);
            panelPrincipal.TabIndex = 1;
            // 
            // chartProportionForfait
            // 
            chartArea1.Name = "ChartArea1";
            chartProportionForfait.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            legend1.Title = "Liste Forfait";
            chartProportionForfait.Legends.Add(legend1);
            chartProportionForfait.Location = new Point(482, 16);
            chartProportionForfait.Name = "chartProportionForfait";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.YValuesPerPoint = 4;
            chartProportionForfait.Series.Add(series1);
            chartProportionForfait.Size = new Size(399, 164);
            chartProportionForfait.TabIndex = 1;
            chartProportionForfait.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "Proportion des différents forfaits choisis";
            chartProportionForfait.Titles.Add(title1);
            // 
            // chartInscritEleve
            // 
            chartArea2.Name = "ChartArea1";
            chartInscritEleve.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            legend2.Title = "nb élèves";
            chartInscritEleve.Legends.Add(legend2);
            chartInscritEleve.Location = new Point(53, 16);
            chartInscritEleve.Name = "chartInscritEleve";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            series2.YValuesPerPoint = 4;
            chartInscritEleve.Series.Add(series2);
            chartInscritEleve.Size = new Size(378, 224);
            chartInscritEleve.TabIndex = 0;
            chartInscritEleve.Text = "chart1";
            title2.Name = "Title1";
            title2.Text = "Nombre d’élèves inscrits par mois sur les 12 derniers mois";
            chartInscritEleve.Titles.Add(title2);
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
            panelPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartProportionForfait).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartInscritEleve).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem gestionDesElèvesToolStripMenuItem;
        private ToolStripMenuItem listeToolStripMenuItem;
        private ToolStripMenuItem inscriptionToolStripMenuItem;
        private ToolStripMenuItem gestionDesConducteursToolStripMenuItem;
        private ToolStripMenuItem listeToolStripMenuItem1;
        private ToolStripMenuItem ajoutToolStripMenuItem;
        private ToolStripMenuItem vehiculeToolStripMenuItem;
        private Panel panelPrincipal;
        private ToolStripMenuItem gestionDesForfaitsToolStripMenuItem;
        private ToolStripMenuItem listeToolStripMenuItem3;
        private ToolStripMenuItem modificationToolStripMenuItem;
        private ToolStripMenuItem ajouterToolStripMenuItem;
        private ToolStripMenuItem ToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartInscritEleve;
        private ToolStripMenuItem deconnexionToolStripMenuItem;
        private ToolStripMenuItem listeToolStripMenuItem2;
        private ToolStripMenuItem ajouterToolStripMenuItem1;
        private ToolStripMenuItem listeToolStripMenuItem4;
        private ToolStripMenuItem ajouterToolStripMenuItem2;
        private ToolStripMenuItem quitterToolStripMenuItem1;
        private ToolStripMenuItem quizToolStripMenuItem;
        private ToolStripMenuItem listeToolStripMenuItem5;
        private ToolStripMenuItem ajouterToolStripMenuItem3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartProportionForfait;
        //private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}