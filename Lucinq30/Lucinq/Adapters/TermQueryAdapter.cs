using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucinq.Core.Adapters;
using Lucinq.Core.QueryTypes;
using Lucinq.Extensions;

namespace Lucinq.Adapters
{
    public class TermQueryAdapter : AbstractFieldValueQueryAdapter<IFieldValueQuery, TermQuery>
    {
        public override TermQuery GetQuery(IFieldValueQuery fieldValueQuery)
        {
            string value = GetValue(fieldValueQuery);
            TermQuery query = new TermQuery(new Term(fieldValueQuery.Field, value));
            if (fieldValueQuery.Boost.HasValue)
            {
                query.SetBoost(fieldValueQuery.Boost.Value);
            }

            return query;
        }
    }
}
