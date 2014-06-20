using Lucene.Net.Search;
using Lucinq.Core.Querying;
using Lucinq.Core.Visitors;

namespace Lucinq.Adapters
{
    public class BooleanQueryAdapter : IQueryAdapter<IGroupedQuery, BooleanQuery>
    {
        public BooleanQuery GetQuery(IGroupedQuery termQuery)
        {
            BooleanQuery booleanQuery = new BooleanQuery();

            foreach (var subGroup in termQuery.Groups)
            {
                GetQuery(subGroup);
            }

            return booleanQuery;
        }
    }
}
