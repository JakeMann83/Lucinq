using Lucene.Net.Search;
using Lucinq.Adapters;
using Lucinq.Core.Interfaces;
using Lucinq.Core.Querying;
using Lucinq.Core.Visitors;
using Lucinq.Extensions;
using Lucinq.Interfaces;

namespace Lucinq.Querying
{
    public partial class QueryBuilder : AbstractQueryBuilder<IQueryBuilder>, IQueryBuilder
    {
        #region [ Build Methods ]

        private void Add(Filter filter)
        {
            CurrentFilter = filter;
        }

        /// <summary>
        /// Builds the query
        /// </summary>
        /// <returns>The query built from the queries and groups that have been added</returns>
        public virtual Query Build()
        {
            IQueryAdapter<IGroupedQuery, BooleanQuery> booleanQueryAdapter = new BooleanQueryAdapter();
            IGroupedQuery groupedQuery = null;
            foreach (IQueryReference query in Queries.Values)
            {
                VisitQuery(query, groupedQuery);
            }

            /*foreach (IQueryBuilder query in Groups)
            {
                groupedQuery.Add(query.Build(), query.Occur.GetLuceneOccurance());
            }*/

            BuildSort();

            return booleanQueryAdapter.GetQuery(groupedQuery);
        }

        private void VisitQuery(IQueryReference query, IGroupedQuery groupedQuery)
        {
            IQueryReference<IQueryBuilderVisitor> visitorReference = query as IQueryReference<IQueryBuilderVisitor>;
            if (visitorReference == null)
            {
                return;
            }

            visitorReference.Query.VisitQueryBuilder(groupedQuery);
        }

        public virtual void BuildSort()
        {
            if (SortFields.Count == 0)
            {
                return;
            }
            CurrentSort = new Sort(SortFields.ToArray());
        }

        #endregion
    }
}
