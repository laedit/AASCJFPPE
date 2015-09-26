using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AASCJFPPE.DAL.Datas;

namespace AASCJFPPE.UserControls
{
    public partial class Informationcomplementaire : UserControl
    {
        #region Properties

        /// <summary>
        /// Gets or sets the eleve id.
        /// </summary>
        /// <value>The eleve id.</value>
        public long EleveId { get; set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Informationcomplementaire"/> class.
        /// </summary>
        public Informationcomplementaire()
        {
            InitializeComponent();
        } // end constructor

        #endregion Constructor


        #region Event handlers

        /// <summary>
        /// Handles the Resize event of the Informationcomplementaire control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Informationcomplementaire_Resize(object sender, EventArgs e)
        {
            this.lblTitre.Left = (this.Width - this.lblTitre.Width) / 2;
            this.txtInfos.Top = this.lblTitre.Top + 20;
            this.txtInfos.Left = 20;
            this.txtInfos.Width = this.Width - 40;
            this.txtInfos.Height = this.Height - this.txtInfos.Top - 40;
            this.btnEnregistrer.Top = this.txtInfos.Top + this.txtInfos.Height + 10;
            this.btnEnregistrer.Left = this.txtInfos.Left + this.txtInfos.Width - this.btnEnregistrer.Width;
        } // end event handler Informationcomplementaire_Resize

        /// <summary>
        /// Handles the VisibleChanged event of the Informationcomplementaire control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Informationcomplementaire_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                if (this.Visible)
                {
                    this.lblTitre.Text = "Informations complémentaires ";


                    if (this.EleveId > 0)
                    {
                        Eleve eleve = DataRepository.Instance.Eleve.SelectById(this.EleveId).FirstOrDefault();
                        if (eleve != null)
                        {
                            this.lblTitre.Text += "de " + eleve.Nom.ToUpper() + " " + eleve.Prenom + " (" + eleve.NiveauIntitule + ")";
                            this.txtInfos.Text = eleve.Informations;
                        }
                        else
                        {
                            MessageBox.Show("L'élève est inconnu.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        this.lblTitre.Text += "générales";

                        List<AASCJFPPE.DAL.Datas.InformationComplementaire> icList = DataRepository.Instance.InformationComplementaire.ToList();

                        if (icList != null && icList.Count > 0)
                        {
                            this.txtInfos.Text = icList[0].Critere;
                        }
                    }
                }
                else
                {
                    // Reset the eleve id
                    this.EleveId = 0;
                }
            }
        } // end event handler Informationcomplementaire_VisibleChanged

        /// <summary>
        /// Handles the Click event of the btnEnregistrer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (this.EleveId > 0)
            {
                Eleve eleve = DataRepository.Instance.Eleve.SelectById(this.EleveId).First();
                eleve.Informations = this.txtInfos.Text;
                DataRepository.Instance.Eleve.Update(eleve);
            }
            else
            {
                List<AASCJFPPE.DAL.Datas.InformationComplementaire> icList = DataRepository.Instance.InformationComplementaire.ToList();

                if (icList == null || icList.Count == 0)
                {
                    DataRepository.Instance.InformationComplementaire.Create(this.txtInfos.Text);
                }
                else
                {
                    DataRepository.Instance.InformationComplementaire.Update(new InformationComplementaire() { Critere = this.txtInfos.Text });
                }
            }
        } // end event handler btnEnregistrer_Click

        #endregion Event handlers
    }
}
