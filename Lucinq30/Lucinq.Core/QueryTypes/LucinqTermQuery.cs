using Lucinq.Core.Querying;

namespace Lucinq.Core.QueryTypes
{
    public class LucinqTermQuery : ITermQuery
    {
        private IAdapterRepository<ITermQuery> repo;

        public float? Boost { get; set; }

        public string Field { get; set; }

        public string Value { get; set; }

        public bool? CaseSensitive { get; set; }

        public TQuery GetNative<TQuery>()
        {
            IQueryAdapter<ITermQuery, TQuery> adapter = repo.GetAdapterFromQuery<TQuery>();
            return adapter.GetQuery(this);
        }

        private string GetValue()
        {
            string value = Value;
            if (!(CaseSensitive ?? false))
            {
                value = value.ToLowerInvariant();
            }

            return value;
        }
    }
}
