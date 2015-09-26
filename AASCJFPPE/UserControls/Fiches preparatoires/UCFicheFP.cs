using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using AASCJFPPE.DAL.Datas;
using AASCJFPPE.Handlers;
using AASCJFPPE.Misc;

namespace AASCJFPPE.UserControls.Fiche_preparatoires
{
    /// <summary>
    /// Fiche de visualisation/édition d'une fiche préparatoire
    /// </summary>
    public partial class UCFicheFP : UserControl
    {

        #region Fields

        /// <summary>
        /// Etat de visualisation de la fiche préparatoire
        /// </summary>
        private UCFichePreparatoireVisualisation _visualisation;

        /// <summary>
        /// Etat de modification de la fiche préparatoire
        /// </summary>
        private UCFichePreparatoireModification _modification;

        /// <summary>
        /// Etat visual du composant
        /// </summary>
        private VisualState _visualState;

        /// <summary>
        /// Aide à l'impression
        /// </summary>
        private PrintDocument _printDocument;

        /// <summary>
        /// Index de la seance à imprimer
        /// </summary>
        private Int32 _printDataIndex = 0;

        /// <summary>
        /// Séance en cours d'impression
        /// </summary>
        private FichePreparatoire _seancePrinted;

        /// <summary>
        /// Didactiques de la séance en cours d'impression
        /// </summary>
        private List<DidactiqueFP> _didactiquesPrinted;

        #endregion Fields


        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="UCFicheFP"/> class.
        /// </summary>
        public UCFicheFP()
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

            _visualisation.Seances = DataRepository.Instance.FichePreparatoire.SelectByDate(dateTime);

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

            _modification.Seances = DataRepository.Instance.FichePreparatoire.SelectByDate(dateTime);

            this.Controls.Add(_modification);
            this.Controls.SetChildIndex(_modification, 0);
        }

        /// <summary>
        /// Shows the modification.
        /// </summary>
        /// <param name="seances">The seances.</param>
        private void ShowModification(List<FichePreparatoire> seances)
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

