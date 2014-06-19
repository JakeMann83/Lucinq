using Lucinq.Core.Enums;
using Lucinq.Core.QueryTypes;

namespace Lucinq.Core.Visitors
{
    public interface IBooleanQuery : IQuery
    {
        void AddQuery<TInterface>(TInterface query, Matches matches) where TInterface : IQuery;

        void AddNativeQuery<TQuery>(TQuery query, Matches matches);
    }
}
