using Lucene.Net.Search;
using Lucinq.Core.Enums;
using Lucinq.Core.Interfaces;
using Lucinq.Core.Querying;
using Lucinq.Core.Visitors;
using Lucinq.Extensions;
using Lucinq.Interfaces;

namespace Lucinq.Adapters
{
    public class BooleanQueryAdapter : IBooleanQueryAdapter<BooleanQuery>
    {
        BooleanQuery booleanQuery = new BooleanQuery();

        protected IQueryBuilder QueryBuilder { get; private set; }

        public BooleanQueryAdapter(IQueryBuilder queryBuilder)
        {
            QueryBuilder = queryBuilder;
        }

        public BooleanQuery GetQuery()
        {
            foreach (IQueryReference query in QueryBuilder.Queries.Values)
            {
                VisitQuery(query);
                AddNative(query);
            }

            foreach (IQueryBuilder query in QueryBuilder.Groups)
            {
                AddQuery(query.Build(), query.Occur);
            }

            return booleanQuery;
        }

        private void AddNative(IQueryReference query)
        {
            IQueryReference<Query> queryReference = query as IQueryReference<Query>;
            if (queryReference == null)
            {
                return;
            }

            AddQuery(queryReference.Query, query.Occur);
        }

        private void VisitQuery(IQueryReference query)
        {
            IQueryReference<IQueryBuilderVisitor> visitorReference = query as IQueryReference<IQueryBuilderVisitor>;
            if (visitorReference == null)
            {
                return;
            }

            visitorReference.Query.VisitQueryBuilder(this);
        }

        public void AddQuery<TNative>(TNative query, Matches matches)
        {
            var actualQuery = query as Query;
            if (actualQuery == null)
            {
                return;
            }

            booleanQuery.Add(actualQuery, matches.GetLuceneOccurance());
        }
    }
}
