using System;

namespace Lucinq.Core.Interfaces
{
    public interface IIndexSearcherProvider<out TIndexSearcher> : IDisposable
    {
        TIndexSearcher IndexSearcher { get; }

        bool ClosesDirectory { get; }
    }
}
