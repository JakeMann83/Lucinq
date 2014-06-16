using Lucene.Net.Search;
using Lucinq.Core.Interfaces;

namespace Lucinq.Interfaces
{
    public interface IQueryBuilder : IQueryBuilderGroup, IQueryBuilderIndividual, IHierarchicalQueryGroup, IQueryBuilderApiSpecific, ICoreQueryBuilder
    {
	    void Filter(Filter filter);

	    Filter CurrentFilter { get; }
    }
}
