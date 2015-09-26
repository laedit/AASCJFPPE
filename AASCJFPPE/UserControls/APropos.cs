using System;
using System.Reflection;
using System.Windows.Forms;
using System.Diagnostics;
using AASCJFPPE.DAL.Datas;

namespace AASCJFPPE.UserControls
{
    public partial class APropos : UserControl
    {

        #region Assembly Attribute Accessors

        /// <summary>
        /// Gets the assembly title.
        /// </summary>
        /// <value>The assembly title.</value>
        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != String.Empty)
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        /// <summary>
        /// Gets the assembly version.
        /// </summary>
        /// <value>The assembly version.</value>
        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        /// <summary>
        /// Gets the assembly description.
        /// </summary>
        /// <value>The assembly description.</value>
        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return String.Empty;
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        /// <summary>
        /// Gets the assembly product.
        /// </summary>
        /// <value>The assembly product.</value>
        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return String.Empty;
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        /// <summary>
        /// Gets the assembly copyright.
        /// </summary>
        /// <value>The assembly copyright.</value>
        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return String.Empty;
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        /// <summary>
        /// Gets the assembly company.
        /// </summary>
        /// <value>The assembly company.</value>
        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return String.Empty;
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        #endregion Assembly Attribute Accessors


        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="APropos"/> class.
        /// </summary>
        public APropos()
        {
            InitializeComponent();

            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = AssemblyCompany;
            this.lblDescription.Text = AssemblyDescription;
            this.lblDatabaseVersion.Text += DataRepository.Instance.Version.GetMaxNumero();
        }

        #endregion Constructor


        #region Private methods

        /// <summary>
        /// Processes the link.
        /// </summary>
        /// <param name="url">The URL.</param>
        private void ProcessLink(String url)
        {
            Process.Start(url);
        }

        #endregion Private methods

        #region Event handlers

        /// <summary>
        /// Handles the Click event of the labelCompanyName control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Link_Click(object sender, EventArgs e)
        {
            Object tag = ((Control)sender).Tag;
            if (tag != null)
            {
                this.ProcessLink(tag.ToString());
            }
        }

        /// <summary>
        /// Handles the Click event of the Mail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Mail_Click(object sender, EventArgs e)
        {
            Object tag = ((Control)sender).Tag;
            if (tag != null)
            {
                this.ProcessLink("mailto:" + tag.ToString());
            }
        }

        /// <summary>
        /// Handles the Resize event of the APropos control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void APropos_Resize(object sender, EventArgs e)
        {
            this.gbDeveloppement.Left = (this.Width - this.gbDeveloppement.Width) / 2;
            this.gbOutilsTiers.Left = this.gbDeveloppement.Left;
        }

        #endregion Event handlers

    }
}
