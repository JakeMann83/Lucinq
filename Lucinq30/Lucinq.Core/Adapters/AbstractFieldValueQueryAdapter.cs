using Lucinq.Core.QueryTypes;

namespace Lucinq.Core.Adapters
{
    public abstract class AbstractFieldValueQueryAdapter<TInterface, TQuery>  : AbstractQueryAdapter<TInterface, TQuery> where TInterface : IFieldValueQuery
    {
        protected virtual string GetValue(TInterface query)
        {
            string value = query.Value;
            if (!(query.CaseSensitive ?? false))
            {
                value = value.ToLowerInvariant();
            }

            return value;
        }
    }
}
