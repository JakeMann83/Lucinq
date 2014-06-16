using Lucinq.Interfaces;

namespace Lucinq.Visitors
{
    public interface IQueryBuilderVisitor
    {
        void VisitQueryBuilder(IQueryBuilder queryBuilder);
    }
}
