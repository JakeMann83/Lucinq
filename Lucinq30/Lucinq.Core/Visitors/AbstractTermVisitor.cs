using Lucinq.Core.Enums;
using Lucinq.Core.QueryTypes;

namespace Lucinq.Core.Visitors
{
    public abstract class AbstractTermVisitor : IQueryProviderVisitor<ITermQuery>
    {
        protected ITermQuery Query { get; private set; }

        protected AbstractTermVisitor()
        {
            Query = new LucinqTermQuery();
        } 

        protected AbstractTermVisitor(string field, string value, Matches matches) : this()
        {
            Query.Field = field;
            Query.Value = value;
            Matches = matches;
        }

        protected AbstractTermVisitor(string field, string value, Matches matches, float? boost) : this(field, value, matches)
        {
            Query.Boost = boost;
        }

        protected AbstractTermVisitor(string field, string value, Matches matches, bool? caseSensitive)
            : this(field, value, matches)
        {
            if (caseSensitive.HasValue)
            {
                Query.CaseSensitive = caseSensitive.Value;
            }
        }

        protected AbstractTermVisitor(string field, string value, Matches matches, float? boost, bool? caseSensitive)
            : this(field, value, matches, caseSensitive)
        {
            Query.Boost = boost;
        }

        public Matches Matches { get; private set; }

        public ITermQuery GetQuery()
        {
            return Query;
        }

        public TQuery GetNativeQuery<TQuery>()
        {
            return Query.GetNative<TQuery>();
        }
    }
}
