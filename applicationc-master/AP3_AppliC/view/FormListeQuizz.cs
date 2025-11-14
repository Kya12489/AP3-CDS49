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
    public partial class FormListeQuizz : Form
    {
        public FormListeQuizz()
        {
            InitializeComponent();
        }

        private void FormListeQuizz_Load(object sender, EventArgs e)
        {
            bsQuizz.DataSource = Modele.ModeleQuizz.listeTousQuestions().Select(static x => new
            {
                x.Idquestion,
                x.Libellequestion,
            }).OrderBy(x => x.Idquestion);


            dgvQuizz.DataSource = bsQuizz;
            dgvQuizz.Columns["Idquestion"].Visible = false;

            dgvQuizz.Columns[1].HeaderText = "Question";

            dgvReponse.Visible = false;
        }
    }
}
