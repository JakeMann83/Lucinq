using Lucinq.Core.Enums;
using Lucinq.Core.Querying;
using Lucinq.Core.QueryTypes;

namespace Lucinq.Core.Visitors
{
    public abstract class AbstractQueryVisitor<TInterface, TNative> : IQueryBuilderVisitor, IQueryProvider<TInterface> where TInterface : class, IQuery
    {
        public IQueryAdapter<TInterface, TNative> Adapter { get; private set; }

        protected AbstractQueryVisitor(IQueryAdapter<TInterface, TNative> adapter, TInterface query, Matches matches)
        {
            Query = query;
            Matches = matches;
            Adapter = adapter;
        } 

        protected TInterface Query { get; private set; }

        public string Key { get; private set; }

        public Matches Matches { get; private set; }

        public virtual void VisitQueryBuilder<TGroupedQuery>(TGroupedQuery queryBuilder) where TGroupedQuery : IBooleanQueryAdapter
        {
            queryBuilder.AddQuery(Adapter.GetQuery(Query), Matches);
        }

        public virtual TInterface GetQuery()
        {
            return Query;
        }
    }
}
