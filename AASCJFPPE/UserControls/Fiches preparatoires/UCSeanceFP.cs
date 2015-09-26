using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using AASCJFPPE.DAL.Datas;
using AASCJFPPE.Misc;

namespace AASCJFPPE.UserControls.Fiche_preparatoires
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UCSeanceFP : UserControl
    {
        /// <summary>
        /// Seance
        /// </summary>
        private FichePreparatoire _seance;

        /// <summary>
        /// Gets or sets the seance.
        /// </summary>
        /// <value>The seance.</value>
        public FichePreparatoire Seance
        {
            get { return _seance; }
            set
            {
                _seance = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UCSeanceFP"/> class.
        /// </summary>
        public UCSeanceFP()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UCSeanceFP"/> class.
        /// </summary>
        /// <param name="seance">The seance.</param>
        public UCSeanceFP(FichePreparatoire seance)
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
        protected virtual UCDidactiqueFP GetDidactiquePanel(DidactiqueFP didactique)
        {
            return null;
        }

        /// <summary>
        /// Adds the didactique panel.
        /// </summary>
        protected void AddDidactiquePanel(DidactiqueFP didactique)
        {
            Panel previousPanel = this.pnlDidactiques.Controls[this.pnlDidactiques.Controls.Count - 1] as Panel;

            UCDidactiqueFP ucDidactiqueCJ = this.GetDidactiquePanel(didactique);
            ucDidactiqueCJ.Name = "pnlDidactique" + this.pnlDidactiques.Controls.Count;
            ucDidactiqueCJ.Dock = DockStyle.Top;

            ucDidactiqueCJ.Location = new System.Drawing.Point(0, previousPanel.Height);

            this.pnlDidactiques.Controls.Add(ucDidactiqueCJ);
            this.pnlDidactiques.Controls.SetChildIndex(ucDidactiqueCJ, 0);
        }

        /// <summary>
        /// Initializes the fiche préparatoire datas.
        /// </summary>
        protected virtual void InitializeDidactiques(List<DidactiqueFP> didactiques)
        {
            this.DeleteDidactiquePanels();

            this.AddDidactiquePanels(didactiques);
        }

        /// <summary>
        /// Adds the didactique panels.
        /// </summary>
        /// <param name="didactiques">The didactiques.</param>
        protected void AddDidactiquePanels(List<DidactiqueFP> didactiques)
        {
            foreach (DidactiqueFP didactique in didactiques)
            {
                this.AddDidactiquePanel(didactique);
            }
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <param name="date">The date.</param>
        public virtual void Save(DateTime date)
        {

        }


        /// <summary>
        /// Handles the Resize event of the pnlDeroulement control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void pnlDeroulement_Resize(object sender, System.EventArgs e)
        {
            this.lblPerformances.Left = (this.pnlPerformances.Width - this.lblPerformances.Width) / 2;
        }

        /// <summary>
        /// Handles the Resize event of the pnlBilan control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void pnlBilan_Resize(object sender, EventArgs e)
        {
            var size = (this.pnlBilan.Width - this.pnlBilanHeader.Width ) /2;
            this.pnlBilanNegatif.Width = size;
            this.lblPointsNegatifs.Left = (this.pnlBilanNegatif.Width - this.lblPointsNegatifs.Width) / 2;
            this.pnlBilanPositif.Width = size;
            this.lblPointPositif.Left = (this.pnlBilanPositif.Width - this.lblPointPositif.Width) / 2;
        }
    }
}
