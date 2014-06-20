using Lucinq.Core.Enums;
using Lucinq.Core.Querying;
using Lucinq.Core.QueryTypes;

namespace Lucinq.Core.Visitors
{
    public class FieldValueQueryVisitor<TNative> : AbstractQueryVisitor<IFieldValueQuery, TNative>
    {
        public FieldValueQueryVisitor(IQueryAdapter<IFieldValueQuery, TNative> adapter, IFieldValueQuery query, Matches matches)
            : base(adapter, query, matches)
        {
        }
    }
}
