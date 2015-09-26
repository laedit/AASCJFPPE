using System;

namespace AASCJFPPE.DAL.Datas
{
    public partial interface IDidactiqueCJRepository
    {
        long CreateAndGetId(System.Int64? PhaseApprentissage, System.Boolean? Realise, System.Int32? Ordre, System.String Deroulement, System.Int64? DispositifSocial, System.Int32? Duree, System.String LieuMateriel);
    }

    public partial class DidactiqueCJRepository
    {
        public long CreateAndGetId(System.Int64? PhaseApprentissage, System.Boolean? Realise, System.Int32? Ordre, System.String Deroulement, System.Int64? DispositifSocial, System.Int32? Duree, System.String LieuMateriel)
        {
            long id = -1;

            this.Create(PhaseApprentissage, Realise, Ordre, Deroulement, DispositifSocial, Duree, LieuMateriel);

            id = DataRepository.ExecuteScalar<long>("SELECT @@IDENTITY FROM DidactiqueCJ");
            //using (var command = EntityBase.CreateCommand())
            //{
            //    command.CommandText = "SELECT @@IDENTITY FROM DidactiqueCJ";
            //    object result = command.ExecuteScalar();
            //    if (result != DBNull.Value && result != null)
            //    {
            //        id = Convert.ToInt64(result);
            //    }
            //}

            return id;
        }
    }
}
