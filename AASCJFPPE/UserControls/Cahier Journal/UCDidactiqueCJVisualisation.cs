using AASCJFPPE.DAL.Datas;
using System.Collections.Generic;
using System.Drawing;

namespace AASCJFPPE.UserControls.Cahier_Journal
{
    /// <summary>
    /// UserControl permettant la visualisation d'une Didactique du Cahier Journal
    /// </summary>
    public partial class UCDidactiqueCJVisualisation : UCDidactiqueCJ
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UCDidactiqueCJVisualisation"/> class.
        /// </summary>
        public UCDidactiqueCJVisualisation()
            : base()
        {
            InitializeComponent();

            this.InitializeData();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UCDidactiqueCJVisualisation"/> class.
        /// </summary>
        /// <param name="didactique">The didactique.</param>
        public UCDidactiqueCJVisualisation(DidactiqueCJ didactique)
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

                List<PhaseApprentissage> pas = DataRepository.Instance.PhaseApprentissage.SelectById(this.Didactique.PhaseApprentissage);
                if (pas != null && pas.Count > 0)
                {
                    this.lblPhaseApprentissage.Text = pas[0].Intitule;
                }

                if (!this.Didactique.Realise.HasValue)
                {
                    this.Didactique.Realise = false;
                }

                this.lblRealise.Text = (this.Didactique.Realise.Value) ? "X" : string.Empty;

                this.lblOrdre.Text = this.Didactique.Ordre.Value.ToString();

                this.lblDeroulement.Text = this.Didactique.Deroulement;
                this.ResizeDeroulement();

                this.lblDuree.Text = this.Didactique.Duree.Value.ToString();

                this.lblMaterielLieu.Text = this.Didactique.LieuMateriel;
                this.ResizeMaterielLieu();
            }
        }

        /// <summary>
        /// Resizes the deroulement.
        /// </summary>
        private void ResizeDeroulement()
        {
            using (AASCJFPPE.Misc.PrintHelper ph = new Misc.PrintHelper(this.lblDeroulement.CreateGraphics()))
            {
                int height = ph.GetRealHeight(this.lblDeroulement.Text, this.lblDeroulement.Font, this.lblDeroulement.Width);
                if (this.lblDeroulement.Height < height)
                {
                    this.lblDeroulement.Height = height;
                    this.Height = height;
                }
            }
        }

        /// <summary>
        /// Resizes the materiel lieu.
        /// </summary>
        private void ResizeMaterielLieu()
        {

            using (AASCJFPPE.Misc.PrintHelper ph = new Misc.PrintHelper(this.lblDeroulement.CreateGraphics()))
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
            this.ResizeDeroulement();
            this.ResizeMaterielLieu();
        }
    }
}
