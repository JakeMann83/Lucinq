using Lucinq.Core.QueryTypes;

namespace Lucinq.Interfaces
{
    public interface IQueryFactory
    {
        ITermQuery GetTermQuery(string field, string value, float? boost);
    }
}
