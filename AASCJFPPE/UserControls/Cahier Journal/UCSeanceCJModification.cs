using System;
using AASCJFPPE.DAL.Datas;
using AASCJFPPE.Misc;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

namespace AASCJFPPE.UserControls.Cahier_Journal
{
    /// <summary>
    /// UserControl permettant la modification d'une séance du Cahier Journal
    /// </summary>
    public partial class UCSeanceCJModification : UCSeanceCJ
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UCSeanceCJModification"/> class.
        /// </summary>
        public UCSeanceCJModification()
            : base()
        {
            InitializeComponent();

            this.cmbDiscipline.DisplayMember = "Intitule";
            this.cmbDiscipline.ValueMember = "Id";

            this.cmbDiscipline.DataSource = DataRepository.Instance.Discipline.ToList().OrderBy(d => d.Intitule).ToList();

            this.InitializeSeanceDatas();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UCSeanceCJModification"/> class.
        /// </summary>
        /// <param name="seance">The seance.</param>
        public UCSeanceCJModification(CahierJournal seance)
            : base(seance)
        {
            InitializeComponent();

            this.AddDidactiquePanel(new DidactiqueCJ());

            this.cmbDiscipline.DisplayMember = "Intitule";
            this.cmbDiscipline.ValueMember = "Id";

            this.cmbDiscipline.DataSource = DataRepository.Instance.Discipline.ToList().OrderBy(d => d.Intitule).ToList();

            this.InitializeSeanceDatas();
        }

        /// <summary>
        /// Initializes the seance datas.
        /// </summary>
        protected override void InitializeSeanceDatas()
        {
            if (this.Seance.Id.HasValue)
            {
                this.txtTrancheHoraire.Text = this.Seance.TrancheHoraire;

                this.nudNumero.Value = this.Seance.NumeroSeance.Value;

                this.txtObjectifs.Text = this.Seance.Objectifs;

                this.cmbDiscipline.Text = DataRepository.Instance.Discipline.SelectById(this.Seance.Discipline)[0].Intitule;

                List<DomaineActivite> das = DataRepository.Instance.DomaineActivite.SelectById(this.Seance.DomaineActivite);
                if (das != null && das.Count > 0)
                {
                    this.cmbDomainActivite.Text = das[0].Intitule;
                }

                this.InitializeDidactiques(this.Seance.Didactiques);
            }
        }

        /// <summary>
        /// Gets the didactique panel.
        /// </summary>
        /// <returns></returns>
        protected override UCDidactiqueCJ GetDidactiquePanel(DidactiqueCJ didactique)
        {
            return new UCDidactiqueCJModification(didactique);
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cmbDiscipline control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cmbDiscipline_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbDomainActivite.DisplayMember = "Intitule";
            this.cmbDomainActivite.ValueMember = "Id";
            List<DomaineActivite> das = DataRepository.Instance.DomaineActivite.SelectByDiscipline((long)this.cmbDiscipline.SelectedValue);
            if (das != null && das.Count > 0)
            {
                this.cmbDomainActivite.DataSource = das.OrderBy(da => da.Intitule).ToList();
                this.cmbDomainActivite.Enabled = true;
            }
            else
            {
                this.cmbDomainActivite.DataSource = null;
                this.cmbDomainActivite.Items.Clear();
                this.cmbDomainActivite.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnAjouterDidactique control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnAjouterDidactique_Click(object sender, EventArgs e)
        {
            this.AddDidactiquePanel(new DidactiqueCJ());
            this.btnDeleteLastDidactique.Enabled = true;
        }


        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <param name="dateDebut">The date debut.</param>
        /// <param name="dateFin">The date fin.</param>
        /// <param name="dateJour">The date jour.</param>
        public override void Save(DateTime dateDebut, DateTime dateFin, DateTime dateJour)
        {
            // Save
            this.Seance.DateDebut = dateDebut;
            this.Seance.DateFin = dateFin;
            this.Seance.DateJour = dateJour;
            this.Seance.Discipline = (long?)this.cmbDiscipline.SelectedValue;
            this.Seance.DomaineActivite = (long?)this.cmbDomainActivite.SelectedValue;
            this.Seance.NumeroSeance = (int)this.nudNumero.Value;
            this.Seance.Objectifs = this.txtObjectifs.Text;
            this.Seance.TrancheHoraire = this.txtTrancheHoraire.Text;

            if (this.Seance.Id.HasValue)
            {
                // Update
                DataRepository.Instance.CahierJournal.Update(this.Seance);
            }
            else
            {
                // Insert
                this.Seance.Id = DataRepository.Instance.CahierJournal.CreateAndGetId(this.Seance.DateDebut,
                                                    this.Seance.DateFin,
                                                    this.Seance.DateJour,
                                                    this.Seance.TrancheHoraire,
                                                    this.Seance.Discipline,
                                                    this.Seance.NumeroSeance,
                                                    this.Seance.Objectifs,
                                                    this.Seance.DomaineActivite);
            }
            
            // Delete previous links
            DataRepository.Instance.Link_CJ_DidactiqueCJ.DeleteByCJ_Id(this.Seance.Id);

            for (int i = this.pnlDidactiques.Controls.Count - 1; i >= 0; i--)
            {
                UCDidactiqueCJ ucDidactiqueCJ = this.pnlDidactiques.Controls[i] as UCDidactiqueCJ;
                if (ucDidactiqueCJ != null)
                {
                    long didactiqueId = ucDidactiqueCJ.Save();

                    //  Save Link
                    DataRepository.Instance.Link_CJ_DidactiqueCJ.Create(this.Seance.Id, didactiqueId);
                }
            }
        }

        private void pnlDisciplineEtDomaineActivite_Resize(object sender, EventArgs e)
        {
            this.lblDisciplineEtDomaineActivite.Left = (this.pnlDisciplineEtDomaineActivite.Width - this.lblDisciplineEtDomaineActivite.Width) / 2;
            this.cmbDomainActivite.Left = this.pnlDisciplineEtDomaineActivite.Width / 2;
        }

        private void btnDeleteLastDidactique_Click(object sender, EventArgs e)
        {
            if (this.pnlDidactiques.Controls.Count > 1)
            {
                this.pnlDidactiques.Controls.RemoveAt(0);

                if (this.pnlDidactiques.Controls.Count == 1)
                {
                    this.btnDeleteLastDidactique.Enabled = false;
                }
            }
        }
    }
}
