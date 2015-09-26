using AASCJFPPE.DAL.Datas;
using System.Collections.Generic;
using AASCJFPPE.Misc;
using System.Linq;

namespace AASCJFPPE.UserControls.Fiche_preparatoires
{
    /// <summary>
    /// UserControl permettant de modifier une Didactique d'une Fiche Préparatoire
    /// </summary>
    public partial class UCDidactiqueFPModification : UCDidactiqueFP
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UCDidactiqueFPModification"/> class.
        /// </summary>
        public UCDidactiqueFPModification()
            : base()
        {
            InitializeComponent();

            this.InitializeData();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UCDidactiqueFPModification"/> class.
        /// </summary>
        /// <param name="didactique">The didactique.</param>
        public UCDidactiqueFPModification(DidactiqueFP didactique)
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
            this.cmbConditions.DataSource = DataRepository.Instance.Conditions.ToList();
            this.cmbConditions.DisplayMember = "Intitule";
            this.cmbConditions.ValueMember = "Id";

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

                List<Conditions> pas = DataRepository.Instance.Conditions.SelectById(this.Didactique.Conditions);
                if (pas != null && pas.Count > 0)
                {
                    this.cmbConditions.Text = pas[0].Intitule;
                }

                this.nudOrdre.Value = this.Didactique.Ordre.Value;

                this.txtPerformances.Text = this.Didactique.Performances;

                this.nudDuree.Value = this.Didactique.Duree.Value;

                this.txtMaterielLieu.Text = this.Didactique.LieuMateriel;
            }
        }


        /// <summary>
        /// Saves this instance.
        /// </summary>
        public override long Save()
        {
            this.Didactique.Conditions = (long)this.cmbConditions.SelectedValue;

            this.Didactique.Ordre = (int)this.nudOrdre.Value;
            this.Didactique.Performances = this.txtPerformances.Text;
            this.Didactique.DispositifSocial = (long)this.cmbDispositifSocial.SelectedValue;
            this.Didactique.Duree = (int)this.nudDuree.Value;
            this.Didactique.LieuMateriel = this.txtMaterielLieu.Text;

            if (!this.Didactique.Id.HasValue)
            {
                this.Didactique.Id = DataRepository.Instance.DidactiqueFP.CreateAndGetId(this.Didactique.Performances,
                                                    this.Didactique.DispositifSocial,
                                                    this.Didactique.Duree,
                                                    this.Didactique.LieuMateriel,
                                                    this.Didactique.Ordre,
                                                    this.Didactique.Conditions);
            }
            else
            {
                DataRepository.Instance.DidactiqueFP.Update(this.Didactique);
            }

            return this.Didactique.Id.Value;
        }
    }
}
