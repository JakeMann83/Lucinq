using Lucinq.Core.QueryTypes;

namespace Lucinq.Core.Visitors
{
    public interface IQueryProvider<out TInterface> where TInterface : class, IQuery 
    {
        TInterface GetQuery();
    }
}
