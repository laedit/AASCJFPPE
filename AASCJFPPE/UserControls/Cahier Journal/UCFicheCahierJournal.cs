using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using AASCJFPPE.DAL.Datas;
using AASCJFPPE.Handlers;
using AASCJFPPE.Misc;

namespace AASCJFPPE.UserControls.Cahier_Journal
{
    /// <summary>
    /// Fiche de visualisation/édition du Cahier Journal
    /// </summary>
    public partial class UCFicheCahierJournal : UserControl
    {

        #region Fields

        /// <summary>
        /// Etat de visualisation du cahier journal
        /// </summary>
        private UCCahierJournalVisualisation _visualisation;

        /// <summary>
        /// Etat de modification du cahier journal
        /// </summary>
        private UCCahierJournalModification _modification;

        /// <summary>
        /// Etat visual du composant
        /// </summary>
        private VisualState _visualState;

        /// <summary>
        /// Aide à l'impression
        /// </summary>
        private PrintDocument _printDocument;

        /// <summary>
        /// Index de la séance à imprimer
        /// </summary>
        private Int32 _printedDataIndex;

        #endregion Fields


        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="UCFicheCahierJournal"/> class.
        /// </summary>
        public UCFicheCahierJournal()
        {
            InitializeComponent();

            this._printDocument = new PrintDocument();
            this._printDocument.PrintPage += new PrintPageEventHandler(_printDocument_PrintPage);
        }

        #endregion Constructor


        #region Private methods

        /// <summary>
        /// Changes the button visibility.
        /// </summary>
        private void ChangeActionsVisibility()
        {
            this.btnAjouter.Visible = this._visualState == VisualState.Visualisation;
            this.btnModifier.Visible = this._visualState == VisualState.Visualisation;
            this.btnImprimer.Visible = this._visualState == VisualState.Visualisation;
            this.btnEnregistrer.Visible = this._visualState != VisualState.Visualisation;
            this.dtpSelection.Visible = this._visualState == VisualState.Visualisation;
            this.btnAnnuler.Visible = this._visualState != VisualState.Visualisation;
        }

        /// <summary>
        /// Shows the visualisation.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        private void ShowVisualisation(DateTime dateTime)
        {
            _visualState = VisualState.Visualisation;
            this.ChangeActionsVisibility();

            DeleteCurrentVisualState();

            _visualisation.Seances = DataRepository.Instance.CahierJournal.SelectByDateJour(dateTime);

            this.Controls.Add(_visualisation);
            this.Controls.SetChildIndex(_visualisation, 0);
        }

        /// <summary>
        /// Shows the modification.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        private void ShowModification(DateTime dateTime)
        {
            _visualState = VisualState.Modification;
            this.ChangeActionsVisibility();

            DeleteCurrentVisualState();

            _modification.Seances = DataRepository.Instance.CahierJournal.SelectByDateJour(dateTime);

            this.Controls.Add(_modification);
            this.Controls.SetChildIndex(_modification, 0);
        }

        /// <summary>
        /// Shows the modification.
        /// </summary>
        /// <param name="seances">The seances.</param>
        private void ShowModification(List<CahierJournal> seances)
        {
            _visualState = VisualState.Modification;
            this.ChangeActionsVisibility();

            DeleteCurrentVisualState();

            _modification.Seances = seances;

            this.Controls.Add(_modification);
            this.Controls.SetChildIndex(_modification, 0);
        }

        /// <summary>
        /// Shows the modification.
        /// </summary>
        /// <param name="dayDate">The day date.</param>
        private void ShowCreation(DateTime dayDate)
        {
            _visualState = VisualState.Creation;
            this.ChangeActionsVisibility();

            DeleteCurrentVisualState();

            _modification.Seances = new List<CahierJournal>();
            _modification.SetDate(dayDate);
            this.Controls.Add(_modification);
            this.Controls.SetChildIndex(_modification, 0);
        }

        /// <summary>
        /// Deletes the state of the current visual.
        /// </summary>
        private void DeleteCurrentVisualState()
        {
            if (this.Controls.Count >= 2)
            {
                this.Controls.RemoveAt(0);
            }
        }

