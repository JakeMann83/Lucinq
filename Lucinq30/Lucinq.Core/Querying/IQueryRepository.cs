using Lucinq.Core.Enums;
using Lucinq.Core.QueryTypes;

namespace Lucinq.Core.Querying
{
    public interface IQueryRepository
    {
        ITermQuery Term(string fieldName, string fieldValue, Matches occur = Matches.NotSet, float? boost = null, string key = null, bool? caseSensitive = null);
    }
}
