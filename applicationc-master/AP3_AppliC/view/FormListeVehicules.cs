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
    public partial class FormListeVehicules : Form
    {
        public FormListeVehicules()
        {
            InitializeComponent();
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormListeVehicules_Load(object sender, EventArgs e)
        {
            bsVehicules.DataSource = Modele.ModeleVehicule.listeVehicules().Select(static x => new
            {
                x.Idvehicule,
                x.Nbpassagers,
                x.Immatriculation,
                x.Designation,
                x.Manuel
            }).OrderBy(x => x.Idvehicule);

            dgvVehicules.DataSource = bsVehicules;

        }
    }
}
