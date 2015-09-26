using System;
using System.Windows.Forms;
using AASCJFPPE.DAL.Datas;

namespace AASCJFPPE.UserControls.Cahier_Journal
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UCCahierJournalModification : UCCahierJournal
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UCCahierJournalModification"/> class.
        /// </summary>
        public UCCahierJournalModification()
        {
            InitializeComponent();
            this.AddSeance();
        }

        /// <summary>
        /// Gets the didactique panel.
        /// </summary>
        /// <returns></returns>
        protected override UCSeanceCJ GetSeancePanel(CahierJournal seance)
        {
            return new UCSeanceCJModification(seance) { Dock = DockStyle.Top };
        }

        /// <summary>
        /// Initializes the cahier journal datas.
        /// </summary>
        protected override void InitializeCahierJournalDatas()
        {
            if (this.Seances != null && this.Seances.Count > 0)
            {
                this.dtpDateDebut.Value = this.Seances[0].DateDebut.Value;
                this.dtpDateFin.Value = this.Seances[0].DateFin.Value;

                this.dtpDateJour.Value = this.Seances[0].DateJour.Value;
            }

            base.InitializeCahierJournalDatas();
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
                UCSeanceCJ ucSeance = this.Controls[i] as UCSeanceCJ;
                if (ucSeance != null)
                {
                    ucSeance.Save(this.dtpDateDebut.Value.Date, this.dtpDateFin.Value.Date, this.dtpDateJour.Value.Date);
                }
            }
        }

        private void UCCahierJournalModification_Resize(object sender, EventArgs e)
        {
            Int32 space = 10;
            Int32 periodeWith = this.lblPeriode.Width + space + this.dtpDateDebut.Width + space + this.dtpDateFin.Width;

            this.lblPeriode.Left = (this.pnlPeriodeNom.Width - periodeWith) / 2;
            this.dtpDateDebut.Left = this.lblPeriode.Left + this.lblPeriode.Width + 10;
            this.dtpDateFin.Left = this.dtpDateDebut.Left + this.dtpDateDebut.Width + 10;
            
            this.dtpDateJour.Left = this.lblJour.Left + this.lblJour.Width + 10;

            if (this.dtpDateFin.Left + this.dtpDateFin.Width > this.lblPEPrenomNom.Left)
            {
                Int32 difference = (this.dtpDateFin.Left + this.dtpDateFin.Width) - this.lblPEPrenomNom.Left;
                this.dtpDateDebut.Left -= difference;
                this.dtpDateFin.Left -= difference;
                this.lblPeriode.Left -= difference;
            }
        }


        /// <summary>
        /// Sets the date.
        /// </summary>
        /// <param name="dayDate">The day date.</param>
        internal void SetDate(DateTime dayDate)
        {
            this.dtpDateJour.Value = dayDate.Date;

            switch (dayDate.DayOfWeek)
            {
                case DayOfWeek.Friday:
                    this.dtpDateDebut.Value = dayDate.AddDays(-4).Date;
                    this.dtpDateFin.Value = dayDate.Date;
                    break;

                case DayOfWeek.Monday:
                    this.dtpDateDebut.Value = dayDate.Date;
                    this.dtpDateFin.Value = dayDate.AddDays(4).Date;
                    break;

                case DayOfWeek.Saturday:
                    this.dtpDateDebut.Value = dayDate.AddDays(-5).Date;
                    this.dtpDateFin.Value = dayDate.AddDays(1).Date;
                    break;

                case DayOfWeek.Sunday:
                    this.dtpDateDebut.Value = dayDate.AddDays(-6).Date;
                    this.dtpDateFin.Value = dayDate.Date;
                    break;

                case DayOfWeek.Thursday:
                    this.dtpDateDebut.Value = dayDate.AddDays(-3).Date;
                    this.dtpDateFin.Value = dayDate.AddDays(1).Date;
                    break;

                case DayOfWeek.Tuesday:
                    this.dtpDateDebut.Value = dayDate.AddDays(-1).Date;
                    this.dtpDateFin.Value = dayDate.AddDays(3).Date;
                    break;

                case DayOfWeek.Wednesday:
                    this.dtpDateDebut.Value = dayDate.AddDays(-2).Date;
                    this.dtpDateFin.Value = dayDate.AddDays(2).Date;
                    break;
            }
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
