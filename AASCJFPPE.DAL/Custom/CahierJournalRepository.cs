using System;

namespace AASCJFPPE.DAL.Datas
{
    public partial interface ICahierJournalRepository
    {
        /// <summary>
        /// Creates the and get id.
        /// </summary>
        /// <param name="DateDebut">The date debut.</param>
        /// <param name="DateFin">The date fin.</param>
        /// <param name="DateJour">The date jour.</param>
        /// <param name="TrancheHoraire">The tranche horaire.</param>
        /// <param name="Discipline">The discipline.</param>
        /// <param name="NumeroSeance">The numero seance.</param>
        /// <param name="Objectifs">The objectifs.</param>
        /// <param name="DomaineActivite">The domaine activite.</param>
        /// <returns></returns>
        long CreateAndGetId(System.DateTime? DateDebut, System.DateTime? DateFin, System.DateTime? DateJour, System.String TrancheHoraire, System.Int64? Discipline, System.Int32? NumeroSeance, System.String Objectifs, System.Int64? DomaineActivite);
    }

    public partial class CahierJournalRepository
    {
        /// <summary>
        /// Creates the and get id.
        /// </summary>
        /// <param name="DateDebut">The date debut.</param>
        /// <param name="DateFin">The date fin.</param>
        /// <param name="DateJour">The date jour.</param>
        /// <param name="TrancheHoraire">The tranche horaire.</param>
        /// <param name="Discipline">The discipline.</param>
        /// <param name="NumeroSeance">The numero seance.</param>
        /// <param name="Objectifs">The objectifs.</param>
        /// <param name="DomaineActivite">The domaine activite.</param>
        /// <returns></returns>
        public long CreateAndGetId(System.DateTime? DateDebut, System.DateTime? DateFin, System.DateTime? DateJour, System.String TrancheHoraire, System.Int64? Discipline, System.Int32? NumeroSeance, System.String Objectifs, System.Int64? DomaineActivite)
        {
            long id = -1;

            this.Create(DateDebut, DateFin, DateJour, TrancheHoraire, Discipline, NumeroSeance, Objectifs, DomaineActivite);

            id = DataRepository.ExecuteScalar<long>("SELECT @@IDENTITY FROM CahierJournal");
            //using (var command = EntityBase.CreateCommand())
            //{
            //    command.CommandText = "SELECT @@IDENTITY FROM CahierJournal";
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
