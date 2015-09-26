using System;

namespace AASCJFPPE.DAL.Datas
{
    public partial interface IFichePreparatoireRepository
    {
        /// <summary>
        /// Creates the and get id.
        /// </summary>
        /// <param name="Discipline">The discipline.</param>
        /// <param name="DomaineActivite">The domaine activite.</param>
        /// <param name="Niveau">The niveau.</param>
        /// <param name="Sequence">The sequence.</param>
        /// <param name="NumeroSeance">The numero seance.</param>
        /// <param name="TitreSeance">The titre seance.</param>
        /// <param name="Date">The date.</param>
        /// <param name="CompetencesVisees">The competences visees.</param>
        /// <param name="CompetencesRequises">The competences requises.</param>
        /// <param name="Objectifs">The objectifs.</param>
        /// <param name="EvaluationEnvisagee">The evaluation envisagee.</param>
        /// <param name="ComplementEvaluationEnvisagee">The complement evaluation envisagee.</param>
        /// <param name="BilanPositif">The bilan positif.</param>
        /// <param name="BilanNegatif">The bilan negatif.</param>
        /// <returns></returns>
        long CreateAndGetId(Int64? Discipline, Int64? DomaineActivite, Int64? Niveau, String Sequence, Int32? NumeroSeance, String TitreSeance, DateTime? Date, String CompetencesVisees, String CompetencesRequises, String Objectifs, Int64? EvaluationEnvisagee, String ComplementEvaluationEnvisagee, String BilanPositif, String BilanNegatif);
    }

    public partial class FichePreparatoireRepository
    {
        /// <summary>
        /// Creates the and get id.
        /// </summary>
        /// <param name="Discipline">The discipline.</param>
        /// <param name="DomaineActivite">The domaine activite.</param>
        /// <param name="Niveau">The niveau.</param>
        /// <param name="Sequence">The sequence.</param>
        /// <param name="NumeroSeance">The numero seance.</param>
        /// <param name="TitreSeance">The titre seance.</param>
        /// <param name="Date">The date.</param>
        /// <param name="CompetencesVisees">The competences visees.</param>
        /// <param name="CompetencesRequises">The competences requises.</param>
        /// <param name="Objectifs">The objectifs.</param>
        /// <param name="EvaluationEnvisagee">The evaluation envisagee.</param>
        /// <param name="ComplementEvaluationEnvisagee">The complement evaluation envisagee.</param>
        /// <param name="BilanPositif">The bilan positif.</param>
        /// <param name="BilanNegatif">The bilan negatif.</param>
        /// <returns></returns>
        public long CreateAndGetId(Int64? Discipline, Int64? DomaineActivite, Int64? Niveau, String Sequence, Int32? NumeroSeance, String TitreSeance, DateTime? Date, String CompetencesVisees, String CompetencesRequises, String Objectifs, Int64? EvaluationEnvisagee, String ComplementEvaluationEnvisagee, String BilanPositif, String BilanNegatif)
        {
            long id = -1;

            this.Create(Discipline, DomaineActivite, Niveau, Sequence, NumeroSeance, TitreSeance, Date, CompetencesVisees, CompetencesRequises, Objectifs, EvaluationEnvisagee, ComplementEvaluationEnvisagee, BilanPositif, BilanNegatif);

            id = DataRepository.ExecuteScalar<long>("SELECT @@IDENTITY FROM FichePreparatoire");

            return id;
        }
    }
}
