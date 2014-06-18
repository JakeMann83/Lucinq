namespace Lucinq.Core.Visitors
{
    public interface IQueryProviderVisitor<out TInterface> where TInterface : class 
    {
        TInterface GetQuery();
    }
}
