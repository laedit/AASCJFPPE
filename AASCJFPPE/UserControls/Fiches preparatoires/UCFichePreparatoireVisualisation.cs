using System;
using System.Windows.Forms;
using AASCJFPPE.DAL.Datas;

namespace AASCJFPPE.UserControls.Fiche_preparatoires
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UCFichePreparatoireVisualisation : UCFichePreparatoire
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UCFichePreparatoireVisualisation"/> class.
        /// </summary>
        public UCFichePreparatoireVisualisation()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Adds the information to newly created didactique panel.
        /// </summary>
        /// <returns></returns>
        protected override UCSeanceFP GetSeancePanel(FichePreparatoire seance)
        {
            return new UCSeanceFPVisualisation(seance) { Dock = DockStyle.Top };
        }


        /// <summary>
        /// Initializes the cahier journal datas.
        /// </summary>
        protected override void InitializeFichePreparatoireDatas()
        {
            if (this.Seances != null && this.Seances.Count > 0)
            {
                this.lblDataJour.Text = this.Seances[0].Date.Value.ToShortDateString();

            }

            base.InitializeFichePreparatoireDatas();
        }

        private void UCCahierJournalVisualisation_Resize(object sender, EventArgs e)
        {
            this.lblDataJour.Left = this.lblJour.Left + this.lblJour.Width + 10;
        }

    }
}
