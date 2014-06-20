using System.Collections.Generic;
using Lucinq.Core.Enums;
using Lucinq.Core.QueryTypes;

namespace Lucinq.Core.Visitors
{
    public interface IGroupedQuery : IQuery
    {
        List<IGroupedQuery> Groups { get; set; } 

        void Add<TNative>(TNative query, Matches matches);
    }
}
