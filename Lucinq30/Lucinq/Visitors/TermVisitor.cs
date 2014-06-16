using Lucene.Net.Search;
using Lucinq.Core.Enums;
using Lucinq.Core.Visitors;
using Lucinq.Interfaces;

namespace Lucinq.Visitors
{
    public class TermVisitor : AbstractTermVisitor, IQueryBuilderVisitor
    {
        public TermVisitor(string field, string value, Matches matches) : base(field, value, matches)
        {
        }

        public TermVisitor(string field, string value, Matches matches, float? boost) : base(field, value, matches, boost)
        {
        }

        public TermVisitor(string field, string value, Matches matches, bool? caseSensitive) : base(field, value, matches, caseSensitive)
        {
        }

        public TermVisitor(string field, string value, Matches matches, float? boost, bool? caseSensitive) : base(field, value, matches, boost, caseSensitive)
        {
        }

        public void VisitQueryBuilder(IQueryBuilder queryBuilder)
        {
            queryBuilder.Add(GetNativeQuery<TermQuery>(), Matches);
        }
    }
}
