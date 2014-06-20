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
            IBooleanQueryAdapter<BooleanQuery> booleanQueryAdapter = new BooleanQueryAdapter(this);
            
            BuildSort();

            return booleanQueryAdapter.GetQuery();
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
