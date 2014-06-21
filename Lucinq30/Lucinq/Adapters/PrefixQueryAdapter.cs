using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucinq.Core.Adapters;
using Lucinq.Core.QueryTypes;
using Lucinq.Extensions;

namespace Lucinq.Adapters
{
    public class PrefixQueryAdapter : AbstractFieldValueQueryAdapter<IFieldValueQuery, PrefixQuery>
    {
        public override PrefixQuery GetQuery(IFieldValueQuery fieldValueQuery)
        {
            string value = GetValue(fieldValueQuery);
            PrefixQuery query = new PrefixQuery(new Term(fieldValueQuery.Field, value));
            if (fieldValueQuery.Boost.HasValue)
            {
                query.SetBoost(fieldValueQuery.Boost.Value);
            }

            return query;
        }
    }
}
