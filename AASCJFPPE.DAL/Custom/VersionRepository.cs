using System;

namespace AASCJFPPE.DAL.Datas
{
    public partial interface IVersionRepository
    {
        /// <summary>
        /// Gets the max numero.
        /// </summary>
        /// <returns></returns>
        String GetMaxNumero();
    }

    public partial class VersionRepository
    {
        /// <summary>
        /// Gets the max numero.
        /// </summary>
        /// <returns></returns>
        public String GetMaxNumero()
        {
            String numero = "0.0.0";

            try
            {
                numero = DataRepository.ExecuteScalar<String>("SELECT MAX(Numero) FROM Version");
            }
            catch { }

            return numero;
        }
    }
}
