using Lucene.Net.Search;
using Lucinq.Core.Querying;

namespace Lucinq.Interfaces
{
    public interface IQueryBuilder : IQueryBuilderGroup<IQueryBuilder>, IHierarchicalQueryGroup<IQueryBuilder>, IQueryBuilderApiSpecific, IQueryBuilderApiVersionSpecific, ICoreQueryBuilder
    {
	    void Filter(Filter filter);

	    Filter CurrentFilter { get; }
    }
}
