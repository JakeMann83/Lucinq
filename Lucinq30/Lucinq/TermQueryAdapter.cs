using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucinq.Core.Querying;
using Lucinq.Core.QueryTypes;
using Lucinq.Extensions;

namespace Lucinq
{
    public class TermQueryAdapter : IQueryAdapter<ITermQuery, TermQuery>
    {
        public TermQuery GetQuery(ITermQuery query)
        {
            string value = GetValue(query);
            TermQuery termQuery = new TermQuery(new Term(query.Field, value));
            if (query.Boost.HasValue)
            {
                termQuery.SetBoost(query.Boost.Value);
            }

            return termQuery;
        }

        private string GetValue(ITermQuery query)
        {
            string value = query.Value;
            if (!(query.CaseSensitive ?? false))
            {
                value = value.ToLowerInvariant();
            }

            return value;
        }
    }
}
