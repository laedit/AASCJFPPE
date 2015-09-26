using System.Windows.Forms;
using AASCJFPPE.DAL.Datas;
using AASCJFPPE.Misc;
using AASCJFPPE.DAL;
using System;
using AASCJFPPE.Properties;
using AASCJFPPE.UserControls.Liste_Eleves;

namespace AASCJFPPE
{
    /// <summary>
    /// Main form of the application
    /// </summary>
    public partial class MainForm : Form
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            this.InitializeDataAccess();

            InitializeComponent();

            this.InitializeFiches();

            this.parametres.DataRestorationCompleted += parametres_DataRestorationCompleted;

            this.ucListeEleves.EleveNameClicked += ucListeEleves_EleveNameClicked;

            for (int i = this.tcCategories.TabPages.Count - 1; i >= 0; i--)
            {
                if (this.tcCategories.TabPages[i].Controls.Count == 0)
                {
                    this.tcCategories.TabPages.RemoveAt(i);
                }
            }

        } // end constructor

        #endregion Constructor


        #region Private methods

        /// <summary>
        /// Initializes the data access.
        /// </summary>
        private void InitializeDataAccess()
        {
            EntityBase.ConnectionString = Variables.ConnectionString;

            if (!DatabaseMaintenance.UpdateDatabase())
            {
                MessageBox.Show("Une erreur est survenue lors de la mise à jour de la base de données. L'application pourra rencontrer certains problèmes.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.DataBackup();
        }

        /// <summary>
        /// Initializes the fiches.
        /// </summary>
        private void InitializeFiches()
        {
            this.ucFicheCahierJournal.Initialize();

            this.ucFicheFP.Initialize();
        }

        /// <summary>
        /// Backup the datas
        /// </summary>
        private void DataBackup()
        {
            Boolean doBackup = false;

            switch (Settings.Default.DataBackupFrequency)
            {
                    // Day
                case 1: doBackup = CheckTimeLength(TimeSpan.FromDays(1));
                    break;

                    // Week
                case 2: doBackup = CheckTimeLength(TimeSpan.FromDays(7));
                    break;

                    // Month
                case 3: doBackup = CheckTimeLength(TimeSpan.FromDays(30));
                    break;

                default:
                    break;
            }

            if (doBackup)
            {
                DatabaseMaintenance.BackUpDatabase();
                Settings.Default.DataBackupLastDate = DateTime.Now.Date;
                Settings.Default.Save();
            }
        }

        /// <summary>
        /// Checks the length of the time.
        /// </summary>
        /// <param name="ts">The ts.</param>
        /// <returns></returns>
        private bool CheckTimeLength(TimeSpan ts)
        {
            bool result = false;

            if ((DateTime.Now - Settings.Default.DataBackupLastDate) > ts)
            {
                result = true;
            }

            return result;
        }

        #endregion Private methods


        #region Public methods

        /// <summary>
        /// Initializes the name.
        /// </summary>
        public void InitializeName()
        {
            this.ucFicheCahierJournal.InitializeName();
        }

        #endregion Public methods

        #region Event handlers

        /// <summary>
        /// Handles the DataRestorationCompleted event of the parametres control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void parametres_DataRestorationCompleted(object sender, EventArgs e)
        {
            this.InitializeFiches();
        }


        /// <summary>
        /// Handles the EleveNameClicked event of the ucListeEleves control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void ucListeEleves_EleveNameClicked(object sender, EventArgs e)
        {
            this.informationcomplementaire.EleveId = (long)((UCEleve)sender).Tag;
            this.tcCategories.SelectedTab = this.tbpInformationsComplementaires;
        }

        #endregion Event handlers
    }
}

