using Lucinq.Core.Enums;
using Lucinq.Core.QueryTypes;

namespace Lucinq.Core.Visitors
{
    public class WildcardQueryVisitor : AbstractQueryVisitor<IFieldValueQuery>, IQueryBuilderVisitor
    {
        public WildcardQueryVisitor(IFieldValueQuery query, Matches matches, string key)
            : base(query, matches, key)
        {
        }

        public WildcardQueryVisitor(string field, string value, Matches matches, float? boost, bool? caseSensitive, string key) : this(null, matches, key)
        {
            Query.Field = field;
            Query.Value = value;
            Query.CaseSensitive = caseSensitive;
            Query.Boost = boost;
        }
    }
}
