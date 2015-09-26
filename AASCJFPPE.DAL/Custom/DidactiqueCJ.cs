using System;
using System.Linq;

namespace AASCJFPPE.DAL.Datas
{
    public partial class DidactiqueCJ
    {
        /// <summary>
        /// Gets the phase apprentissage intitule.
        /// </summary>
        /// <value>The phase apprentissage intitule.</value>
        public String PhaseApprentissageIntitule
        {
            get
            {
                if (this.PhaseApprentissage.HasValue)
                {
                    return DataRepository.Instance.PhaseApprentissage.SelectById(this._PhaseApprentissage).First().Intitule;
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
        public DidactiqueCJ()
        {
            this.Realise = false;
            this.Ordre = 1;
            this.Duree = 0;
        }
    }
}
