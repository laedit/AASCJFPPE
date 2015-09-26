using System;

namespace AASCJFPPE.DAL.Datas
{
    public partial interface IDidactiqueFPRepository
    {
        /// <summary>
        /// Creates the and get id.
        /// </summary>
        /// <param name="Performances">The performances.</param>
        /// <param name="DispositifSocial">The dispositif social.</param>
        /// <param name="Duree">The duree.</param>
        /// <param name="LieuMateriel">The lieu materiel.</param>
        /// <param name="Ordre">The ordre.</param>
        /// <param name="Conditions">The conditions.</param>
        /// <returns></returns>
        long CreateAndGetId(String Performances, Int64? DispositifSocial, Int32? Duree, String LieuMateriel, Int32? Ordre, Int64? Conditions);
    }

    public partial class DidactiqueFPRepository
    {
        /// <summary>
        /// Creates the and get id.
        /// </summary>
        /// <param name="Performances">The performances.</param>
        /// <param name="DispositifSocial">The dispositif social.</param>
        /// <param name="Duree">The duree.</param>
        /// <param name="LieuMateriel">The lieu materiel.</param>
        /// <param name="Ordre">The ordre.</param>
        /// <param name="Conditions">The conditions.</param>
        /// <returns></returns>
        public long CreateAndGetId(String Performances, Int64? DispositifSocial, Int32? Duree, String LieuMateriel, Int32? Ordre, Int64? Conditions)
        {
            long id = -1;

            this.Create(Performances, DispositifSocial, Duree, LieuMateriel, Ordre, Conditions);

            id = DataRepository.ExecuteScalar<long>("SELECT @@IDENTITY FROM DidactiqueFP");
            
            return id;
        }
    }
}
