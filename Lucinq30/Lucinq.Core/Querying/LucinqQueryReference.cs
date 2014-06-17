using Lucinq.Core.Enums;
using Lucinq.Core.Interfaces;
using Lucinq.Core.QueryTypes;

namespace Lucinq.Core.Querying
{
    public class LucinqQueryReference : IQueryReference<IQuery>
    {
        public Matches Occur { get; set; }

        public IQuery Query { get; set; }
    }
}
