using System;
using System.Windows.Forms;
using AASCJFPPE.DAL.Datas;
using AASCJFPPE.Misc;
using System.Collections.Generic;
using AASCJFPPE.UserControls.Liste_Eleves;
using System.Linq;

namespace AASCJFPPE.UserControls
{
    /// <summary>
    /// Visual of the student list
    /// </summary>
    public partial class ListeEleves : UserControl
    {
        #region Events

        /// <summary>
        /// Occurs when [name clicked].
        /// </summary>
        public event EventHandler EleveNameClicked;

        #endregion Events

        /// <summary>
        /// Initializes a new instance of the <see cref="ListeEleves"/> class.
        /// </summary>
        public ListeEleves()
        {
            InitializeComponent();

            this.ucEleveList1.EleveDeleteClicked += ucEleveList1_EleveDeleteClicked;
            this.ucEleveList1.EleveModifyClicked += ucEleveList1_EleveModifyClicked;
            this.ucEleveList1.EleveNameClicked += ucEleveList1_EleveNameClicked;
        }

        #region Private methods

        /// <summary>
        /// Called when [name clicked].
        /// </summary>
        private void OnEleveNameClicked(Object sender)
        {
            EventHandler eh = this.EleveNameClicked;
            if (eh != null)
            {
                eh(sender, new EventArgs());
            }
        }

        /// <summary>
        /// Refreshes the student list.
        /// </summary>
        private void RefreshStudentList()
        {
            this.ucEleveList1.Clear();

            List<Eleve> eleves = DataRepository.Instance.Eleve.SelectByNiveau((long)((Niveau)this.cmbNiveau.SelectedItem).Id);

            if (eleves != null && eleves.Count > 0)
            {
                this.ucEleveList1.Add(eleves);
            }
        }

        #endregion Private methods

        /// <summary>
        /// Handles the EleveNameClicked event of the ucEleveList1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void ucEleveList1_EleveNameClicked(object sender, EventArgs e)
        {
            this.OnEleveNameClicked(sender);
        }

        /// <summary>
        /// Handles the EleveModifyClicked event of the ucEleveList1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void ucEleveList1_EleveModifyClicked(object sender, EventArgs e)
        {
            // Modify an existing eleve (Nom, Prenom) by his Id
            UCEleve ucEleve= (UCEleve)sender;
            Eleve eleve = DataRepository.Instance.Eleve.SelectById((long)ucEleve.Tag).First();
            eleve.Nom = ucEleve.Nom;
            eleve.Prenom = ucEleve.Prenom;
            DataRepository.Instance.Eleve.Update(eleve);
        }

        /// <summary>
        /// Handles the EleveDeleteClicked event of the ucEleveList1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void ucEleveList1_EleveDeleteClicked(object sender, EventArgs e)
        {
            DataRepository.Instance.Eleve.DeleteById((long)((UCEleve)sender).Tag);
        }

        /// <summary>
        /// Handles the Load event of the ListeEleves control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ListeEleves_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                if (String.IsNullOrEmpty(EntityBase.ConnectionString))
                {
                    EntityBase.ConnectionString = Variables.ConnectionString;
                }

                this.cmbNiveau.DataSource = DataRepository.Instance.Niveau.ToList();
                this.cmbNiveau.ValueMember = "Id";
                this.cmbNiveau.DisplayMember = "Intitule";
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cmbNiveau control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cmbNiveau_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.RefreshStudentList();
        }

        /// <summary>
        /// Handles the Click event of the btnAddELeve control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnAddELeve_Click(object sender, EventArgs e)
        {
            Eleve newEleve = new Eleve { Niveau = (long)((Niveau)this.cmbNiveau.SelectedItem).Id, Nom = String.Empty, Prenom = String.Empty, Informations = String.Empty };
            newEleve.Id = DataRepository.Instance.Eleve.CreateAndGetId(newEleve);
            this.ucEleveList1.Add(newEleve, true);
        }
    }
}
