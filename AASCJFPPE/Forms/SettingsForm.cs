using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AASCJFPPE
{
    /// <summary>
    /// Form for modify settings of the application
    /// </summary>
    public partial class SettingsForm : Form
    {
        #region Properties

        /// <summary>
        /// Gets the PE prenom.
        /// </summary>
        /// <value>The PE prenom.</value>
        public String PEPrenom
        {
            get { return this.txtPEPrenom.Text; }
        }

        /// <summary>
        /// Gets the PE nom.
        /// </summary>
        /// <value>The PE nom.</value>
        public String PENom
        {
            get { return this.txtPENom.Text; }
        }

        #endregion Properties


        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsForm"/> class.
        /// </summary>
        public SettingsForm()
        {
            InitializeComponent();

            this.txtPENom.Text = AASCJFPPE.Properties.Settings.Default.PENom;
            this.txtPEPrenom.Text = AASCJFPPE.Properties.Settings.Default.PEPrenom;
        }

        #endregion Constructor


        #region Events handlers

        /// <summary>
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            AASCJFPPE.Properties.Settings.Default.PENom = this.txtPENom.Text;
            AASCJFPPE.Properties.Settings.Default.PEPrenom = this.txtPEPrenom.Text;
            AASCJFPPE.Properties.Settings.Default.Save();
            this.Close();
        }

        /// <summary>
        /// Handles the Shown event of the SettingsForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void SettingsForm_Shown(object sender, EventArgs e)
        {
            this.txtPEPrenom.Focus();
        }

        /// <summary>
        /// Handles the KeyDown event of the txtPENom control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void txtPENom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnSave_Click(null, null);
            }
        }

        #endregion Events handlers

    }
}
