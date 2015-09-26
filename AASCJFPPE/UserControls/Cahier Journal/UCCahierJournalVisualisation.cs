using System;
using System.Windows.Forms;
using AASCJFPPE.DAL.Datas;

namespace AASCJFPPE.UserControls.Cahier_Journal
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UCCahierJournalVisualisation : UCCahierJournal
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UCCahierJournalVisualisation"/> class.
        /// </summary>
        public UCCahierJournalVisualisation()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Adds the information to newly created didactique panel.
        /// </summary>
        /// <returns></returns>
        protected override UCSeanceCJ GetSeancePanel(CahierJournal seance)
        {
            return new UCSeanceCJVisualisation(seance) { Dock = DockStyle.Top };
        }


        /// <summary>
        /// Initializes the cahier journal datas.
        /// </summary>
        protected override void InitializeCahierJournalDatas()
        {
            if (this.Seances != null && this.Seances.Count > 0)
            {
                this.lblDataPeriode.Text = "du " + this.Seances[0].DateDebut.Value.ToShortDateString() + " au " + this.Seances[0].DateFin.Value.ToShortDateString();

                this.lblDataJour.Text = this.Seances[0].DateJour.Value.ToShortDateString();

            }

            base.InitializeCahierJournalDatas();
        }

        private void UCCahierJournalVisualisation_Resize(object sender, EventArgs e)
        {
            this.lblDataPeriode.Left = this.lblPeriode.Left + this.lblPeriode.Width + 10;
            this.lblDataJour.Left = this.lblJour.Left + this.lblJour.Width + 10;

            if (this.lblDataPeriode.Left + this.lblDataPeriode.Width > this.lblPEPrenomNom.Left)
            {
                Int32 space = (this.lblDataPeriode.Left + this.lblDataPeriode.Width) - this.lblPEPrenomNom.Left;
                this.lblDataPeriode.Left -= space;
                this.lblPeriode.Left -= space;
            }
        }

    }
}
