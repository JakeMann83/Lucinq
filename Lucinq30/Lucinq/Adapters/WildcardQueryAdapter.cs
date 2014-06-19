using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucinq.Core.Adapters;
using Lucinq.Core.QueryTypes;
using Lucinq.Extensions;

namespace Lucinq.Adapters
{
    public class WildcardQueryAdapter : AbstractFieldValueQueryAdapter<IFieldValueQuery, WildcardQuery>
    {
        public override WildcardQuery GetQuery(IFieldValueQuery fieldValueQuery)
        {
            string value = GetValue(fieldValueQuery);
            WildcardQuery query = new WildcardQuery(new Term(fieldValueQuery.Field, value));
            if (fieldValueQuery.Boost.HasValue)
            {
                query.SetBoost(fieldValueQuery.Boost.Value);
            }

            return query;
        }
    }
}
