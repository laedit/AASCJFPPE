using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AASCJFPPE.DAL.Datas;

namespace AASCJFPPE.UserControls.Liste_Eleves
{
    public partial class UCEleveList : UserControl
    {
        #region Constants

        private const int UCEleveWidth = 388;

        private const int UCEleveHeight = 38;

        #endregion Constants


        #region Events

        /// <summary>
        /// Occurs when [name clicked].
        /// </summary>
        public event EventHandler EleveNameClicked;

        /// <summary>
        /// Occurs when [delete clicked].
        /// </summary>
        public event EventHandler EleveDeleteClicked;

        /// <summary>
        /// Occurs when [modify clicked].
        /// </summary>
        public event EventHandler EleveModifyClicked;

        #endregion Events


        #region Fields

        /// <summary>
        /// Liste des controles représentant les élèves
        /// </summary>
        private IList<UCEleve> _eleves;

        #endregion Fields


        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="UCEleveList"/> class.
        /// </summary>
        public UCEleveList()
        {
            InitializeComponent();

            this._eleves = new List<UCEleve>();
        }

        #endregion Constructor


       
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
        /// Called when [delete clicked].
        /// </summary>
        private void OnEleveDeleteClicked(Object sender)
        {
            EventHandler eh = this.EleveDeleteClicked;
            if (eh != null)
            {
                eh(sender, new EventArgs());
            }
        }

        /// <summary>
        /// Called when [modify clicked].
        /// </summary>
        private void OnEleveModifyClicked(Object sender)
        {
            EventHandler eh = this.EleveModifyClicked;
            if (eh != null)
            {
                eh(sender, new EventArgs());
            }
        }

        /// <summary>
        /// Organizes the eleves.
        /// </summary>
        private void OrganizeEleves()
        {
            this.Controls.Clear();

            int x = 50;
            int y = 0;

            foreach (UCEleve ucEleve in this._eleves)
            {
                ucEleve.Top = y;
                ucEleve.Left = x;
                this.Controls.Add(ucEleve);

                y += UCEleveHeight;
            }

            this.Height = y + UCEleveHeight;
        }

        /// <summary>
        /// Adds the eleve.
        /// </summary>
        /// <param name="eleve">The eleve.</param>
        /// <param name="editMode">if set to <c>true</c> [edit mode].</param>
        private void AddEleve(Eleve eleve, Boolean editMode)
        {
            UCEleve ucEleve = new UCEleve { Nom = eleve.Nom, Prenom = eleve.Prenom, Tag = eleve.Id, EditMode = editMode };

            ucEleve.NameClicked += ucEleve_NameClicked;
            ucEleve.DeleteButtonClicked += ucEleve_DeleteButtonClicked;
            ucEleve.ModifyButtonClicked += ucEleve_ModifyButtonClicked;

            this._eleves.Add(ucEleve);
        }

        /// <summary>
        /// Handles the ModifyButtonClicked event of the ucEleve control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void ucEleve_ModifyButtonClicked(object sender, System.EventArgs e)
        {
            this.OnEleveModifyClicked(sender);
        }

        /// <summary>
        /// Handles the DeleteButtonClicked event of the ucEleve control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void ucEleve_DeleteButtonClicked(object sender, System.EventArgs e)
        {
            this._eleves.Remove(sender as UCEleve);
            this.OrganizeEleves();

            this.OnEleveDeleteClicked(sender);
        }

        /// <summary>
        /// Handles the NameClicked event of the ucEleve control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void ucEleve_NameClicked(object sender, System.EventArgs e)
        {
            this.OnEleveNameClicked(sender);
        }

        #endregion Private methods


        #region Public methods

        /// <summary>
        /// Adds the specified eleve.
        /// </summary>
        /// <param name="eleve">The eleve.</param>
        public void Add(Eleve eleve)
        {
            this.Add(eleve, false);
        }

        /// <summary>
        /// Adds the specified eleve.
        /// </summary>
        /// <param name="eleve">The eleve.</param>
        /// <param name="editMode">if set to <c>true</c> [edit mode].</param>
        public void Add(Eleve eleve, Boolean editMode)
        {
            this.AddEleve(eleve, editMode);

            this.OrganizeEleves();
        }

        /// <summary>
        /// Adds the specified eleve.
        /// </summary>
        /// <param name="eleve">The eleve.</param>
        public void Add(List<Eleve> eleves)
        {
            foreach (Eleve eleve in eleves)
            {
                this.AddEleve(eleve, false);
            }

            this.OrganizeEleves();
        }

        /// <summary>
        /// Removes the specified eleve.
        /// </summary>
        /// <param name="eleve">The eleve.</param>
        public void Remove(Eleve eleve)
        {
            foreach (UCEleve item in this._eleves)
            {
                if (eleve.Id == (long)item.Tag)
                {
                    this._eleves.Remove(item);
                    break;
                }
            }

            this.OrganizeEleves();
        }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear()
        {
            this._eleves.Clear();

            this.OrganizeEleves();
        }

        #endregion Public methods
    }
}
