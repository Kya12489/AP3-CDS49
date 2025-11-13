using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using AP3_AppliC.Entities;
using System.Threading.Tasks;

namespace AP3_AppliC
{
    public static class GenererFacturation
    {
        /// <summary>
        /// Génère une facture pour un élève (gère automatiquement les forfaits multiples)
        /// </summary>
        /// <param name="idEleve">ID de l'élève</param>
        public static void GenererFactureEleve(int idEleve)
        {
            try
            {
                // Récupérer l'élève
                Eleve eleve = Modele.ModeleEleve.ObtenirEleve(idEleve);
                if (eleve == null)
                {
                    MessageBox.Show("Élève introuvable.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Récupérer les forfaits de l'élève
                List<Inscrire> lesForfaits = Modele.ModeleEleve.listeForfaitsParEleve(idEleve);

                if (lesForfaits.Count == 0)
                {
                    MessageBox.Show("Cet élève n'a aucun forfait attribué.\nImpossible de générer une facture.",
                        "Aucun forfait", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Si plusieurs forfaits, demander lequel
                Inscrire forfaitChoisi;
                if (lesForfaits.Count > 1)
                {
                    forfaitChoisi = ChoisirForfait(lesForfaits);
                    if (forfaitChoisi == null) return; // Annulé
                }
                else
                {
                    forfaitChoisi = lesForfaits[0];
                }

                // Générer le PDF
                string cheminPdf = CreerPDF(
                    eleve.Nomeleve,
                    eleve.Prenomeleve,
                    eleve.Emaileleve,
                    eleve.Numeroteleleve,
                    forfaitChoisi.IdforfaitNavigation.Libelleforfait,
                    forfaitChoisi.IdforfaitNavigation.Prixforfait ?? 0,  // ← Conversion nullable
                    (int)(forfaitChoisi.IdforfaitNavigation.Nbheures ?? 0),  // ← Conversion nullable
                    forfaitChoisi.Dateinscription.ToDateTime(TimeOnly.MinValue)
                );

                // Demander si on veut ouvrir
                DialogResult resultat = MessageBox.Show(
                    "Facture générée avec succès !\n\nVoulez-vous ouvrir la facture ?",
                    "Succès",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information
                );

                if (resultat == DialogResult.Yes)
                {
                    OuvrirPDF(cheminPdf);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la génération de la facture :\n{ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Permet à l'utilisateur de choisir un forfait parmi plusieurs
        /// </summary>
        private static Inscrire ChoisirForfait(List<Inscrire> forfaits)
        {
            Form formChoix = new Form
            {
                Text = "Sélectionner un forfait",
                Width = 450,
                Height = 200,
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label label = new Label
            {
                Text = "Cet élève possède plusieurs forfaits.\nVeuillez sélectionner celui à facturer :",
                Top = 20,
                Left = 20,
                Width = 400,
                Height = 40
            };

            ComboBox comboBox = new ComboBox
            {
                Top = 70,
                Left = 20,
                Width = 400,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            comboBox.DisplayMember = "Display";
            comboBox.ValueMember = "Forfait";
            comboBox.DataSource = forfaits.Select(f => new
            {
                Display = $"{f.IdforfaitNavigation.Libelleforfait} - {f.Dateinscription:dd/MM/yyyy} - {f.IdforfaitNavigation.Prixforfait:F2}€",
                Forfait = f
            }).ToList();

            Button btnOk = new Button
            {
                Text = "Valider",
                Top = 110,
                Left = 250,
                Width = 80,
                DialogResult = DialogResult.OK
            };

            Button btnAnnuler = new Button
            {
                Text = "Annuler",
                Top = 110,
                Left = 340,
                Width = 80,
                DialogResult = DialogResult.Cancel
            };

            formChoix.Controls.Add(label);
            formChoix.Controls.Add(comboBox);
            formChoix.Controls.Add(btnOk);
            formChoix.Controls.Add(btnAnnuler);
            formChoix.AcceptButton = btnOk;
            formChoix.CancelButton = btnAnnuler;

            if (formChoix.ShowDialog() == DialogResult.OK && comboBox.SelectedItem != null)
            {
                dynamic item = comboBox.SelectedItem;
                return item.Forfait;
            }

            return null;
        }

        /// <summary>
        /// Crée le fichier PDF de la facture
        /// </summary>
        private static string CreerPDF(
            string nomEleve,
            string prenomEleve,
            string emailEleve,
            string telEleve,
            string libelleForfait,
            decimal prixForfait,
            int nbHeures,
            DateTime dateInscription)
        {
            // Créer le dossier Factures
            string dossierFactures = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Factures");
            if (!Directory.Exists(dossierFactures))
            {
                Directory.CreateDirectory(dossierFactures);
            }

            // Numéro de facture unique
            string numeroFacture = $"F{DateTime.Now:yyyyMMdd}-{DateTime.Now:HHmmss}";
            string nomFichier = $"Facture_{numeroFacture}_{nomEleve}_{prenomEleve}.pdf";
            string cheminComplet = Path.Combine(dossierFactures, nomFichier);

            // Créer le document
            Document document = new Document(PageSize.A4, 50, 50, 50, 50);
            PdfWriter.GetInstance(document, new FileStream(cheminComplet, FileMode.Create));
            document.Open();

            // ===== LOGO =====
            string cheminLogo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "logo.png");
            if (File.Exists(cheminLogo))
            {
                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(cheminLogo);
                logo.ScaleToFit(100f, 100f);
                logo.Alignment = Element.ALIGN_CENTER;
                document.Add(logo);
            }
            document.Add(new Paragraph("\n"));

            // ===== TITRE =====
            iTextSharp.text.Font fontTitre = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 22, BaseColor.DARK_GRAY);
            Paragraph titre = new Paragraph("FACTURE", fontTitre);
            titre.Alignment = Element.ALIGN_CENTER;
            document.Add(titre);
            document.Add(new Paragraph("\n"));

            // ===== INFOS AUTO-ÉCOLE =====
            iTextSharp.text.Font fontBold = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11);
            iTextSharp.text.Font fontNormal = FontFactory.GetFont(FontFactory.HELVETICA, 10);

            Paragraph infoAutoEcole = new Paragraph();
            infoAutoEcole.Add(new Chunk("Chevrollier Driving School 49\n", fontBold));
            infoAutoEcole.Add(new Chunk("123 Rue de l'Auto-École\n", fontNormal));
            infoAutoEcole.Add(new Chunk("49000 Angers\n", fontNormal));
            infoAutoEcole.Add(new Chunk("Tél : 02 41 XX XX XX\n", fontNormal));
            infoAutoEcole.Add(new Chunk("Email : contact@cds49.com\n", fontNormal));
            document.Add(infoAutoEcole);
            document.Add(new Paragraph("\n"));

            // ===== NUMÉRO ET DATE =====
            PdfPTable tableInfo = new PdfPTable(2);
            tableInfo.WidthPercentage = 100;

            PdfPCell cellNumero = new PdfPCell(new Phrase($"N° Facture : {numeroFacture}", fontBold));
            cellNumero.Border = iTextSharp.text.Rectangle.NO_BORDER;
            tableInfo.AddCell(cellNumero);

            PdfPCell cellDate = new PdfPCell(new Phrase($"Date : {dateInscription:dd/MM/yyyy}", fontBold));
            cellDate.Border = iTextSharp.text.Rectangle.NO_BORDER;
            cellDate.HorizontalAlignment = Element.ALIGN_RIGHT;
            tableInfo.AddCell(cellDate);

            document.Add(tableInfo);
            document.Add(new Paragraph("\n"));

            // ===== INFOS CLIENT =====
            Paragraph infoClient = new Paragraph();
            infoClient.Add(new Chunk("Facturé à :\n", fontBold));
            infoClient.Add(new Chunk($"{nomEleve} {prenomEleve}\n", fontNormal));
            infoClient.Add(new Chunk($"Email : {emailEleve}\n", fontNormal));
            infoClient.Add(new Chunk($"Tél : {telEleve}\n", fontNormal));
            document.Add(infoClient);
            document.Add(new Paragraph("\n\n"));

            // ===== TABLEAU DES DÉTAILS =====
            PdfPTable tableDetails = new PdfPTable(4);
            tableDetails.WidthPercentage = 100;
            tableDetails.SetWidths(new float[] { 3, 1, 1, 1.5f });

            iTextSharp.text.Font fontHeader = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11, BaseColor.WHITE);
            BaseColor couleurHeader = new BaseColor(41, 128, 185);

            string[] titres = { "Désignation", "Quantité", "Prix Unit.", "Total" };
            foreach (string t in titres)
            {
                PdfPCell cell = new PdfPCell(new Phrase(t, fontHeader));
                cell.BackgroundColor = couleurHeader;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.Padding = 8;
                tableDetails.AddCell(cell);
            }

            // Ligne forfait
            tableDetails.AddCell(new PdfPCell(new Phrase($"{libelleForfait} ({nbHeures}h)", fontNormal)) { Padding = 8 });
            tableDetails.AddCell(new PdfPCell(new Phrase("1", fontNormal)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 8 });
            tableDetails.AddCell(new PdfPCell(new Phrase($"{prixForfait:F2} €", fontNormal)) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 8 });
            tableDetails.AddCell(new PdfPCell(new Phrase($"{prixForfait:F2} €", fontBold)) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 8 });

            document.Add(tableDetails);
            document.Add(new Paragraph("\n"));

            // ===== TOTAUX =====
            PdfPTable tableTotaux = new PdfPTable(2);
            tableTotaux.WidthPercentage = 50;
            tableTotaux.HorizontalAlignment = Element.ALIGN_RIGHT;

            decimal montantTVA = prixForfait * 0.20m;
            decimal totalTTC = prixForfait + montantTVA;

            tableTotaux.AddCell(new PdfPCell(new Phrase("Sous-total HT :", fontNormal)) { Border = iTextSharp.text.Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 5 });
            tableTotaux.AddCell(new PdfPCell(new Phrase($"{prixForfait:F2} €", fontNormal)) { Border = iTextSharp.text.Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 5 });

            tableTotaux.AddCell(new PdfPCell(new Phrase("TVA (20%) :", fontNormal)) { Border = iTextSharp.text.Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 5 });
            tableTotaux.AddCell(new PdfPCell(new Phrase($"{montantTVA:F2} €", fontNormal)) { Border = iTextSharp.text.Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 5 });

            PdfPCell cellLabelTotal = new PdfPCell(new Phrase("Total TTC :", fontBold)) { Border = iTextSharp.text.Rectangle.TOP_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 8, BackgroundColor = new BaseColor(240, 240, 240) };
            PdfPCell cellTotal = new PdfPCell(new Phrase($"{totalTTC:F2} €", fontBold)) { Border = iTextSharp.text.Rectangle.TOP_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 8, BackgroundColor = new BaseColor(240, 240, 240) };
            tableTotaux.AddCell(cellLabelTotal);
            tableTotaux.AddCell(cellTotal);

            document.Add(tableTotaux);
            document.Add(new Paragraph("\n\n"));

            // ===== PIED DE PAGE =====
            iTextSharp.text.Font fontPetit = FontFactory.GetFont(FontFactory.HELVETICA, 8, BaseColor.GRAY);
            Paragraph piedPage = new Paragraph();
            piedPage.Add(new Chunk("Conditions de paiement : Paiement à réception de facture\n", fontPetit));
            piedPage.Add(new Chunk("Moyens de paiement acceptés : Chèque, Virement bancaire, Espèces\n", fontPetit));
            piedPage.Add(new Chunk("\nMerci de votre confiance !", fontPetit));
            piedPage.Alignment = Element.ALIGN_CENTER;
            document.Add(piedPage);

            document.Close();

            return cheminComplet;
        }

        /// <summary>
        /// Ouvre le PDF avec le lecteur par défaut
        /// </summary>
        private static void OuvrirPDF(string cheminPdf)
        {
            if (File.Exists(cheminPdf))
            {
                Process.Start(new ProcessStartInfo(cheminPdf) { UseShellExecute = true });
            }
        }
    }
}
