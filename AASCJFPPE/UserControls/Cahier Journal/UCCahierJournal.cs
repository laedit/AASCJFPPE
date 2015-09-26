using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AASCJFPPE.DAL.Datas;
using AASCJFPPE.Misc;

namespace AASCJFPPE.UserControls.Cahier_Journal
{
    /// <summary>
    /// UserControl représentant les parties statiques du Cahier Journal
    /// </summary>
    public partial class UCCahierJournal : UserControl
    {
        /// <summary>
        /// Seances
        /// </summary>
        private List<CahierJournal> _seances;

        /// <summary>
        /// Gets or sets the seances.
        /// </summary>
        /// <value>The seances.</value>
        public List<CahierJournal> Seances
        {
            get { return this._seances; }
            set
            {
                this._seances = value;
                this.InitializeCahierJournalDatas();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Seances"/> class.
        /// </summary>
        public UCCahierJournal()
        {
            EntityBase.ConnectionString = Variables.ConnectionString;

            InitializeComponent();

            InitializeDatas();
        }

        /// <summary>
        /// Initializes the cahier journal datas.
        /// </summary>
        protected virtual void InitializeCahierJournalDatas()
        {
            this.DeleteSeance();

            if (this.Seances.Count > 0)
            {
                foreach (CahierJournal seance in Seances)
                {
                    this.AddSeance(seance);
                }
            }
            else
            {
                this.AddSeance();
            }
        }

        /// <summary>
        /// Deletes the seance.
        /// </summary>
        protected void DeleteSeance()
        {
            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                if (this.Controls[i].Name != "pnlHeader" && this.Controls[i].Name != "pnlFooter")
                {
                    this.Controls.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Adds the seance.
        /// </summary>
        protected void AddSeance(CahierJournal seance)
        {
            Panel space = new Panel() { Dock = DockStyle.Top, Height = 30 };
            this.Controls.Add(space);
            this.Controls.SetChildIndex(space, 0);

            UCSeanceCJ ucSeance = this.GetSeancePanel(seance);
            this.Controls.Add(ucSeance);
            this.Controls.SetChildIndex(ucSeance, 0);
        }

        /// <summary>
        /// Adds the seance.
        /// </summary>
        protected void AddSeance()
        {
            this.AddSeance(new CahierJournal());
        }

        /// <summary>
        /// Gets the seance panel.
        /// </summary>
        /// <param name="seance">The seance.</param>
        /// <returns></returns>
        protected virtual UCSeanceCJ GetSeancePanel(CahierJournal seance)
        {
            return null;
        }

        private void UCCahierJournal_Resize(object sender, EventArgs e)
        {
            this.lblPeriode.Left = ((this.pnlPeriodeNom.Width - this.lblPeriode.Width) / 2) - this.lblPeriode.Width;
            this.lblJour.Left = ((this.pnlJour.Width - this.lblJour.Width) / 2) - this.lblJour.Width;
            this.lblPEPrenomNom.Left = this.Width - this.lblPEPrenomNom.Width - 20;
        }


        /// <summary>
        /// Initializes the datas.
        /// </summary>
        public void InitializeDatas()
        {
            if (!String.IsNullOrEmpty(AASCJFPPE.Properties.Settings.Default.PEPrenom))
            {
                this.lblPEPrenomNom.Text = AASCJFPPE.Properties.Settings.Default.PEPrenom[0].ToString().ToUpper() + ". " + AASCJFPPE.Properties.Settings.Default.PENom.ToUpper();
            }
            else
            {
                this.lblPEPrenomNom.Text = String.Empty;
            }
        }

    }
}
