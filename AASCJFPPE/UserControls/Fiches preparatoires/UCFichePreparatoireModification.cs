using System;
using System.Windows.Forms;
using AASCJFPPE.DAL.Datas;

namespace AASCJFPPE.UserControls.Fiche_preparatoires
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UCFichePreparatoireModification : UCFichePreparatoire
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UCFichePreparatoireModification"/> class.
        /// </summary>
        public UCFichePreparatoireModification()
        {
            InitializeComponent();
            this.AddSeance();
        }

        /// <summary>
        /// Gets the didactique panel.
        /// </summary>
        /// <returns></returns>
        protected override UCSeanceFP GetSeancePanel(FichePreparatoire seance)
        {
            return new UCSeanceFPModification(seance) { Dock = DockStyle.Top };
        }

        /// <summary>
        /// Initializes the fiche préparatoire datas.
        /// </summary>
        protected override void InitializeFichePreparatoireDatas()
        {
            if (this.Seances != null && this.Seances.Count > 0)
            {
                this.dtpDate.Value = this.Seances[0].Date.Value;
            }

            base.InitializeFichePreparatoireDatas();
        }

        /// <summary>
        /// Handles the Click event of the btnAjouterSeance control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnAjouterSeance_Click(object sender, EventArgs e)
        {
            this.AddSeance();
            this.btnDeleteLastSeance.Enabled = true;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                UCSeanceFP ucSeance = this.Controls[i] as UCSeanceFP;
                if (ucSeance != null)
                {
                    ucSeance.Save(this.dtpDate.Value.Date);
                }
            }
        }

        private void UCFichePreparatoireModification_Resize(object sender, EventArgs e)
        {
            this.dtpDate.Left = this.lblJour.Left + this.lblJour.Width + 10;
        }


        /// <summary>
        /// Sets the date.
        /// </summary>
        /// <param name="dayDate">The day date.</param>
        internal void SetDate(DateTime dayDate)
        {
            this.dtpDate.Value = dayDate.Date;
        }

        private void btnDeleteLastSeance_Click(object sender, EventArgs e)
        {
            if (this.Controls.Count > 2)
            {
                this.Controls.RemoveAt(0);
                this.Controls.RemoveAt(0);
                if (this.Controls.Count == 2)
                {
                    this.btnDeleteLastSeance.Enabled = false;
                }
            }
        }
    }
}
