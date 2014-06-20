using Lucinq.Core.Enums;
using Lucinq.Core.Interfaces;
using Lucinq.Core.QueryTypes;

namespace Lucinq.Core.Querying
{
    public class LucinqQueryReference<TNative> : IQueryReference<TNative>
    {
        public Matches Occur { get; set; }

        public TNative Query { get; set; }
    }
}
