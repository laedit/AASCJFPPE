using System;
using System.Collections.Generic;
using System.Linq;

namespace AASCJFPPE.DAL.Datas
{
    public partial class FichePreparatoire : ICloneable
    {
        /// <summary>
        /// Gets the discipline intitule.
        /// </summary>
        /// <value>The discipline intitule.</value>
        public String DisciplineIntitule
        {
            get
            {
                if (this.Discipline.HasValue)
                {
                    return DataRepository.Instance.Discipline.SelectById(this.Discipline).First().Intitule;
                }
                else
                {
                    return String.Empty;
                }
            }
        }

        /// <summary>
        /// Gets the domaine activite intitule.
        /// </summary>
        /// <value>The domaine activite intitule.</value>
        public String DomaineActiviteIntitule
        {
            get
            {
                if (this.DomaineActivite.HasValue)
                {
                    return DataRepository.Instance.DomaineActivite.SelectById(this.DomaineActivite).First().Intitule;
                }
                else
                {
                    return String.Empty;
                }
            }
        }

        /// <summary>
        /// Gets the niveau intitule.
        /// </summary>
        /// <value>The niveau intitule.</value>
        public String NiveauIntitule
        {
            get
            {
                if (this.Niveau.HasValue)
                {
                    return DataRepository.Instance.Niveau.SelectById(this.Niveau).First().Intitule;
                }
                else
                {
                    return String.Empty;
                }
            }
        }

        /// <summary>
        /// Gets the evaluation envisagée intitule.
        /// </summary>
        /// <value>The evaluation envisagée intitule.</value>
        public String EvaluationEnvisageeIntitule
        {
            get
            {
                if (this.EvaluationEnvisagee.HasValue)
                {
                    return DataRepository.Instance.EvaluationEnvisagee.SelectById(this.EvaluationEnvisagee).First().Intitule;
                }
                else
                {
                    return String.Empty;
                }
            }
        }

        /// <summary>
        /// Gets the didactiques.
        /// </summary>
        /// <value>The didactiques.</value>
        public List<DidactiqueFP> Didactiques
        {
            get
            {
                List<DidactiqueFP> didactiques = new List<DidactiqueFP>();

                if (this._Id.HasValue)
                {
                    Link_FP_DidactiqueFPRepository lfpdr = new Link_FP_DidactiqueFPRepository();
                    List<Link_FP_DidactiqueFP> linkDidactiques = lfpdr.SelectByFP_id(this._Id);

                    if (linkDidactiques != null)
                    {
                        DidactiqueFPRepository dfpr = new DidactiqueFPRepository();
                        foreach (Link_FP_DidactiqueFP linkDidactique in linkDidactiques)
                        {
                            didactiques.Add(dfpr.SelectById(linkDidactique.DidactiqueFP_Id)[0]);
                        }
                    }
                }
                return didactiques.OrderBy(d => d.Ordre).ToList();
            }

            set
            {
                Link_FP_DidactiqueFPRepository lfpdr = new Link_FP_DidactiqueFPRepository();
                lfpdr.DeleteByFP_id(this._Id);

                foreach (DidactiqueFP didactique in value)
                {
                    lfpdr.Create(new Link_FP_DidactiqueFP() { FP_id = this._Id, DidactiqueFP_Id = didactique.Id });
                }
            }
        }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public object Clone()
        {
            FichePreparatoire fp = new FichePreparatoire();
            fp._BilanNegatif = this._BilanNegatif.Clone().ToString();
            fp._BilanPositif = this._BilanPositif.Clone().ToString();
            fp._CompetencesRequises = this._CompetencesRequises.Clone().ToString();
            fp._CompetencesVisees = this._CompetencesVisees.Clone().ToString();
            fp._ComplementEvaluationEnvisagee = this._ComplementEvaluationEnvisagee.Clone().ToString();
            fp._Date = this._Date;
            fp._Discipline = this._Discipline;
            fp._DomaineActivite = this._DomaineActivite;
            fp._EvaluationEnvisagee = this._EvaluationEnvisagee;
            fp._Id = this._Id;
            fp._Niveau = this._Niveau;
            fp._NumeroSeance = this._NumeroSeance;
            fp._Objectifs = this._Objectifs.Clone().ToString();
            fp._Sequence = this._Sequence.Clone().ToString();
            fp._TitreSeance = this._TitreSeance.Clone().ToString();

            return fp;
        }
    }
}