        /// <summary>
        /// Shows the last seance or creation.
        /// </summary>
        private void ShowLastSeanceOrCreation()
        {
            List<CahierJournal> cahierJournals = DataRepository.Instance.CahierJournal.ToList();
            if (cahierJournals == null || cahierJournals.Count == 0)
            {
                ShowCreation(DateTime.Now);
            }
            else
            {
                cahierJournals = cahierJournals.OrderBy(cj => cj.DateJour).Reverse().ToList();
                this.dtpSelection.Value = cahierJournals[0].DateJour.Value.Date;
                ShowVisualisation(cahierJournals[0].DateJour.Value.Date);
            }
        }

        /// <summary>
        /// Shows the seance or creation.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        private void ShowSeanceOrCreation(DateTime dateTime)
        {
            List<CahierJournal> cahierJournals = DataRepository.Instance.CahierJournal.SelectByDateJour(dateTime.Date);
            if (cahierJournals == null || cahierJournals.Count == 0)
            {
                ShowCreation(dateTime.Date);
            }
            else
            {
                this.dtpSelection.Value = dateTime.Date;
                ShowVisualisation(dateTime.Date);
            }
        }

        #endregion Private methods


        #region Public methods

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            if (_visualisation != null)
            {
                _visualisation.Dispose();
            }
            _visualisation = new UCCahierJournalVisualisation();
            _visualisation.Dock = DockStyle.Top;
            _visualisation.Left = 0;
            _visualisation.Top = 45;

            if (_modification != null)
            {
                _modification.Dispose();
            }
            _modification = new UCCahierJournalModification();
            _modification.Dock = DockStyle.Top;
            _modification.Left = 0;
            _modification.Top = 45;

            this.ShowLastSeanceOrCreation();
        }

        #endregion  Public methods


        #region Event handlers

