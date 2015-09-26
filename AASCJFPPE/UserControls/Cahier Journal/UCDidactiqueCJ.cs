using System.Windows.Forms;
using AASCJFPPE.DAL.Datas;

namespace AASCJFPPE.UserControls.Cahier_Journal
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UCDidactiqueCJ : UserControl
    {
        /// <summary>
        /// Gets or sets the didactique.
        /// </summary>
        /// <value>The didactique.</value>
        public DidactiqueCJ Didactique { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UCDidactiqueCJ"/> class.
        /// </summary>
        public UCDidactiqueCJ()
        {
            InitializeComponent();

            this.Didactique = new DidactiqueCJ();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UCDidactiqueCJ"/> class.
        /// </summary>
        /// <param name="didactique">The didactique.</param>
        public UCDidactiqueCJ(DidactiqueCJ didactique)
        {
            InitializeComponent();

            this.Didactique = didactique;
        }

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected virtual void InitializeData()
        {

        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public virtual long Save()
        {
            long didactiqueId = -1;

            return didactiqueId;
        }
    }
}
