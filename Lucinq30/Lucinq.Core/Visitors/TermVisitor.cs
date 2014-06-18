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

        public TermVisitor(ITermQuery query, Matches matches, string key)
        {
            Query = query;
            Matches = matches;
            Key = key;
        }

        public TermVisitor(string field, string value, Matches matches, float? boost, bool? caseSensitive, string key) : this(new LucinqTermQuery(), matches, key)
        {
            Query.Field = field;
            Query.Value = value;
            Query.CaseSensitive = caseSensitive;
            Query.Boost = boost;
        }

        public Matches Matches { get; private set; }

        public string Key { get; private set; }

        public ITermQuery GetQuery()
        {
            return Query;
        }

        public void VisitQueryBuilder(ICoreQueryBuilder queryBuilder)
        {
            queryBuilder.Add(Query, Matches, Key);
        }
    }
}
