using System;
using Lucene.Net.Search;
using Lucinq.Adapters;
using Lucinq.Core.Enums;
using Lucinq.Core.Interfaces;
using Lucinq.Core.Querying;
using Lucinq.Core.QueryTypes;
using Lucinq.Extensions;
using Lucinq.Interfaces;

namespace Lucinq.Querying
{
    public partial class QueryBuilder : AbstractQueryBuilder<IQueryBuilder>, IQueryBuilder
    {
        #region [ Build Methods ]

        /// <summary>
        /// Adds a query to the current group
        /// </summary>
        /// <param name="query">The query to add</param>
        /// <param name="occur">The occur value for the query</param>
        /// <param name="key">A key to allow manipulation from the dictionary later on (a default key will be generated if none is specified</param>
        public virtual void Add(Query query, Matches occur, string key = null)
        {
            key = GetQueryKey(key);
            SetOccurValue(this, ref occur);
            IQueryReference<Query> queryReference = new NativeQueryReference { Occur = occur, Query = query };
            Queries.Add(key, queryReference);
        }

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
            BooleanQuery booleanQuery = new BooleanQuery();
            foreach (IQueryReference query in Queries.Values)
            {
                AddNativeQuery(query, booleanQuery);
                AddLucinqQuery(query, booleanQuery);
            }

            foreach (IQueryBuilder query in Groups)
            {
                booleanQuery.Add(query.Build(), query.Occur.GetLuceneOccurance());
            }

            BuildSort();

            return booleanQuery;
        }

        private static void AddNativeQuery(IQueryReference query, BooleanQuery booleanQuery)
        {
            IQueryReference<Query> actualReference = query as IQueryReference<Query>;
            if (actualReference == null)
            {
                return;
            }

            booleanQuery.Add(actualReference.Query, query.Occur.GetLuceneOccurance());
        }

        private static void AddLucinqQuery(IQueryReference query, BooleanQuery booleanQuery)
        {
            IQueryReference<IQuery> actualReference = query as IQueryReference<IQuery>;
            if (actualReference == null)
            {
                return;
            }

            // todo: solve this

            booleanQuery.Add(actualReference.Query.GetNative(new WildcardQueryAdapter()), query.Occur.GetLuceneOccurance());
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
