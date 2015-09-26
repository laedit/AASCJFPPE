using System.Windows.Forms;
using AASCJFPPE.DAL.Datas;

namespace AASCJFPPE.UserControls.Fiche_preparatoires
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UCDidactiqueFP : UserControl
    {
        /// <summary>
        /// Gets or sets the didactique.
        /// </summary>
        /// <value>The didactique.</value>
        public DidactiqueFP Didactique { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UCDidactiqueFP"/> class.
        /// </summary>
        public UCDidactiqueFP()
        {
            InitializeComponent();

            this.Didactique = new DidactiqueFP();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UCDidactiqueFP"/> class.
        /// </summary>
        /// <param name="didactique">The didactique.</param>
        public UCDidactiqueFP(DidactiqueFP didactique)
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
