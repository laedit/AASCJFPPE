using AASCJFPPE.DAL.Datas;
using System.Collections.Generic;
using System.Drawing;

namespace AASCJFPPE.UserControls.Fiche_preparatoires
{
    /// <summary>
    /// UserControl permettant la visualisation d'une Didactique d'une Fiche Préparatoire
    /// </summary>
    public partial class UCDidactiqueFPVisualisation : UCDidactiqueFP
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UCDidactiqueFPVisualisation"/> class.
        /// </summary>
        public UCDidactiqueFPVisualisation()
            : base()
        {
            InitializeComponent();

            this.InitializeData();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UCDidactiqueFPVisualisation"/> class.
        /// </summary>
        /// <param name="didactique">The didactique.</param>
        public UCDidactiqueFPVisualisation(DidactiqueFP didactique)
            : base(didactique)
        {
            InitializeComponent();

            this.InitializeData();
        }


        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitializeData()
        {
            if (this.Didactique != null)
            {
                List<DispositifSocial> dss = DataRepository.Instance.DispositifSocial.SelectById(this.Didactique.DispositifSocial);

                if (dss != null && dss.Count > 0)
                {
                    this.lblDispositifSocial.Text = dss[0].Intitule;
                }

                List<Conditions> pas = DataRepository.Instance.Conditions.SelectById(this.Didactique.Conditions);
                if (pas != null && pas.Count > 0)
                {
                    this.lblConditions.Text = pas[0].Intitule;
                }

                this.lblOrdre.Text = this.Didactique.Ordre.Value.ToString();

                this.lblPerformances.Text = this.Didactique.Performances;
                this.ResizePerformances();

                this.lblDuree.Text = this.Didactique.Duree.Value.ToString();

                this.lblMaterielLieu.Text = this.Didactique.LieuMateriel;
                this.ResizeMaterielLieu();
            }
        }

        /// <summary>
        /// Resizes the performances.
        /// </summary>
        private void ResizePerformances()
        {
            using (AASCJFPPE.Misc.PrintHelper ph = new Misc.PrintHelper(this.lblPerformances.CreateGraphics()))
            {
                int height = ph.GetRealHeight(this.lblPerformances.Text, this.lblPerformances.Font, this.lblPerformances.Width);
                if (this.lblPerformances.Height < height)
                {
                    this.lblPerformances.Height = height;
                    this.Height = height;
                }
            }
        }

        /// <summary>
        /// Resizes the materiel lieu.
        /// </summary>
        private void ResizeMaterielLieu()
        {

            using (AASCJFPPE.Misc.PrintHelper ph = new Misc.PrintHelper(this.lblPerformances.CreateGraphics()))
            {
                int height = ph.GetRealHeight(this.lblMaterielLieu.Text, this.lblMaterielLieu.Font, this.lblMaterielLieu.Width);
                if (this.Height < height)
                {
                    this.lblMaterielLieu.Height = height;
                    this.Height = height;
                }
            }
        }

        /// <summary>
        /// Handles the Resize event of the UCDidactiqueCJVisualisation control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void UCDidactiqueCJVisualisation_Resize(object sender, System.EventArgs e)
        {
            this.ResizePerformances();
            this.ResizeMaterielLieu();
        }
    }
}
