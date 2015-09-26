using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using AASCJFPPE.DAL;
using AASCJFPPE.DAL.Datas;
using AASCJFPPE.Misc;

namespace AASCJFPPE.UserControls
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Parametres : UserControl
    {
        #region Events

        /// <summary>
        /// Occurs when [data restoration completed].
        /// </summary>
        public event EventHandler DataRestorationCompleted;

        #endregion Events

        #region Fields

        /// <summary>
        /// Data folder name
        /// </summary>
        private String _dataFolderName;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="APropos"/> class.
        /// </summary>
        public Parametres()
        {
            InitializeComponent();

            this.txtPENom.Text = AASCJFPPE.Properties.Settings.Default.PENom;
            this.txtPEPrenom.Text = AASCJFPPE.Properties.Settings.Default.PEPrenom;

            this.cbDBFrequency.Text = this.cbDBFrequency.Items[0].ToString();

            if (!this.DesignMode)
            {
                if (String.IsNullOrEmpty(EntityBase.ConnectionString))
                {
                    EntityBase.ConnectionString = Variables.ConnectionString;
                }
            }

            String databasePath = EntityBase.ConnectionString.Split(';')[0].Split('=')[1];
            _dataFolderName = Path.GetDirectoryName(databasePath) + "/";
        }

        #endregion Constructor


        #region Private methods

        /// <summary>
        /// Rises the data restoration completed.
        /// </summary>
        private void RaiseDataRestorationCompleted()
        {
            EventHandler eh = this.DataRestorationCompleted;
            if (eh != null)
            {
                eh(this, new EventArgs());
            }
        }

        #endregion Private methods

        #region Event handlers

        /// <summary>
        /// Handles the Resize event of the APropos control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Parametres_Resize(object sender, EventArgs e)
        {
            this.gbNom.Left = (this.Width - this.gbNom.Width) / 2;
            this.gbDataBackup.Left = this.gbNom.Left;
            this.gbDataRestore.Left = this.gbDataBackup.Left;
            this.btnSave.Left = this.gbNom.Left + (this.gbNom.Width - this.btnSave.Width);
            this.btnRestore.Left = this.gbNom.Left + (this.gbNom.Width - this.btnRestore.Width);
        }

        /// <summary>
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            AASCJFPPE.Properties.Settings.Default.PENom = this.txtPENom.Text;
            AASCJFPPE.Properties.Settings.Default.PEPrenom = this.txtPEPrenom.Text;
            AASCJFPPE.Properties.Settings.Default.DataBackupFrequency = this.cbDBFrequency.SelectedIndex;
            AASCJFPPE.Properties.Settings.Default.Save();
            (Application.OpenForms[0] as MainForm).InitializeName();
        }

        /// <summary>
        /// Handles the VisibleChanged event of the Parametres control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Parametres_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                this.cmbDataRestore.Items.Clear();

                List<String> backups = new List<String>(Directory.GetFiles(_dataFolderName, "*datas.sdf"));

                if (backups.Contains(_dataFolderName + "Datas.sdf"))
                {
                    backups.Remove(_dataFolderName + "Datas.sdf");
                }
                // TODO: Modify test: build with current connection string

                if (backups.Count > 0)
                {
                    Int32 folder = _dataFolderName.Length;

                    backups.Sort();
                    backups.Reverse();

                    foreach (String backup in backups)
                    {
                        this.cmbDataRestore.Items.Add("" + backup[folder + 6] + backup[folder + 7] + "/" + backup[folder + 4] + backup[folder + 5] + "/" + backup[folder + 0] + backup[folder + 1] + backup[folder + 2] + backup[folder + 3] + " " + backup[folder + 9] + backup[folder + 10] + ":" + backup[folder + 11] + backup[folder + 12] + ":" + backup[folder + 13] + backup[folder + 14]);
                    }

                    this.cmbDataRestore.Text = this.cmbDataRestore.Items[0].ToString();

                    this.gbDataRestore.Visible = true;
                    this.btnRestore.Visible = true;
                }
                else
                {
                    this.gbDataRestore.Visible = false;
                    this.btnRestore.Visible = false;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnRestore control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnRestore_Click(object sender, EventArgs e)
        {
            DatabaseMaintenance.CloseConnection();

            String dateTimePrefix = DateTime.Now.ToString("yyyyMMdd_HHmmss_");
            String outputFileName = dateTimePrefix + "datas.sdf";

            File.Move(this._dataFolderName + "Datas.sdf", this._dataFolderName + outputFileName);

            File.Move(this._dataFolderName + this.cmbDataRestore.Text[6]
                                           + this.cmbDataRestore.Text[7]
                                           + this.cmbDataRestore.Text[8]
                                           + this.cmbDataRestore.Text[9]
                                           + this.cmbDataRestore.Text[3]
                                           + this.cmbDataRestore.Text[4]
                                           + this.cmbDataRestore.Text[0]
                                           + this.cmbDataRestore.Text[1]
                                           + "_"
                                           + this.cmbDataRestore.Text[11]
                                           + this.cmbDataRestore.Text[12]
                                           + this.cmbDataRestore.Text[14]
                                           + this.cmbDataRestore.Text[15]
                                           + this.cmbDataRestore.Text[17]
                                           + this.cmbDataRestore.Text[18]
                                           + "_datas.sdf"
                    , this._dataFolderName + "Datas.sdf");

            MessageBox.Show("Restauration effectuée", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.RaiseDataRestorationCompleted();
        }

        #endregion Event handlers

    }
}
