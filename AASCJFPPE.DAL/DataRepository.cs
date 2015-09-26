
using System;
namespace AASCJFPPE.DAL.Datas
{
    public partial class DataRepository
    {
        /// <summary>
        /// Instance of DataRepository
        /// </summary>
        private static DataRepository _dataRepository;

        /// <summary>
        /// Gets the instance of DataRepository.
        /// </summary>
        /// <value>The instance of DataRepository.</value>
        public static DataRepository Instance
        {
            get
            {
                if (_dataRepository == null)
                {
                    _dataRepository = new DataRepository();
                }

                return _dataRepository;
            }
        } // end property Instance

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string query)
        {
            int rowsAffected = -1;

            using (var command = EntityBase.CreateCommand())
            {
                command.CommandText = query;
                rowsAffected = command.ExecuteNonQuery();
            }

            return rowsAffected;
        } // end function ExecuteNonQuery


        /// <summary>
        /// Executes scalar.
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        public static T ExecuteScalar<T>(string query)
        {
            T result = default(T);

            using (var command = EntityBase.CreateCommand())
            {
                command.CommandText = query;
                object res = command.ExecuteScalar();
                if (res != DBNull.Value && res != null)
                {
                    result = (T)Convert.ChangeType(res, typeof(T));
                }
            }

            return result;
        } // end function ExecuteNonQuery
    }
}
