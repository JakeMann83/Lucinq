using Lucinq.Core.Enums;
using Lucinq.Core.QueryTypes;

namespace Lucinq.Core.Visitors
{
    public class FieldValueQueryVisitor : AbstractQueryVisitor<IFieldValueQuery>, IQueryBuilderVisitor
    {
        public FieldValueQueryVisitor(IFieldValueQuery query, Matches matches, string key) : base(query, matches, key)
        {
        }

        public FieldValueQueryVisitor(string field, string value, Matches matches, float? boost, bool? caseSensitive, string key)
            : this(new LucinqFieldValueQuery(), matches, key)
        {
            Query.Field = field;
            Query.Value = value;
            Query.CaseSensitive = caseSensitive;
            Query.Boost = boost;
        }
    }
}
