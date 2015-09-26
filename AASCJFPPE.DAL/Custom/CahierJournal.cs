using System;
using System.Collections.Generic;
using System.Linq;

namespace AASCJFPPE.DAL.Datas
{
    public partial class CahierJournal
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
        /// Gets the didactiques.
        /// </summary>
        /// <value>The didactiques.</value>
        public List<DidactiqueCJ> Didactiques
        {
            get
            {
                List<DidactiqueCJ> didactiques = new List<DidactiqueCJ>();

                if (this._Id.HasValue)
                {
                    Link_CJ_DidactiqueCJRepository lcjdr = new Link_CJ_DidactiqueCJRepository();
                    List<Link_CJ_DidactiqueCJ> linkDidactiques = lcjdr.SelectByCJ_Id(this._Id);

                    DidactiqueCJRepository dcjr = new DidactiqueCJRepository();
                    foreach (Link_CJ_DidactiqueCJ linkDidactique in linkDidactiques)
                    {
                        didactiques.Add(dcjr.SelectById(linkDidactique.DidactiqueCJ_Id)[0]);
                    }
                }
                return didactiques;
            }

            set
            {
                Link_CJ_DidactiqueCJRepository lcjdr = new Link_CJ_DidactiqueCJRepository();
                lcjdr.DeleteByCJ_Id(this._Id);

                foreach (DidactiqueCJ didactique in value)
                {
                    lcjdr.Create(new Link_CJ_DidactiqueCJ() { CJ_Id = this._Id, DidactiqueCJ_Id = didactique.Id });
                }
            }
        }
    }
}
