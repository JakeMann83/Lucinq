using Lucinq.Core.Enums;
using Lucinq.Core.QueryTypes;

namespace Lucinq.Core.Visitors
{
    public class TermQueryVisitor : AbstractQueryVisitor<ITermQuery>, IQueryBuilderVisitor
    {
        public TermQueryVisitor(ITermQuery query, Matches matches, string key) : base(query, matches, key)
        {
        }

        public TermQueryVisitor(string field, string value, Matches matches, float? boost, bool? caseSensitive, string key) : this(new LucinqTermQuery(), matches, key)
        {
            Query.Field = field;
            Query.Value = value;
            Query.CaseSensitive = caseSensitive;
            Query.Boost = boost;
        }
    }
}
