using System.Threading;
using System.Threading.Tasks;

namespace Data.Common.Contracts
{
    public interface IRepository<TKey, TItem>
    {
        TItem Find(TKey key);
        void Save(TItem item);
    }

    public interface IAsyncRepository<TKey, TItem>
    {
        Task<TItem> FindAsync(TKey key, CancellationToken token);
        Task SaveAsync(TItem item, CancellationToken token);
    }
}
