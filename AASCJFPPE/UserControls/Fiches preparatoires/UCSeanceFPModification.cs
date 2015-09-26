using System;
using AASCJFPPE.DAL.Datas;
using AASCJFPPE.Misc;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

namespace AASCJFPPE.UserControls.Fiche_preparatoires
{
    /// <summary>
    /// UserControl permettant la modification d'une fiche préparatoire
    /// </summary>
    public partial class UCSeanceFPModification : UCSeanceFP
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UCSeanceFPModification"/> class.
        /// </summary>
        public UCSeanceFPModification()
            : base()
        {
            InitializeComponent();

            this.cmbDiscipline.DisplayMember = "Intitule";
            this.cmbDiscipline.ValueMember = "Id";

            this.cmbDiscipline.DataSource = DataRepository.Instance.Discipline.ToList().OrderBy(d => d.Intitule).ToList();

            this.cmbNiveaux.DisplayMember = "Intitule";
            this.cmbNiveaux.ValueMember = "Id";

            this.cmbNiveaux.DataSource = DataRepository.Instance.Niveau.ToList();

            this.cmbEvaluation.DisplayMember = "Intitule";
            this.cmbEvaluation.ValueMember = "Id";

            this.cmbEvaluation.DataSource = DataRepository.Instance.EvaluationEnvisagee.ToList();

            this.InitializeSeanceDatas();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UCSeanceFPModification"/> class.
        /// </summary>
        /// <param name="seance">The seance.</param>
        public UCSeanceFPModification(FichePreparatoire seance)
            : base(seance)
        {
            InitializeComponent();

            this.AddDidactiquePanel(new DidactiqueFP());

            this.cmbDiscipline.DisplayMember = "Intitule";
            this.cmbDiscipline.ValueMember = "Id";

            this.cmbDiscipline.DataSource = DataRepository.Instance.Discipline.ToList().OrderBy(d => d.Intitule).ToList();

            this.cmbNiveaux.DisplayMember = "Intitule";
            this.cmbNiveaux.ValueMember = "Id";

            this.cmbNiveaux.DataSource = DataRepository.Instance.Niveau.ToList();

            this.cmbEvaluation.DisplayMember = "Intitule";
            this.cmbEvaluation.ValueMember = "Id";

            this.cmbEvaluation.DataSource = DataRepository.Instance.EvaluationEnvisagee.ToList();

            this.InitializeSeanceDatas();
        }

        /// <summary>
        /// Initializes the seance datas.
        /// </summary>
        protected override void InitializeSeanceDatas()
        {
            if (this.Seance.Id.HasValue)
            {
                this.nudNumero.Value = this.Seance.NumeroSeance.Value;

                this.txtObjectifs.Text = this.Seance.Objectifs;

                this.cmbDiscipline.Text = DataRepository.Instance.Discipline.SelectById(this.Seance.Discipline)[0].Intitule;

                List<DomaineActivite> das = DataRepository.Instance.DomaineActivite.SelectById(this.Seance.DomaineActivite);
                if (das != null && das.Count > 0)
                {
                    this.cmbDomainActivite.Text = das[0].Intitule;
                }

                this.cmbNiveaux.Text = this.Seance.NiveauIntitule;

                this.txtSequence.Text = this.Seance.Sequence;

                this.txtSeanceTitre.Text = this.Seance.TitreSeance;

                this.txtCompetencesGenerales.Text = this.Seance.CompetencesVisees;

                this.txtCompetencesRequises.Text = this.Seance.CompetencesRequises;

                this.cmbEvaluation.Text = this.Seance.EvaluationEnvisageeIntitule;

                this.txtEvaluationComplements.Text = this.Seance.ComplementEvaluationEnvisagee;

                this.InitializeDidactiques(this.Seance.Didactiques);

                this.txtPointsNegatifs.Text = this.Seance.BilanNegatif;
                this.txtPointsPositifs.Text = this.Seance.BilanPositif;
            }
        }

        /// <summary>
        /// Gets the didactique panel.
        /// </summary>
        /// <returns></returns>
        protected override UCDidactiqueFP GetDidactiquePanel(DidactiqueFP didactique)
        {
            return new UCDidactiqueFPModification(didactique);
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cmbDiscipline control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cmbDiscipline_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbDomainActivite.DisplayMember = "Intitule";
            this.cmbDomainActivite.ValueMember = "Id";
            List<DomaineActivite> das = DataRepository.Instance.DomaineActivite.SelectByDiscipline((long)this.cmbDiscipline.SelectedValue);
            if (das != null && das.Count > 0)
            {
                this.cmbDomainActivite.DataSource = das.OrderBy(da => da.Intitule).ToList();
                this.cmbDomainActivite.Enabled = true;
            }
            else
            {
                this.cmbDomainActivite.DataSource = null;
                this.cmbDomainActivite.Items.Clear();
                this.cmbDomainActivite.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnAjouterDidactique control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnAjouterDidactique_Click(object sender, EventArgs e)
        {
            this.AddDidactiquePanel(new DidactiqueFP());
            this.btnDeleteLastDidactique.Enabled = true;
        }


        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <param name="date">The date.</param>
        public override void Save(DateTime date)
        {
            // Save
            this.Seance.Date = date;
            this.Seance.Discipline = (long?)this.cmbDiscipline.SelectedValue;
            this.Seance.DomaineActivite = (long?)this.cmbDomainActivite.SelectedValue;
            this.Seance.NumeroSeance = (int)this.nudNumero.Value;
            this.Seance.TitreSeance = this.txtSeanceTitre.Text;
            this.Seance.Objectifs = this.txtObjectifs.Text;
            this.Seance.Sequence = this.txtSequence.Text;
            this.Seance.CompetencesVisees = this.txtCompetencesGenerales.Text;
            this.Seance.CompetencesRequises = this.txtCompetencesRequises.Text;
            this.Seance.EvaluationEnvisagee = (long?)this.cmbEvaluation.SelectedValue;
            this.Seance.Niveau = (long?)this.cmbNiveaux.SelectedValue;
            this.Seance.ComplementEvaluationEnvisagee = this.txtEvaluationComplements.Text;
            this.Seance.BilanNegatif = this.txtPointsNegatifs.Text;
            this.Seance.BilanPositif = this.txtPointsPositifs.Text;

            if (this.Seance.Id.HasValue)
            {
                // Update
                DataRepository.Instance.FichePreparatoire.Update(this.Seance);
            }
            else
            {
                // Insert
                this.Seance.Id = DataRepository.Instance.FichePreparatoire.CreateAndGetId(this.Seance.Discipline,
                                                    this.Seance.DomaineActivite,                                
                                                    this.Seance.Niveau,
                                                    this.Seance.Sequence,
                                                    this.Seance.NumeroSeance,
                                                    this.Seance.TitreSeance,
                                                    this.Seance.Date,
                                                    this.Seance.CompetencesVisees,
                                                    this.Seance.CompetencesRequises,
                                                    this.Seance.Objectifs,
                                                    this.Seance.EvaluationEnvisagee,
                                                    this.Seance.ComplementEvaluationEnvisagee,
                                                    this.Seance.BilanPositif,
                                                    this.Seance.BilanNegatif);
            }
            
            // Delete previous links
            DataRepository.Instance.Link_FP_DidactiqueFP.DeleteByFP_id(this.Seance.Id);

            for (int i = this.pnlDidactiques.Controls.Count - 1; i >= 0; i--)
            {
                UCDidactiqueFP ucDidactiqueFP = this.pnlDidactiques.Controls[i] as UCDidactiqueFP;
                if (ucDidactiqueFP != null)
                {
                    long didactiqueId = ucDidactiqueFP.Save();

                    //  Save Link
                    DataRepository.Instance.Link_FP_DidactiqueFP.Create(this.Seance.Id, didactiqueId);
                }
            }
        }

        /// <summary>
        /// Handles the Resize event of the pnlDisciplineEtDomaineActivite control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void pnlDisciplineEtDomaineActivite_Resize(object sender, EventArgs e)
        {
            this.lblDisciplineEtDomaineActivite.Left = (this.pnlDisciplineEtDomaineActivite.Width - this.lblDisciplineEtDomaineActivite.Width) / 2;
            this.cmbDomainActivite.Left = this.pnlDisciplineEtDomaineActivite.Width / 2;
        }

        /// <summary>
        /// Handles the Click event of the btnDeleteLastDidactique control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnDeleteLastDidactique_Click(object sender, EventArgs e)
        {
            if (this.pnlDidactiques.Controls.Count > 1)
            {
                this.pnlDidactiques.Controls.RemoveAt(0);

                if (this.pnlDidactiques.Controls.Count == 1)
                {
                    this.btnDeleteLastDidactique.Enabled = false;
                }
            }
        }
    }
}