        /// <summary>
        /// Handles the Click event of the btnAjouter control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            this.ShowCreation(this.dtpSelection.Value);
        }

        /// <summary>
        /// Handles the Click event of the btnModifier control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnModifier_Click(object sender, EventArgs e)
        {
            this.ShowModification(this._visualisation.Seances);
        }

        /// <summary>
        /// Handles the Click event of the btnImprimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnImprimer_Click(object sender, EventArgs e)
        {
            if (this._visualisation.Seances.Count > 0)
            {
#if !DEBUG
            PrintDialog printDialog = new PrintDialog();
            printDialog.AllowPrintToFile = true;
            printDialog.Document = this._printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
            
#endif
                this._printDocument.Print();
#if !DEBUG
            }
            
#endif
            }
            else
            {
                MessageBox.Show("Aucune séance à imprimer", "Erreur d'impression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnEnregistrer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            // Save
            _modification.Save();

            // Visualize
            this.ShowVisualisation(_modification.dtpDateJour.Value);
        }

        /// <summary>
        /// Handles the PrintPage event of the _printDocument control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Drawing.Printing.PrintPageEventArgs"/> instance containing the event data.</param>
        void _printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // We assumes that there are multiple pages by default
            e.HasMorePages = true;

            // Offset Variables
            Int32 y = 10;

            // Graphics variables
            using (PrintHelper printHelper = new PrintHelper(e.Graphics))
            {
                // Size variables
                Int32 arial10Height = printHelper.GetHeight(PrintHelper.AvailableFont.Arial10);
                Int32 arial8Height = printHelper.GetHeight(PrintHelper.AvailableFont.Arial8);
                Int32 arial10BoldHeight = printHelper.GetHeight(PrintHelper.AvailableFont.Arial10Bold);
                Int32 arial8BoldHeight = printHelper.GetHeight(PrintHelper.AvailableFont.Arial8Bold);

                Int32 spaceheight = arial10Height * 4;
                Int32 spaceMinHeight = arial10Height * 2;

                Int32 leftMargin = 10;
                Int32 rightMargin = -10;

                // Get first seance in order to draw the header
                CahierJournal firstSeance = this._visualisation.Seances.First();

                String headerPeriode = "Période : du " + firstSeance.DateDebut.Value.ToShortDateString() + " au " + firstSeance.DateFin.Value.ToShortDateString();

                printHelper.Print(headerPeriode, PrintHelper.AvailableFont.Arial10Bold, PrintHelper.XPosition.Center, y);

                y += arial10BoldHeight;

                String headerName = AASCJFPPE.Properties.Settings.Default.PEPrenom[0].ToString().ToUpper() + ". " + AASCJFPPE.Properties.Settings.Default.PENom.ToUpper();
                printHelper.Print(headerName, PrintHelper.AvailableFont.Arial10Bold, PrintHelper.XPosition.Right, rightMargin, y);
                y += arial10BoldHeight;

                String headerJour = "Jour : " + firstSeance.DateJour.Value.ToShortDateString();
                printHelper.Print(headerJour, PrintHelper.AvailableFont.Arial10Bold, PrintHelper.XPosition.Center, y);

                // Table print
                printHelper.PrintRectangle(new RectangleF(1, 1, printHelper.PageSize.Width - 3.5f, y + arial10BoldHeight));

                y += spaceheight;

                Int32 pageWidthQuarter = printHelper.PageSize.Width / 4;

                CahierJournal seance = this._visualisation.Seances[_printedDataIndex];

                // Seance header
                String trancheHoraire = "Tranche horaire : ";
                Rectangle trancheHoraireRect = printHelper.Print(trancheHoraire, PrintHelper.AvailableFont.Arial10Bold, leftMargin, y);
                Size textSize = printHelper.GetTextSize(trancheHoraire, PrintHelper.AvailableFont.Arial10Bold);
                trancheHoraire = seance.TrancheHoraire;
                printHelper.Print(trancheHoraire, PrintHelper.AvailableFont.Arial8, trancheHoraireRect.X + textSize.Width, y);

                String discEtDA = "Discipline et domaine(s) d'activité";
                Size discEtDASize = printHelper.GetTextSize(discEtDA, PrintHelper.AvailableFont.Arial10Bold);
                printHelper.Print(discEtDA, PrintHelper.AvailableFont.Arial10Bold, pageWidthQuarter + ((pageWidthQuarter * 2) - discEtDASize.Width) / 2, y);

                String seanceNumber = "Séance n°";
                Size seanceNumberSize = printHelper.GetTextSize(seanceNumber, PrintHelper.AvailableFont.Arial10Bold);
                Rectangle seanceNumberRect = printHelper.Print(seanceNumber, PrintHelper.AvailableFont.Arial10Bold, (pageWidthQuarter * 3) + ((pageWidthQuarter - seanceNumberSize.Width) / 2), y);

                seanceNumber = seance.NumeroSeance.Value.ToString();
                printHelper.Print(seanceNumber, PrintHelper.AvailableFont.Arial8, seanceNumberRect.X + seanceNumberSize.Width, y);

                y += arial10BoldHeight;

                discEtDA = seance.DisciplineIntitule + " - " + seance.DomaineActiviteIntitule;
                printHelper.Print(discEtDA, PrintHelper.AvailableFont.Arial8, PrintHelper.XPosition.Center, y);

                y += spaceMinHeight;

                // Table print
                printHelper.PrintRectangle(new RectangleF(1, y - spaceMinHeight - arial10BoldHeight, pageWidthQuarter, arial10BoldHeight + spaceMinHeight - (spaceMinHeight / 3)));
                printHelper.PrintRectangle(new RectangleF(1, y - spaceMinHeight - arial10BoldHeight, (pageWidthQuarter * 3), arial10BoldHeight + spaceMinHeight - (spaceMinHeight / 3)));
                printHelper.PrintRectangle(new RectangleF(1, y - spaceMinHeight - arial10BoldHeight, printHelper.PageSize.Width - 3.5f, arial10BoldHeight + spaceMinHeight - (spaceMinHeight / 3)));

                String objectifs = "Objectifs : ";
                Rectangle objectifsRect = printHelper.Print(objectifs, PrintHelper.AvailableFont.Arial10Bold, leftMargin, y);
                textSize = printHelper.GetTextSize(objectifs, PrintHelper.AvailableFont.Arial10Bold);
                Int32 availableWidth = printHelper.PageSize.Width - objectifsRect.X - textSize.Width + rightMargin;

                Int32 objectifsHeight = printHelper.GetRealHeight(seance.Objectifs, PrintHelper.AvailableFont.Arial8, availableWidth);
                printHelper.Print(seance.Objectifs, PrintHelper.AvailableFont.Arial8, new Rectangle(objectifsRect.X + textSize.Width, y, availableWidth, objectifsHeight));

                y += objectifsHeight;

                // Table print
                printHelper.PrintRectangle(new RectangleF(1, 1, printHelper.PageSize.Width - 3.5f, y - (arial10BoldHeight / 2)));

                //y += spaceMinHeight;

                // Didactiques
                Int32 page15Width = printHelper.PageSize.Width / 15;
                Int32 phaseApprentissageColumnWidth = 3 * page15Width;
                Int32 realiseColumnWidth = page15Width;
                Int32 ordreColumnWidth = page15Width;
                Int32 deroulementColumnWidth = 4 * page15Width;
                Int32 dispositifSocialColumnWidth = 2 * page15Width;
                Int32 dureeColumnWidth = page15Width;
                Int32 materielLieuColumnWidth = 3 * page15Width;

                Int32 xColumn = 0;

                // Header
                String phaseApprentissage = "Phases d'apprentissage";
                Size phaseApprentissageSize = printHelper.GetTextSize(phaseApprentissage, PrintHelper.AvailableFont.Arial8Bold);
                printHelper.Print(phaseApprentissage, PrintHelper.AvailableFont.Arial8Bold, xColumn + (phaseApprentissageColumnWidth - phaseApprentissageSize.Width) / 2, y);

                xColumn += phaseApprentissageColumnWidth;
                // Print Table
                printHelper.PrintRectangle(new RectangleF(1, y - (arial10BoldHeight / 2) + 1, xColumn, arial10BoldHeight * 1.5f));

                String realise = "Réalisé";
                Size realiseSize = printHelper.GetTextSize(realise, PrintHelper.AvailableFont.Arial8Bold);
                Rectangle realiseRect = printHelper.Print(realise, PrintHelper.AvailableFont.Arial8Bold, xColumn + ((realiseColumnWidth - realiseSize.Width) / 2), y);

                xColumn += realiseColumnWidth;
                // Print Table
                printHelper.PrintRectangle(new RectangleF(1, y - (arial10BoldHeight / 2) + 1, xColumn, arial10BoldHeight * 1.5f));


                String ordre = "Ordre";
                Size ordreSize = printHelper.GetTextSize(ordre, PrintHelper.AvailableFont.Arial8Bold);
                Rectangle ordreRect = printHelper.Print(ordre, PrintHelper.AvailableFont.Arial8Bold, xColumn + ((ordreColumnWidth - ordreSize.Width) / 2), y);

                xColumn += ordreColumnWidth;
                // Print Table
                printHelper.PrintRectangle(new RectangleF(1, y - (arial10BoldHeight / 2) + 1, xColumn, arial10BoldHeight * 1.5f));


                String deroulement = "Déroulement";
                Size deroulementSize = printHelper.GetTextSize(deroulement, PrintHelper.AvailableFont.Arial8Bold);
                Rectangle deroulementRect = printHelper.Print(deroulement, PrintHelper.AvailableFont.Arial8Bold, xColumn + ((deroulementColumnWidth - deroulementSize.Width) / 2), y);

                xColumn += deroulementColumnWidth;
                // Print Table
                printHelper.PrintRectangle(new RectangleF(1, y - (arial10BoldHeight / 2) + 1, xColumn, arial10BoldHeight * 1.5f));


                String dispositifSocial = "Dispositif social";
                Size dispositifSocialSize = printHelper.GetTextSize(dispositifSocial, PrintHelper.AvailableFont.Arial8Bold);
                Rectangle dispositifSocialRect = printHelper.Print(dispositifSocial, PrintHelper.AvailableFont.Arial8Bold, xColumn + ((dispositifSocialColumnWidth - dispositifSocialSize.Width) / 2), y);

                xColumn += dispositifSocialColumnWidth;
                // Print Table
                printHelper.PrintRectangle(new RectangleF(1, y - (arial10BoldHeight / 2) + 1, xColumn, arial10BoldHeight * 1.5f));


                String duree = "Durée";
                Size dureeSize = printHelper.GetTextSize(duree, PrintHelper.AvailableFont.Arial8Bold);
                Rectangle dureeRect = printHelper.Print(duree, PrintHelper.AvailableFont.Arial8Bold, xColumn + ((dureeColumnWidth - dureeSize.Width)) / 2, y);

                xColumn += dureeColumnWidth;
                // Print Table
                printHelper.PrintRectangle(new RectangleF(1, y - (arial10BoldHeight / 2) + 1, xColumn, arial10BoldHeight * 1.5f));


                String materielLieu = "Matériel et/ou Lieu";
                Size materielLieuSize = printHelper.GetTextSize(materielLieu, PrintHelper.AvailableFont.Arial8Bold);
                Rectangle materielLieuRect = printHelper.Print(materielLieu, PrintHelper.AvailableFont.Arial8Bold, xColumn + ((materielLieuColumnWidth - materielLieuSize.Width) / 2), y);

                // Print tables
                printHelper.PrintRectangle(new RectangleF(1, y - (arial10BoldHeight / 2) + 1, printHelper.PageSize.Width - 3.5f, arial10BoldHeight * 1.5f));

                y += arial10BoldHeight;

                // Content
                foreach (DidactiqueCJ didactique in seance.Didactiques.OrderBy(d => d.Ordre))
                {
                    xColumn = 0;
                    float yTable = y;
                    if (seance == this._visualisation.Seances[0])
                    {
                        yTable += 1;
                    }
                    else
                    {
                        yTable += 1.5f;
                    }

                    // Deroulement
                    deroulement = didactique.Deroulement;

                    Int32 deroulementHeight = printHelper.GetRealHeight(deroulement, PrintHelper.AvailableFont.Arial8, deroulementColumnWidth);
                    deroulementRect = printHelper.Print(deroulement, PrintHelper.AvailableFont.Arial8, new Rectangle(phaseApprentissageColumnWidth + realiseColumnWidth + ordreColumnWidth + 2, y, deroulementColumnWidth, deroulementHeight));

                    // Materiel / Lieu
                    materielLieu = didactique.LieuMateriel;

                    Int32 materielLieuHeight = printHelper.GetRealHeight(materielLieu, PrintHelper.AvailableFont.Arial8, materielLieuColumnWidth);
                    materielLieuRect = printHelper.Print(materielLieu, PrintHelper.AvailableFont.Arial8, new Rectangle(phaseApprentissageColumnWidth + realiseColumnWidth + ordreColumnWidth + deroulementColumnWidth + dispositifSocialColumnWidth + dureeColumnWidth + 2, y, materielLieuColumnWidth, materielLieuHeight));

                    // Calculate row height
                    Int32 rowHeight = arial10BoldHeight;
                    if (deroulementHeight > arial10BoldHeight || materielLieuHeight > arial10BoldHeight)
                    {
                        if (deroulementHeight > materielLieuHeight)
                        {
                            rowHeight = deroulementHeight;
                        }
                        else
                        {
                            rowHeight = materielLieuHeight;
                        }
                    }

                    // Phase d'apprentissage
                    phaseApprentissage = didactique.PhaseApprentissageIntitule;
                    phaseApprentissageSize = printHelper.GetTextSize(phaseApprentissage, PrintHelper.AvailableFont.Arial8);
                    printHelper.Print(phaseApprentissage, PrintHelper.AvailableFont.Arial8, (phaseApprentissageColumnWidth - phaseApprentissageSize.Width) / 2, y);

                    xColumn += phaseApprentissageColumnWidth;
                    // Print Table
                    printHelper.PrintRectangle(new RectangleF(1, yTable, xColumn, rowHeight));

                    // Seance realisee
                    realise = (didactique.Realise.Value) ? "X" : String.Empty;
                    realiseSize = printHelper.GetTextSize(realise, PrintHelper.AvailableFont.Arial8);
                    realiseRect = printHelper.Print(realise, PrintHelper.AvailableFont.Arial8, phaseApprentissageColumnWidth + ((realiseColumnWidth - realiseSize.Width) / 2), y);

                    xColumn += realiseColumnWidth;
                    // Print Table
                    printHelper.PrintRectangle(new RectangleF(1, yTable, xColumn, rowHeight));

                    // Ordre
                    ordre = didactique.Ordre.Value.ToString();
                    ordreSize = printHelper.GetTextSize(ordre, PrintHelper.AvailableFont.Arial8);
                    ordreRect = printHelper.Print(ordre, PrintHelper.AvailableFont.Arial8, phaseApprentissageColumnWidth + realiseColumnWidth + ((ordreColumnWidth - ordreSize.Width) / 2), y);

                    xColumn += ordreColumnWidth;
                    // Print Table
                    printHelper.PrintRectangle(new RectangleF(1, yTable, xColumn, rowHeight));

                    xColumn += deroulementColumnWidth;
                    // Print Table
                    printHelper.PrintRectangle(new RectangleF(1, yTable, xColumn, rowHeight));

                    // Dispositif social
                    dispositifSocial = didactique.DispositifSocialIntitule;
                    dispositifSocialSize = printHelper.GetTextSize(dispositifSocial, PrintHelper.AvailableFont.Arial8Bold);
                    dispositifSocialRect = printHelper.Print(dispositifSocial, PrintHelper.AvailableFont.Arial8, phaseApprentissageColumnWidth + realiseColumnWidth + ordreColumnWidth + deroulementColumnWidth + ((dispositifSocialColumnWidth - dispositifSocialSize.Width) / 2), y);

                    xColumn += dispositifSocialColumnWidth;
                    // Print Table
                    printHelper.PrintRectangle(new RectangleF(1, yTable, xColumn, rowHeight));

                    // Duree
                    duree = didactique.Duree.Value.ToString();
                    dureeSize = printHelper.GetTextSize(duree, PrintHelper.AvailableFont.Arial8);
                    dureeRect = printHelper.Print(duree, PrintHelper.AvailableFont.Arial8, phaseApprentissageColumnWidth + realiseColumnWidth + ordreColumnWidth + deroulementColumnWidth + dispositifSocialColumnWidth + ((dureeColumnWidth - dureeSize.Width) / 2), y);

                    xColumn += dureeColumnWidth;
                    // Print Table
                    printHelper.PrintRectangle(new RectangleF(1, yTable, xColumn, rowHeight));

                    xColumn += materielLieuColumnWidth;
                    // Print Table
                    printHelper.PrintRectangle(new RectangleF(1, yTable, printHelper.PageSize.Width - 3.5f, rowHeight));

                    // New row
                    y += rowHeight;
                }

                y += spaceheight;

            } // end using PrintHelper

            _printedDataIndex++;
            if (this._visualisation.Seances.Count == _printedDataIndex)
            {
                _printedDataIndex = 0;
                e.HasMorePages = false;
            }

        } // end event handler _printDocument_PrintPage

        /// <summary>
        /// Handles the Click event of the btnAnnuler control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            if (this._visualState == VisualState.Creation)
            {
                this.ShowLastSeanceOrCreation();
            }
            else
            {
                // Visualize
                this.ShowVisualisation(_modification.dtpDateJour.Value);
            }
        }

        /// <summary>
        /// Handles the ValueChanged event of the dtpSelection control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void dtpSelection_ValueChanged(object sender, EventArgs e)
        {
            this.ShowSeanceOrCreation(this.dtpSelection.Value.Date);
        }

        #endregion Event handlers

        private void pnlActions_Resize(object sender, EventArgs e)
        {
            Int32 buttonSpace = 20;
            Int32 visualisationButtonsWidth = this.btnAjouter.Width + buttonSpace + this.btnModifier.Width + buttonSpace + this.btnImprimer.Width;
            Int32 modificationButtonWidth = this.btnAnnuler.Width + buttonSpace + this.btnEnregistrer.Width;

            this.btnAjouter.Left = (this.pnlActions.Width - visualisationButtonsWidth) / 2;
            this.btnModifier.Left = this.btnAjouter.Left + this.btnAjouter.Width + buttonSpace;
            this.btnImprimer.Left = this.btnModifier.Left + this.btnModifier.Width + buttonSpace;

            this.btnEnregistrer.Left = (this.pnlActions.Width - modificationButtonWidth) / 2;
            this.btnAnnuler.Left = this.btnEnregistrer.Left + this.btnEnregistrer.Width + buttonSpace;

            this.dtpSelection.Left = this.pnlActions.Width - this.dtpSelection.Width - 50;
        }


        internal void InitializeName()
        {
            this._modification.InitializeDatas();
            this._visualisation.InitializeDatas();
        }
    }
}
