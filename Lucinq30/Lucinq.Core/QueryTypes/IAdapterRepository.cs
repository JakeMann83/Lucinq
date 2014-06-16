using Lucinq.Core.Querying;

namespace Lucinq.Core.QueryTypes
{
    public interface IAdapterRepository<in TInterface>
    {
        IQueryAdapter<TInterface, TQuery> GetAdapter<TQuery>();
    }
}
