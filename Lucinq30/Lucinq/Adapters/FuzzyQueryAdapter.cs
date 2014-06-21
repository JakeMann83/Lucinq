using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucinq.Core.Adapters;
using Lucinq.Core.QueryTypes;
using Lucinq.Extensions;

namespace Lucinq.Adapters
{
    public class FuzzyQueryAdapter : AbstractFieldValueQueryAdapter<IFieldValueQuery, FuzzyQuery>
    {
        public override FuzzyQuery GetQuery(IFieldValueQuery fieldValueQuery)
        {
            string value = GetValue(fieldValueQuery);
            FuzzyQuery query = new FuzzyQuery(new Term(fieldValueQuery.Field, value));
            if (fieldValueQuery.Boost.HasValue)
            {
                query.SetBoost(fieldValueQuery.Boost.Value);
            }

            return query;
        }
    }
}
