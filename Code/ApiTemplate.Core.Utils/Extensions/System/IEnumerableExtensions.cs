using System.Linq;

namespace System.Collections.Generic
{
    public static class IEnumerableExtensions
    {
        #region Public Methods

        public static IEnumerable<TModel> GetRepeatedEntriesFromList<TModel>(this IEnumerable<TModel> entries, IEqualityComparer<TModel> comparer)
            where TModel : class
        {
            return entries.GroupBy(s => s, comparer).SelectMany(grp => grp.Skip(1));
        }

        /// <summary>
        /// Devuelve elementos distintos por una propiedad.
        /// source: https://github.com/morelinq/MoreLINQ
        /// </summary>
        /// <typeparam name="TSource">Tipo de los elementos</typeparam>
        /// <typeparam name="TKey">Tipo de la propiedad</typeparam>
        /// <param name="source">Elementos</param>
        /// <param name="keySelector">Propiedad por la que distinguir</param>
        /// <returns>Distintos elementos por la propiedad dada</returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            // separación de metodos para que la iteración se pueda evaluar lazy.
            return _(); IEnumerable<TSource> _()
            {
                var knownKeys = new HashSet<TKey>();
                foreach (var element in source)
                {
                    if (knownKeys.Add(keySelector(element)))
                        yield return element;
                }
            }
        }

        #endregion Public Methods
    }
}