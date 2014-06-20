using Lucinq.Core.Querying;

namespace Lucinq.Interfaces
{
    public interface IQueryBuilder : IQueryBuilderGroup<IQueryBuilder>, IQueryBuilderApiSpecific, IQueryBuilderApiVersionSpecific
    {
    }
}
