using System;
using System.Windows.Forms;
using AASCJFPPE.Properties;

namespace AASCJFPPE.UserControls.Liste_Eleves
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UCEleve : UserControl
    {
        #region Events

        /// <summary>
        /// Occurs when [name clicked].
        /// </summary>
        public event EventHandler NameClicked;

        /// <summary>
        /// Occurs when [delete button clicked].
        /// </summary>
        public event EventHandler DeleteButtonClicked;

        /// <summary>
        /// Occurs when [modify button clicked].
        /// </summary>
        public event EventHandler ModifyButtonClicked;

        #endregion Events


        #region Fields

        /// <summary>
        /// True if the control is in Edit mode
        /// </summary>
        private Boolean _isInEditMode;

        #endregion Fields


        #region Properties

        /// <summary>
        /// Gets or sets the nom.
        /// </summary>
        /// <value>The nom.</value>
        public String Nom
        {
            get { return this.LblNom.Text; }
            set { this.LblNom.Text = value; this.txtNom.Text = value; }
        }

        /// <summary>
        /// Gets or sets the prenom.
        /// </summary>
        /// <value>The prenom.</value>
        public String Prenom
        {
            get { return this.lblPrenom.Text; }
            set { this.lblPrenom.Text = value; this.txtPrenom.Text = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [edit mode].
        /// </summary>
        /// <value><c>true</c> if [edit mode]; otherwise, <c>false</c>.</value>
        public Boolean EditMode
        {
            get
            { return this._isInEditMode; }

            set
            {
                this.ChangeMode(value);
            }
        }

        #endregion Properties


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UCEleve"/> class.
        /// </summary>
        public UCEleve()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Private methods

        /// <summary>
        /// Called when [name clicked].
        /// </summary>
        private void OnNameClicked()
        {
            EventHandler eh = this.NameClicked;
            if (eh != null)
            {
                eh(this, new EventArgs());
            }
        }

        /// <summary>
        /// Called when [delete button clicked].
        /// </summary>
        private void OnDeleteButtonClicked()
        {
            EventHandler eh = this.DeleteButtonClicked;
            if (eh != null)
            {
                eh(this, new EventArgs());
            }
        }

        /// <summary>
        /// Called when [modify button clicked].
        /// </summary>
        private void OnModifyButtonClicked()
        {
            EventHandler eh = this.ModifyButtonClicked;
            if (eh != null)
            {
                eh(this, new EventArgs());
            }
        }

        /// <summary>
        /// Changes the mode.
        /// </summary>
        /// <param name="isInEditMode">if set to <c>true</c> [is in edit mode].</param>
        private void ChangeMode(Boolean isInEditMode)
        {
            this._isInEditMode = isInEditMode;

            this.txtNom.Visible = this.txtPrenom.Visible = isInEditMode;
            this.LblNom.Visible = this.lblPrenom.Visible = !isInEditMode;

            if (isInEditMode)
            {
                this.btnModify.BackgroundImage = Resources.Save;
                this.txtNom.Text = this.LblNom.Text;
                this.txtPrenom.Text = this.lblPrenom.Text;
            }
            else
            {
                this.btnModify.BackgroundImage = Resources.Edit;
                this.LblNom.Text = this.txtNom.Text;
                this.lblPrenom.Text = this.txtPrenom.Text;
            }
        }

        #endregion Private methods


        #region Event handlers

        /// <summary>
        /// Handles the Click event of the btnDelete control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.OnDeleteButtonClicked();
        }

        /// <summary>
        /// Handles the Click event of the LblNom control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void LblNom_Click(object sender, EventArgs e)
        {
            this.OnNameClicked();
        }

        /// <summary>
        /// Handles the Click event of the btnModify control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnModify_Click(object sender, EventArgs e)
        {
            this.ChangeMode(!this._isInEditMode);

            if (!this._isInEditMode)
            {
                this.OnModifyButtonClicked();
            }
        }

        #endregion Event handlers

    }
}
