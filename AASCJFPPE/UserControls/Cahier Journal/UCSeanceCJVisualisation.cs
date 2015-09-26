using AASCJFPPE.DAL.Datas;
using System.Collections.Generic;
using System;

namespace AASCJFPPE.UserControls.Cahier_Journal
{
    /// <summary>
    /// UserControl permettant la visualisation d'une séance du Cahier Journal
    /// </summary>
    public partial class UCSeanceCJVisualisation : UCSeanceCJ
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UCSeanceCJVisualisation"/> class.
        /// </summary>
        public UCSeanceCJVisualisation()
            : base()
        {
            InitializeComponent();

            this.InitializeSeanceDatas();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UCSeanceCJVisualisation"/> class.
        /// </summary>
        /// <param name="seance">The seance.</param>
        public UCSeanceCJVisualisation(CahierJournal seance)
            : base(seance)
        {
            InitializeComponent();

            this.InitializeSeanceDatas();
        }

        /// <summary>
        /// Adds the information to newly created didactique panel.
        /// </summary>
        /// <returns></returns>
        protected override UCDidactiqueCJ GetDidactiquePanel(DidactiqueCJ didactique)
        {
            return new UCDidactiqueCJVisualisation(didactique);
        }

        /// <summary>
        /// Initializes the seance datas.
        /// </summary>
        protected override void InitializeSeanceDatas()
        {
            if (this.Seance != null)
            {
                this.lblDataTrancheHoraire.Text = this.Seance.TrancheHoraire;

                this.lblDataNumeroSeance.Text = this.Seance.NumeroSeance.Value.ToString();

                this.lblDataObjectifs.Text = this.Seance.Objectifs;
                this.ResizeObjectifs();

                this.lblDataDiscipline.Text = DataRepository.Instance.Discipline.SelectById(this.Seance.Discipline)[0].Intitule;

                List<DomaineActivite> das = DataRepository.Instance.DomaineActivite.SelectById(this.Seance.DomaineActivite);
                if (das != null && das.Count > 0)
                {
                    this.lblDataDomaineActivite.Text = das[0].Intitule;
                }
                else
                {
                    this.lblDataDomaineActivite.Text = String.Empty;
                }

                this.AddDidactiquePanels(this.Seance.Didactiques);
            }

        }

        /// <summary>
        /// Resizes the objectifs.
        /// </summary>
        private void ResizeObjectifs()
        {
            using (AASCJFPPE.Misc.PrintHelper ph = new Misc.PrintHelper(this.lblDeroulement.CreateGraphics()))
            {
                int height = ph.GetRealHeight(this.lblDataObjectifs.Text, this.lblDataObjectifs.Font, this.lblDataObjectifs.Width);
                if (this.Height < height)
                {
                    this.lblDataObjectifs.Height = height;
                    this.Height = height;
                }
            }
        }

        /// <summary>
        /// Handles the Resize event of the pnlDisciplineEtDomaineActivite control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void pnlDisciplineEtDomaineActivite_Resize(object sender, System.EventArgs e)
        {
            this.lblDisciplineEtDomaineActivite.Left = (this.pnlDisciplineEtDomaineActivite.Width - this.lblDisciplineEtDomaineActivite.Width) / 2;
            this.lblDataDomaineActivite.Left = this.pnlDisciplineEtDomaineActivite.Width / 2;
        }

        /// <summary>
        /// Handles the Resize event of the pnlObjectifs control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void pnlObjectifs_Resize(object sender, EventArgs e)
        {
            this.ResizeObjectifs();
        }
    }
}
