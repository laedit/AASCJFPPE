using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AASCJFPPE.DAL.Datas;
using AASCJFPPE.Misc;

namespace AASCJFPPE.UserControls.Cahier_Journal
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UCSeanceCJ : UserControl
    {
        /// <summary>
        /// Seance
        /// </summary>
        private CahierJournal _seance;

        /// <summary>
        /// Gets or sets the seance.
        /// </summary>
        /// <value>The seance.</value>
        public CahierJournal Seance
        {
            get { return _seance; }
            set
            {
                _seance = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UCSeanceCJ"/> class.
        /// </summary>
        public UCSeanceCJ()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UCSeanceCJ"/> class.
        /// </summary>
        /// <param name="seance">The seance.</param>
        public UCSeanceCJ(CahierJournal seance)
            : this()
        {
            this.Seance = seance;
        }

        /// <summary>
        /// Initializes the seance datas.
        /// </summary>
        protected virtual void InitializeSeanceDatas()
        {

        }

        /// <summary>
        /// Deletes the didactique panels.
        /// </summary>
        protected void DeleteDidactiquePanels()
        {
            for (int i = 0; i < pnlDidactiques.Controls.Count; i++)
            {
                if (pnlDidactiques.Controls[i].Name != "pnlFooter")
                {
                    pnlDidactiques.Controls.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Gets the didactique panel.
        /// </summary>
        /// <param name="didactique">The didactique.</param>
        /// <returns></returns>
        protected virtual UCDidactiqueCJ GetDidactiquePanel(DidactiqueCJ didactique)
        {
            return null;
        }

        /// <summary>
        /// Adds the didactique panel.
        /// </summary>
        protected void AddDidactiquePanel(DidactiqueCJ didactique)
        {
            Panel previousPanel = this.pnlDidactiques.Controls[this.pnlDidactiques.Controls.Count - 1] as Panel;

            UCDidactiqueCJ ucDidactiqueCJ = this.GetDidactiquePanel(didactique);
            ucDidactiqueCJ.Name = "pnlDidactique" + this.pnlDidactiques.Controls.Count;
            ucDidactiqueCJ.Dock = DockStyle.Top;

            ucDidactiqueCJ.Location = new System.Drawing.Point(0, previousPanel.Height);

            this.pnlDidactiques.Controls.Add(ucDidactiqueCJ);
            this.pnlDidactiques.Controls.SetChildIndex(ucDidactiqueCJ, 0);
        }

        /// <summary>
        /// Initializes the cahier journal datas.
        /// </summary>
        protected virtual void InitializeDidactiques(List<DidactiqueCJ> didactiques)
        {
            this.DeleteDidactiquePanels();

            this.AddDidactiquePanels(didactiques);
        }

        /// <summary>
        /// Adds the didactique panels.
        /// </summary>
        /// <param name="didactiques">The didactiques.</param>
        protected void AddDidactiquePanels(List<DidactiqueCJ> didactiques)
        {
            foreach (DidactiqueCJ didactique in didactiques)
            {
                this.AddDidactiquePanel(didactique);
            }
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <param name="dateDebut">The date debut.</param>
        /// <param name="dateFin">The date fin.</param>
        /// <param name="dateJour">The date jour.</param>
        public virtual void Save(DateTime dateDebut, DateTime dateFin, DateTime dateJour)
        {

        }


        protected void pnlDeroulement_Resize(object sender, System.EventArgs e)
        {
            this.lblDeroulement.Left = (this.pnlDeroulement.Width - this.lblDeroulement.Width) / 2;
        }
    }
}
