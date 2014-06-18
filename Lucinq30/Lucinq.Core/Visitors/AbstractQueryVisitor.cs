using Lucinq.Core.Enums;
using Lucinq.Core.Querying;
using Lucinq.Core.QueryTypes;

namespace Lucinq.Core.Visitors
{
    public abstract class AbstractQueryVisitor<TInterface> : IQueryProvider<TInterface> where TInterface : class, IQuery
    {
        protected AbstractQueryVisitor(TInterface query, Matches matches, string key)
        {
            Query = query;
            Matches = matches;
            Key = key;
        } 

        protected TInterface Query { get; private set; }

        public string Key { get; private set; }

        public Matches Matches { get; private set; }

        public virtual void VisitQueryBuilder(ICoreQueryBuilder queryBuilder)
        {
            queryBuilder.Add(Query, Matches, Key);
        }

        public virtual TInterface GetQuery()
        {
            return Query;
        }
    }
}