            _modification.Seances = new List<FichePreparatoire>();
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
            List<FichePreparatoire> fichePreparatoires = DataRepository.Instance.FichePreparatoire.ToList();
            if (fichePreparatoires == null || fichePreparatoires.Count == 0)
            {
                ShowCreation(DateTime.Now);
            }
            else
            {
                fichePreparatoires = fichePreparatoires.OrderBy(cj => cj.Date).Reverse().ToList();
                this.dtpSelection.Value = fichePreparatoires[0].Date.Value.Date;
                ShowVisualisation(fichePreparatoires[0].Date.Value.Date);
            }
        }

        /// <summary>
        /// Shows the seance or creation.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        private void ShowSeanceOrCreation(DateTime dateTime)
        {
            List<FichePreparatoire> fichePreparatoires = DataRepository.Instance.FichePreparatoire.SelectByDate(dateTime.Date);
            if (fichePreparatoires == null || fichePreparatoires.Count == 0)
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
            _visualisation = new UCFichePreparatoireVisualisation();
            _visualisation.Dock = DockStyle.Top;
            _visualisation.Left = 0;
            _visualisation.Top = 45;

            if (_modification != null)
            {
                _modification.Dispose();
            }
            _modification = new UCFichePreparatoireModification();
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
            this.ShowVisualisation(_modification.dtpDate.Value);
        }

        /// <summary>
        /// Prints the title to the right.
        /// </summary>
        /// <param name="printHelper">The print helper.</param>
        /// <param name="title">The title.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        private Int32 PrintTitleRight(PrintHelper printHelper, String title, Int32 y)
        {
            Rectangle result = printHelper.PrintTitleRight(title, y);
            if (result == Rectangle.Empty)
            {
                y = -1;
            }
            else
            {
                y += printHelper.Arial10BoldHeight;
            }
            return y;
        }

        /// <summary>
        /// Prints the title left.
        /// </summary>
        /// <param name="printHelper">The print helper.</param>
        /// <param name="title">The title.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        private Int32 PrintTitleLeft(PrintHelper printHelper, String title, Int32 y)
        {
            Rectangle result = printHelper.PrintTitle(title, y);
            if (result == Rectangle.Empty)
            {
                y = -1;
            }
            else
            {
                y += printHelper.Arial10BoldHeight;
            }
            return y;
        }

        /// <summary>
        /// Prints the content of the title.
        /// </summary>
        /// <param name="printHelper">The print helper.</param>
        /// <param name="content">The content.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        private Int32 PrintTitleContent(PrintHelper printHelper, String content, Int32 y)
        {
            Rectangle lastPrintRectangle = printHelper.PrintContent(content, y);
            if (lastPrintRectangle == Rectangle.Empty)
            {
                y = -1;
            }
            else
            {
                y += lastPrintRectangle.Height + printHelper.Arial10BoldHeight;
            }
            return y;
        }

        /// <summary>
        /// Prints the title and content left.
        /// </summary>
        /// <param name="printHelper">The print helper.</param>
        /// <param name="title">The title.</param>
        /// <param name="content">The content.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        private Boolean PrintTitleAndContentLeft(PrintHelper printHelper, String title, String content, ref Int32 y)
        {
            y = PrintTitleLeft(printHelper, title, y);
            if (y != -1)
                y = PrintTitleContent(printHelper, content, y);
            if (y == -1)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Clones the didactique FP.
        /// </summary>
        /// <param name="didactiqueFP">The didactique FP.</param>
        /// <returns></returns>
        private static DidactiqueFP CloneDidactiqueFP(DidactiqueFP didactiqueFP)
        {
            DidactiqueFP newDidactique = new DidactiqueFP();
            newDidactique.Conditions = didactiqueFP.Conditions;
            newDidactique.DispositifSocial = didactiqueFP.DispositifSocial;
            newDidactique.Duree = didactiqueFP.Duree;
            newDidactique.LieuMateriel = didactiqueFP.LieuMateriel.Clone().ToString();
            newDidactique.Ordre = didactiqueFP.Ordre;
            newDidactique.Performances = didactiqueFP.Performances.Clone().ToString();

            return didactiqueFP;
        }

        /// <summary>
        /// Handles the PrintPage event of the _printDocument control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Drawing.Printing.PrintPageEventArgs"/> instance containing the event data.</param>
        private void _printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // By default there is multiple pages
            e.HasMorePages = true;

            // Graphics variables
            using (PrintHelper printHelper = new PrintHelper(e.Graphics))
            {
                // Offset variables
                Int32 y = printHelper.Margin, rightY = printHelper.Margin;

                // Size variables
                Int32 spaceheight = printHelper.Arial10Height * 4;
                Int32 spaceMinHeight = printHelper.Arial10Height * 2;

                //Int32 leftMargin = 10;

                //Int32 pageWidthQuarter = printHelper.PageSize.Width / 4;

                //Rectangle lastPrintRectangle;

                if (_seancePrinted == null)
                {
                    _seancePrinted = (FichePreparatoire)this._visualisation.Seances[_printDataIndex].Clone();
                }

                #region 1) Titres à droite

                // Niveau(x)
                if (_seancePrinted.Niveau.HasValue)
                {
                    rightY = PrintTitleRight(printHelper, "Niveau : " + _seancePrinted.NiveauIntitule, printHelper.Margin);
                    _seancePrinted.Niveau = null;
                    // Offset Variables
                    y = rightY;
                }

                // Numéro de séance
                if (_seancePrinted.NumeroSeance.HasValue)
                {
                    rightY = PrintTitleRight(printHelper, "Séance n°" + _seancePrinted.NumeroSeance.Value.ToString(), rightY);
                    _seancePrinted.NumeroSeance = null;
                }

                // Date
                if (_seancePrinted.Date.HasValue)
                {
                    PrintTitleRight(printHelper, "Date : " + _seancePrinted.Date.Value.ToShortDateString(), rightY);
                    _seancePrinted.Date = null;
                }
                #endregion 1) Titres à droite

                #region 2) Titres à gauche
                // Discipline et domaine d'activité
                if (_seancePrinted.Discipline.HasValue)
                {
                    String header = "Discipline et domaine d'activité : " + _seancePrinted.DisciplineIntitule;
                    if (!String.IsNullOrEmpty(_seancePrinted.DomaineActiviteIntitule))
                    {
                        header += " et " + _seancePrinted.DomaineActiviteIntitule;
                    }

                    y = PrintTitleLeft(printHelper, header, y);
                    if (y == -1)
                    {
                        return;
                    }
                    y += printHelper.Arial10BoldHeight;
                    _seancePrinted.Discipline = null;
                }

                // Séquence
                if (_seancePrinted.Sequence != null)
                {
                    y = PrintTitleLeft(printHelper, "Séquence : ", y);
                    if (y != -1)
                        y = PrintTitleContent(printHelper, _seancePrinted.Sequence, y);
                    if (y == -1)
                    {
                        return;
                    }
                    _seancePrinted.Sequence = null;
                }

                // Titre séance
                if (_seancePrinted.TitreSeance != null)
                {
                    y = PrintTitleLeft(printHelper, "Titre séance : ", y);
                    if (y != -1)
                        y = PrintTitleContent(printHelper, _seancePrinted.TitreSeance, y);
                    if (y == -1)
                    {
                        return;
                    }
                    _seancePrinted.TitreSeance = null;
                }

                // Compétences générales
                if (_seancePrinted.CompetencesVisees != null)
                {
                    y = PrintTitleLeft(printHelper, "Compétences générales visées (BO) : ", y);
                    if (y != -1)
                        y = PrintTitleContent(printHelper, _seancePrinted.CompetencesVisees, y);
                    if (y == -1)
                    {
                        return;
                    }
                    _seancePrinted.CompetencesVisees = null;
                }

                // Objectifs
                if (_seancePrinted.Objectifs != null)
                {
                    y = PrintTitleLeft(printHelper, "Objectif(s) spécifique(s) de séance : ", y);
                    if (y != -1)
                        y = PrintTitleContent(printHelper, _seancePrinted.Objectifs, y);
                    if (y == -1)
                    {
                        return;
                    }
                    _seancePrinted.Objectifs = null;
                }

                // Compétences requises
                if (_seancePrinted.CompetencesRequises != null)
                {
                    y = PrintTitleLeft(printHelper, "Compétences requises : ", y);
                    if (y != -1)
                        y = PrintTitleContent(printHelper, _seancePrinted.CompetencesRequises, y);
                    if (y == -1)
                    {
                        return;
                    }
                    _seancePrinted.CompetencesRequises = null;
                }

                // Evaluation envisagée
                if (_seancePrinted.EvaluationEnvisagee.HasValue)
                {
                    y = PrintTitleLeft(printHelper, "Evaluation envisagée : ", y);
                    if (y != -1)
                        y = PrintTitleContent(printHelper, _seancePrinted.EvaluationEnvisageeIntitule + "\n" + _seancePrinted.ComplementEvaluationEnvisagee, y);
                    if (y == -1)
                    {
                        return;
                    }
                    _seancePrinted.EvaluationEnvisagee = null;
                    y += spaceMinHeight;
                }
                #endregion 2) Titres à gauche

                #region 3) Didactiques

                if (_didactiquesPrinted == null)
                {
                    _didactiquesPrinted = _seancePrinted.Didactiques.ConvertAll<DidactiqueFP>(new Converter<DidactiqueFP, DidactiqueFP>(CloneDidactiqueFP));
                }

                if (_didactiquesPrinted.Count > 0)
                {
                    Int32 margin = 10;
                    Int32 page15Width = (printHelper.PageSize.Width - (2 * margin)) / 15;
                    Int32 conditionsColumnWidth = 4 * page15Width;
                    Int32 performancesColumnWidth = 5 * page15Width;
                    Int32 dispositifSocialColumnWidth = 2 * page15Width;
                    Int32 dureeColumnWidth = page15Width;
                    Int32 materielLieuColumnWidth = 3 * page15Width;
                    Int32 xColumn = margin;

                    // Header
                    // Bordure
                    Int32 headerY = y - (printHelper.Arial10BoldHeight / 2) + 1;
                    float headerHeight = printHelper.Arial10BoldHeight * 2.5f;
                    printHelper.PrintRectangle(new RectangleF(margin, headerY, printHelper.PageSize.Width - (2 * margin), headerHeight));

                    String conditions = "Conditions proposées par " + Environment.NewLine + "le professeur des écoles";
                    Size conditionsSize = printHelper.GetTextSize(conditions, PrintHelper.AvailableFont.Arial8Bold);
                    printHelper.Print(conditions, PrintHelper.AvailableFont.Arial8Bold, xColumn + (conditionsColumnWidth - conditionsSize.Width) / 2, y);

                    xColumn += conditionsColumnWidth;
                    printHelper.PrintVerticalLine(xColumn, headerY, headerHeight);

                    int ytemp = y + (printHelper.Arial10BoldHeight / 2);

                    String performances = "Performances attendues des élèves";
                    Size performancesSize = printHelper.GetTextSize(performances, PrintHelper.AvailableFont.Arial8Bold);
                    Rectangle performancesRect = printHelper.Print(performances, PrintHelper.AvailableFont.Arial8Bold, xColumn + ((performancesColumnWidth - performancesSize.Width) / 2), ytemp);

                    xColumn += performancesColumnWidth;
                    printHelper.PrintVerticalLine(xColumn, headerY, headerHeight);


                    String dispositifSocial = "Dispositif social";
                    Size dispositifSocialSize = printHelper.GetTextSize(dispositifSocial, PrintHelper.AvailableFont.Arial8Bold);
                    Rectangle dispositifSocialRect = printHelper.Print(dispositifSocial, PrintHelper.AvailableFont.Arial8Bold, xColumn + ((dispositifSocialColumnWidth - dispositifSocialSize.Width) / 2), ytemp);

                    xColumn += dispositifSocialColumnWidth;
                    printHelper.PrintVerticalLine(xColumn, headerY, headerHeight);


                    String duree = "Durée";
                    Size dureeSize = printHelper.GetTextSize(duree, PrintHelper.AvailableFont.Arial8Bold);
                    Rectangle dureeRect = printHelper.Print(duree, PrintHelper.AvailableFont.Arial8Bold, xColumn + ((dureeColumnWidth - dureeSize.Width)) / 2, ytemp);

                    xColumn += dureeColumnWidth;
                    printHelper.PrintVerticalLine(xColumn, headerY, headerHeight);


                    String materielLieu = "Matériel et/ou Lieu";
                    Size materielLieuSize = printHelper.GetTextSize(materielLieu, PrintHelper.AvailableFont.Arial8Bold);
                    Rectangle materielLieuRect = printHelper.Print(materielLieu, PrintHelper.AvailableFont.Arial8Bold, xColumn + ((materielLieuColumnWidth - materielLieuSize.Width) / 2), ytemp);

                    y += printHelper.Arial10BoldHeight * 2 + 1;

                    // Content
                    foreach (DidactiqueFP didactique in _didactiquesPrinted.ConvertAll<DidactiqueFP>(new Converter<DidactiqueFP, DidactiqueFP>(CloneDidactiqueFP)))
                    {
                        xColumn = margin;

                        // Performances
                        performances = didactique.Performances;

                        Int32 performancesHeight = printHelper.GetRealHeight(performances, PrintHelper.AvailableFont.Arial8, performancesColumnWidth);

                        // Materiel / Lieu
                        materielLieu = didactique.LieuMateriel;

                        Int32 materielLieuHeight = printHelper.GetRealHeight(materielLieu, PrintHelper.AvailableFont.Arial8, materielLieuColumnWidth);

                        // Calculate row height
                        Int32 rowHeight = printHelper.Arial10BoldHeight;
                        if (performancesHeight > printHelper.Arial10BoldHeight || materielLieuHeight > printHelper.Arial10BoldHeight)
                        {
                            if (performancesHeight > materielLieuHeight)
                            {
                                rowHeight = performancesHeight;
                            }
                            else
                            {
                                rowHeight = materielLieuHeight;
                            }
                        }

                        if (printHelper.PageSize.Height < y + rowHeight + printHelper.Margin)
                        {
                            return;
                        }

                        // Bordure
                        printHelper.PrintRectangle(new RectangleF(margin, y, printHelper.PageSize.Width - (2 * margin), rowHeight));

                        // Conditions
                        conditions = didactique.Ordre + " - " + didactique.ConditionsIntitule;
                        conditionsSize = printHelper.GetTextSize(conditions, PrintHelper.AvailableFont.Arial8);
                        printHelper.Print(conditions, PrintHelper.AvailableFont.Arial8, xColumn + (conditionsColumnWidth - conditionsSize.Width) / 2, y);

                        xColumn += conditionsColumnWidth;
                        printHelper.PrintVerticalLine(xColumn, y, rowHeight);

                        // Performances
                        performancesRect = printHelper.Print(performances, PrintHelper.AvailableFont.Arial8, new Rectangle(xColumn + 2, y, performancesColumnWidth, performancesHeight));
                        xColumn += performancesColumnWidth;
                        printHelper.PrintVerticalLine(xColumn, y, rowHeight);

                        // Dispositif social
                        dispositifSocial = didactique.DispositifSocialIntitule;
                        dispositifSocialSize = printHelper.GetTextSize(dispositifSocial, PrintHelper.AvailableFont.Arial8Bold);
                        dispositifSocialRect = printHelper.Print(dispositifSocial, PrintHelper.AvailableFont.Arial8, xColumn + ((dispositifSocialColumnWidth - dispositifSocialSize.Width) / 2), y);

                        xColumn += dispositifSocialColumnWidth;
                        printHelper.PrintVerticalLine(xColumn, y, rowHeight);

                        // Duree
                        duree = didactique.Duree.Value.ToString();
                        dureeSize = printHelper.GetTextSize(duree, PrintHelper.AvailableFont.Arial8);
                        dureeRect = printHelper.Print(duree, PrintHelper.AvailableFont.Arial8, xColumn + ((dureeColumnWidth - dureeSize.Width) / 2), y);

                        xColumn += dureeColumnWidth;
                        printHelper.PrintVerticalLine(xColumn, y, rowHeight);

                        // Matériel / Lieu
                        materielLieuRect = printHelper.Print(materielLieu, PrintHelper.AvailableFont.Arial8, new Rectangle(xColumn + 2, y, materielLieuColumnWidth, materielLieuHeight));


                        _didactiquesPrinted.Remove(didactique);
                        // New row
                        y += rowHeight;
                    }

                    _didactiquesPrinted.Clear();
                    y += spaceMinHeight;

                }

                #endregion Didactiques

                #region 4) Bilans

                // Bilan positif
                if (_seancePrinted.BilanPositif != null)
                {
                    y = PrintTitleLeft(printHelper, "Bilan positif :", y);
                    if (y != -1)
                        y = PrintTitleContent(printHelper, _seancePrinted.BilanPositif, y);
                    if (y == -1)
                    {
                        return;
                    }
                    _seancePrinted.BilanPositif = null;
                }
                // Bilan négatif
                if (_seancePrinted.BilanNegatif != null)
                {
                    y = PrintTitleLeft(printHelper, "Bilan négatif :", y);
                    if (y != -1)
                        y = PrintTitleContent(printHelper, _seancePrinted.BilanNegatif, y);
                    if (y == -1)
                    {
                        return;
                    }
                    _seancePrinted.BilanNegatif = null;
                }

                #endregion 4) Bilans
            } // end using PrintHelper


            _printDataIndex++;
            if (this._visualisation.Seances.Count == _printDataIndex)
            {
                _printDataIndex = 0;
                e.HasMorePages = false;
            }

            _seancePrinted = null;
            _didactiquesPrinted = null;

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
                this.ShowVisualisation(_modification.dtpDate.Value);
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
