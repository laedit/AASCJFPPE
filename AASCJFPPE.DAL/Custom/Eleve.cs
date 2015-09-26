using System;
using System.Linq;

namespace AASCJFPPE.DAL.Datas
{
    public partial class Eleve
    {
        /// <summary>
        /// Gets or sets the niveau intitule.
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
    }
}
