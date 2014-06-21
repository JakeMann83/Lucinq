namespace Lucinq.Core.Interfaces
{
    public interface IIndexSearcherAccessor<TIndexSearcher>
    {
        IIndexSearcherProvider<TIndexSearcher> GetIndexSearcherProvider();
    }
}
