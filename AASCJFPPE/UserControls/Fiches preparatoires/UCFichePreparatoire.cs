using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AASCJFPPE.DAL.Datas;
using AASCJFPPE.Misc;

namespace AASCJFPPE.UserControls.Fiche_preparatoires
{
    /// <summary>
    /// UserControl représentant les parties statiques d'une Fiche Préparatoire
    /// </summary>
    public partial class UCFichePreparatoire : UserControl
    {
        /// <summary>
        /// Seances
        /// </summary>
        private List<FichePreparatoire> _seances;

        /// <summary>
        /// Gets or sets the seances.
        /// </summary>
        /// <value>The seances.</value>
        public List<FichePreparatoire> Seances
        {
            get { return this._seances; }
            set
            {
                this._seances = value;
                this.InitializeFichePreparatoireDatas();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Seances"/> class.
        /// </summary>
        public UCFichePreparatoire()
        {
            EntityBase.ConnectionString = Variables.ConnectionString;

            InitializeComponent();

            InitializeDatas();
        }

        /// <summary>
        /// Initializes the cahier journal datas.
        /// </summary>
        protected virtual void InitializeFichePreparatoireDatas()
        {
            this.DeleteSeance();

            if (this.Seances.Count > 0)
            {
                foreach (FichePreparatoire seance in Seances)
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
        protected void AddSeance(FichePreparatoire seance)
        {
            Panel space = new Panel() { Dock = DockStyle.Top, Height = 30 };
            this.Controls.Add(space);
            this.Controls.SetChildIndex(space, 0);

            UCSeanceFP ucSeance = this.GetSeancePanel(seance);
            this.Controls.Add(ucSeance);
            this.Controls.SetChildIndex(ucSeance, 0);
        }

        /// <summary>
        /// Adds the seance.
        /// </summary>
        protected void AddSeance()
        {
            this.AddSeance(new FichePreparatoire());
        }

        /// <summary>
        /// Gets the seance panel.
        /// </summary>
        /// <param name="seance">The seance.</param>
        /// <returns></returns>
        protected virtual UCSeanceFP GetSeancePanel(FichePreparatoire seance)
        {
            return null;
        }

        private void UCFichePreparatoire_Resize(object sender, EventArgs e)
        {
            this.lblJour.Left = ((this.pnlJour.Width - this.lblJour.Width) / 2) - this.lblJour.Width;
        }


        /// <summary>
        /// Initializes the datas.
        /// </summary>
        public void InitializeDatas()
        {
            
        }

    }
}
