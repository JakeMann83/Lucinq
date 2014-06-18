using Lucinq.Core.Enums;
using Lucinq.Core.IoC;
using Lucinq.Core.Querying;
using Lucinq.Core.QueryTypes;

namespace Lucinq.Core.Visitors
{
    public class TermVisitor : IQueryProviderVisitor<ITermQuery>
    {
        public IContainerManager ContainerManager { get; set; }

        public ITermQuery Query { get; private set; }

        public TermVisitor()
        {
            Query = new LucinqTermQuery();
        }

        public TermVisitor(string field, string value, Matches matches)
            : this()
        {
            Query.Field = field;
            Query.Value = value;
            Matches = matches;
        }

        public TermVisitor(string field, string value, Matches matches, float? boost)
            : this(field, value, matches)
        {
            Query.Boost = boost;
        }

        public TermVisitor(string field, string value, Matches matches, bool? caseSensitive)
            : this(field, value, matches)
        {
            Query.CaseSensitive = caseSensitive;
        }

        public TermVisitor(string field, string value, Matches matches, float? boost, bool? caseSensitive)
            : this(field, value, matches, caseSensitive)
        {
            Query.Boost = boost;
        }

        public Matches Matches { get; private set; }

        public ITermQuery GetQuery()
        {
            return Query;
        }

        public void VisitQueryBuilder(ICoreQueryBuilder queryBuilder)
        {
            queryBuilder.Add(Query, Matches);
        }
    }
}
