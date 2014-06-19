using Lucinq.Core.Querying;
using Lucinq.Core.QueryTypes;

namespace Lucinq.Core.Adapters
{
    public abstract class AbstractQueryAdapter<TInterface, TQuery> : IQueryAdapter<TInterface, TQuery> where TInterface : IQuery
    {
        public abstract TQuery GetQuery(TInterface query);
    }
}
