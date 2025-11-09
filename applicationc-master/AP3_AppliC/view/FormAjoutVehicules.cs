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
    public partial class FormAjoutVehicules : Form
    {
        public FormAjoutVehicules()
        {
            InitializeComponent();

            cbType.Items.Add("Manuel");
            cbType.Items.Add("Automatique");
            cbType.SelectedIndex = 0;
        }

        private void btAjouter_Click(object sender, EventArgs e)
        {
            int? nbPassagers = null;  // Nullable car optionnel

            // Si le champ n'est pas vide essaie de le convertir
            if (!string.IsNullOrWhiteSpace(tbNbPassagers.Text))
            {
                if (int.TryParse(tbNbPassagers.Text, out int valeur))
                {
                    nbPassagers = valeur;  // Conversion réussie
                }
                else
                {
                    MessageBox.Show("Le nombre de passagers doit être un nombre entier valide.");
                    return;  // Arrête l'exécution si erreur
                }
            }
            #region immatriculation
            string immatriculation = tbImmatriculation.Text.Trim().ToUpper();

            if (string.IsNullOrWhiteSpace(immatriculation))
            {
                MessageBox.Show("L'immatriculation est obligatoire.",
                    "Champ requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbImmatriculation.Focus();
                return;
            }

            // Vérifier la longueur (doit être 9 caractères : AB-123-CD)
            if (immatriculation.Length != 9)
            {
                MessageBox.Show("L'immatriculation est incomplète.\nFormat attendu : AB-123-CD (9 caractères)",
                    "Format incomplet", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbImmatriculation.Focus();
                return;
            }

            // Vérifier le format avec Regex
            if (!System.Text.RegularExpressions.Regex.IsMatch(immatriculation, @"^[A-Z]{2}-\d{3}-[A-Z]{2}$"))
            {
                MessageBox.Show("Format d'immatriculation invalide.\nFormat attendu : AB-123-CD",
                    "Format incorrect", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbImmatriculation.Focus();
                return;
            }

            // Vérifier si l'immatriculation existe déjà
            if (Modele.ModeleVehicule.ImmatriculationExiste(immatriculation))
            {
                MessageBox.Show($"L'immatriculation '{immatriculation}' existe déjà !",
                    "Doublon", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbImmatriculation.Focus();
                return;
            }
            #endregion
            string designation = string.IsNullOrWhiteSpace(tbDesignation.Text) ? null : tbDesignation.Text;
            string mode = cbType.SelectedItem.ToString();

            bool ajout = Modele.ModeleVehicule.AjoutVehicule(nbPassagers, immatriculation, designation, mode);

            if (ajout)
            {
                MessageBox.Show("Véhicule ajoutée");
                tbImmatriculation.Clear(); //remet à zéro l'immatriculation
            }
            else
            {
                MessageBox.Show("Erreur lors de l'ajout");
            }
        }

        private void tbImmatriculation_TextChanged(object sender, EventArgs e)
        {
            string immatriculation = tbImmatriculation.Text.Trim();

            // Ne vérifier que si le champ n'est pas vide
            if (!string.IsNullOrWhiteSpace(immatriculation))
            {
                bool existe = Modele.ModeleVehicule.ImmatriculationExiste(immatriculation);

                if (existe)
                {
                    MessageBox.Show($"L'immatriculation '{immatriculation}' existe déjà !",
                        "Doublon", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    tbImmatriculation.Clear();  // Vider automatiquement
                    tbImmatriculation.Focus();  // Remettre le focus sur le champ
                }
            }
        }

        private void tbImmatriculation_KeyPress(object sender, KeyPressEventArgs e)
        {

            #region sans mettre les tirets
            /*
            string texteActuel = tbImmatriculation.Text;
            int position = tbImmatriculation.SelectionStart;

            // Autoriser Backspace et Delete
            if (e.KeyChar == (char)Keys.Back)
            {
                return;
            }

            // Supprimer les tirets pour compter les vrais caractères
            string sanstirets = texteActuel.Replace("-", "");

            // Limiter à 7 caractères (2 lettres + 3 chiffres + 2 lettres)
            if (sanstirets.Length >= 7)
            {
                e.Handled = true;
                return;
            }

            // Position 0-1 : Lettres uniquement (AB)
            if (sanstirets.Length < 2)
            {
                if (!char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                    return;
                }
                e.KeyChar = char.ToUpper(e.KeyChar);  // Forcer majuscule
            }
            // Position 2-4 : Chiffres uniquement (123)
            else if (sanstirets.Length >= 2 && sanstirets.Length < 5)
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                    return;
                }
            }
            // Position 5-6 : Lettres uniquement (CD)
            else if (sanstirets.Length >= 5 && sanstirets.Length < 7)
            {
                if (!char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                    return;
                }
                e.KeyChar = char.ToUpper(e.KeyChar);  // Forcer majuscule
            }*/
            #endregion

            string texteActuel = tbImmatriculation.Text;
            int position = tbImmatriculation.SelectionStart;
            int selectionLength = tbImmatriculation.SelectionLength;

            // Autoriser Backspace
            if (e.KeyChar == (char)Keys.Back)
            {
                return;
            }

            // RÈGLE : On peut taper à la fin OU remplacer une sélection
            if (position < texteActuel.Length && selectionLength == 0)
            {
                // Insertion au milieu interdite
                e.Handled = true;
                return;
            }

            // Si on remplace (selectionLength > 0), vérifier qu'on ne dépasse pas 9 caractères
            int nouvelleLongueur = texteActuel.Length - selectionLength + 1;
            if (nouvelleLongueur > 9)
            {
                e.Handled = true;
                return;
            }

            // Position 0-1 : Lettres uniquement (AB)
            if (position == 0 || position == 1)
            {
                if (!char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                    return;
                }
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
            // Position 2 : Tiret obligatoire (-)
            else if (position == 2)
            {
                if (e.KeyChar != '-')
                {
                    e.Handled = true;
                    return;
                }
            }
            // Position 3-5 : Chiffres uniquement (123)
            else if (position == 3 || position == 4 || position == 5)
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                    return;
                }
            }
            // Position 6 : Tiret obligatoire (-)
            else if (position == 6)
            {
                if (e.KeyChar != '-')
                {
                    e.Handled = true;
                    return;
                }
            }
            // Position 7-8 : Lettres uniquement (CD)
            else if (position == 7 || position == 8)
            {
                if (!char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                    return;
                }
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }
    }
}
