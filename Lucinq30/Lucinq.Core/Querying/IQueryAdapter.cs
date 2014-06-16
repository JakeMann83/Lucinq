namespace Lucinq.Core.Querying
{
    public interface IQueryAdapter<in TInterface, out TQuery>
    {
        TQuery GetQuery(TInterface termQuery);
    }
}
