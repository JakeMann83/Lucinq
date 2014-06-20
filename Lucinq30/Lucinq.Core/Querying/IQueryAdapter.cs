using Lucinq.Core.Enums;

namespace Lucinq.Core.Querying
{
    public interface IQueryAdapter<in TInterface, out TQuery>
    {
        TQuery GetQuery(TInterface termQuery);
    }

    public interface IBooleanQueryAdapter<out TQuery> : IBooleanQueryAdapter
    {
        TQuery GetQuery();
    }

    public interface IBooleanQueryAdapter
    {
        void AddQuery<TNative>(TNative query, Matches matches);
    }
}
