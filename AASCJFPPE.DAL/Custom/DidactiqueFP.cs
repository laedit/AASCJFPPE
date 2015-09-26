using System;
using System.Linq;

namespace AASCJFPPE.DAL.Datas
{
    public partial class DidactiqueFP
    {
        /// <summary>
        /// Gets the conditions intitule.
        /// </summary>
        /// <value>The conditions intitule.</value>
        public String ConditionsIntitule
        {
            get
            {
                if (this.Conditions.HasValue)
                {
                    return DataRepository.Instance.Conditions.SelectById(this._Conditions).First().Intitule;
                }
                else
                {
                    return String.Empty;
                }

            }
        }

        /// <summary>
        /// Gets the dispositif social intitule.
        /// </summary>
        /// <value>The dispositif social intitule.</value>
        public String DispositifSocialIntitule
        {
            get
            {
                if (this.DispositifSocial.HasValue)
                {
                    return DataRepository.Instance.DispositifSocial.SelectById(this._DispositifSocial).First().Intitule;
                }
                else
                {
                    return String.Empty;
                }

            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DidactiqueCJ"/> class.
        /// </summary>
        public DidactiqueFP()
        {
            this.Ordre = 1;
            this.Duree = 0;
        }
    }
}
