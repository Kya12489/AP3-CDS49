using AP3_AppliC.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AP3_AppliC.view
{
    public partial class FormGestionQuizz : Form
    {
        public FormGestionQuizz()
        {
            InitializeComponent();
        }

        private void FormGestionQuizz_Load(object sender, EventArgs e)
        {
            List<Category> types = Modele.ModeleQuizz.listeTypes();

            cbCategory.Items.Clear();
            cbCategory.Items.Add("Sans catégorie");

            foreach (var type in types)
            {
                cbCategory.Items.Add(type.LibelleCategorie);
            }

            cbCategory.SelectedIndex = 0;
        }
    }
}
