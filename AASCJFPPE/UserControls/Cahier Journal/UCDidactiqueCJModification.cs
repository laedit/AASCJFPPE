using AASCJFPPE.DAL.Datas;
using System.Collections.Generic;
using AASCJFPPE.Misc;
using System.Linq;

namespace AASCJFPPE.UserControls.Cahier_Journal
{
    /// <summary>
    /// UserControl permettant de modifier une Didactique du Cahier Journal
    /// </summary>
    public partial class UCDidactiqueCJModification : UCDidactiqueCJ
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UCDidactiqueCJModification"/> class.
        /// </summary>
        public UCDidactiqueCJModification()
            : base()
        {
            InitializeComponent();

            this.InitializeData();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UCDidactiqueCJModification"/> class.
        /// </summary>
        /// <param name="didactique">The didactique.</param>
        public UCDidactiqueCJModification(DidactiqueCJ didactique)
            : base(didactique)
        {
            InitializeComponent();

            this.InitializeData();
        }


        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitializeData()
        {
            this.cmbPhaseApprentissage.DataSource = DataRepository.Instance.PhaseApprentissage.ToList();
            this.cmbPhaseApprentissage.DisplayMember = "Intitule";
            this.cmbPhaseApprentissage.ValueMember = "Id";

            this.cmbDispositifSocial.DataSource = DataRepository.Instance.DispositifSocial.ToList().OrderBy(ds => ds.Intitule).ToList();
            this.cmbDispositifSocial.DisplayMember = "Intitule";
            this.cmbDispositifSocial.ValueMember = "Id";

            if (this.Didactique != null)
            {
                List<DispositifSocial> dss = DataRepository.Instance.DispositifSocial.SelectById(this.Didactique.DispositifSocial);

                if (dss != null && dss.Count > 0)
                {
                    this.cmbDispositifSocial.Text = dss[0].Intitule;
                }

                List<PhaseApprentissage> pas = DataRepository.Instance.PhaseApprentissage.SelectById(this.Didactique.PhaseApprentissage);
                if (pas != null && pas.Count > 0)
                {
                    this.cmbPhaseApprentissage.Text = pas[0].Intitule;
                }

                if (!this.Didactique.Realise.HasValue)
                {
                    this.Didactique.Realise = false;
                }

                this.cbRealise.Checked = this.Didactique.Realise.Value;

                this.nudOrdre.Value = this.Didactique.Ordre.Value;

                this.txtDeroulement.Text = this.Didactique.Deroulement;

                this.nudDuree.Value = this.Didactique.Duree.Value;

                this.txtMaterielLieu.Text = this.Didactique.LieuMateriel;
            }
        }


        /// <summary>
        /// Saves this instance.
        /// </summary>
        public override long Save()
        {
            this.Didactique.PhaseApprentissage = (long)this.cmbPhaseApprentissage.SelectedValue;
            this.Didactique.Realise = this.cbRealise.Checked;
            this.Didactique.Ordre = (int)this.nudOrdre.Value;
            this.Didactique.Deroulement = this.txtDeroulement.Text;
            this.Didactique.DispositifSocial = (long)this.cmbDispositifSocial.SelectedValue;
            this.Didactique.Duree =  (int)this.nudDuree.Value;
            this.Didactique.LieuMateriel = this.txtMaterielLieu.Text;

            if (!this.Didactique.Id.HasValue)
            {
                this.Didactique.Id = DataRepository.Instance.DidactiqueCJ.CreateAndGetId(this.Didactique.PhaseApprentissage, 
                                                    this.Didactique.Realise, 
                                                    this.Didactique.Ordre, 
                                                    this.Didactique.Deroulement, 
                                                    this.Didactique.DispositifSocial, 
                                                    this.Didactique.Duree,
                                                    this.Didactique.LieuMateriel);
            }
            else
            {
                DataRepository.Instance.DidactiqueCJ.Update(this.Didactique);
            }
            
            return this.Didactique.Id.Value;
        }
    }
}
