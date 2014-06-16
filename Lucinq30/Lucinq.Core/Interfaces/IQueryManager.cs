using Lucinq.Core.Enums;

namespace Lucinq.Core.Interfaces
{
    public interface IQueryManager
    {
        TQuery GetTermQuery<TQuery>(string fieldName, string fieldValue, Matches occur = Matches.NotSet, float? boost = null,
            string key = null, bool? caseSensitive = null);
    }

    public interface IQueryVisitor
    {
        void VisitQueryBuilder();
    }
}
