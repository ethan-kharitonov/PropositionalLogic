namespace Core
{
    public static class GeneralPorpusExtensions
    {
        public static IEnumerable<IEnumerable<T>> GetAllSubcollections<T>(this IEnumerable<T> source)
        {
            if (!source.Any())
            {
                return Enumerable.Repeat(Enumerable.Empty<T>(), 1);
            }

            var element = source.Take(1);

            var haveNots = source.Skip(1).GetAllSubcollections();
            var haves = haveNots.Select(set => element.Concat(set));

            return haves.Concat(haveNots);
        }
    }
}
