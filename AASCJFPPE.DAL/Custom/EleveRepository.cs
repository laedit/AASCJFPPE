using System;

namespace AASCJFPPE.DAL.Datas
{
    public partial interface IEleveRepository
    {

        /// <summary>
        /// Create new record without specifying a primary key and return the id created
        /// </summary>
        /// <param name="Nom">The nom.</param>
        /// <param name="Prenom">The prenom.</param>
        /// <param name="Niveau">The niveau.</param>
        /// <param name="Informations">The informations.</param>
        /// <returns>The new Id</returns>
        long CreateAndGetId(System.String Nom, System.String Prenom, System.Int64? Niveau, System.String Informations);

        /// <summary>
        /// Create new record without specifying a primary key and return the id created
        /// </summary>
        /// <param name="eleve">The eleve.</param>
        /// <returns>The new Id</returns>
        long CreateAndGetId(Eleve eleve);

    }

    public partial class EleveRepository
    {
        /// <summary>
        /// Create new record without specifying a primary key and return the id created
        /// </summary>
        /// <param name="Nom">The nom.</param>
        /// <param name="Prenom">The prenom.</param>
        /// <param name="Niveau">The niveau.</param>
        /// <param name="Informations">The informations.</param>
        /// <returns>The new Id</returns>
        public long CreateAndGetId(System.String Nom, System.String Prenom, System.Int64? Niveau, System.String Informations)
        {
            long id = -1;

            this.Create(Nom, Prenom, Niveau, Informations);

            id = DataRepository.ExecuteScalar<long>("SELECT @@IDENTITY FROM Eleve");
            
            return id;
        }

        /// <summary>
        /// Create new record without specifying a primary key and return the id created
        /// </summary>
        /// <param name="eleve">The eleve.</param>
        /// <returns>The new Id</returns>
        public long CreateAndGetId(Eleve eleve)
        {
            long id = -1;

            this.Create(eleve.Nom, eleve.Prenom, eleve.Niveau, eleve.Informations);

            id = DataRepository.ExecuteScalar<long>("SELECT @@IDENTITY FROM Eleve");
            
            return id;
        }
    }
}
