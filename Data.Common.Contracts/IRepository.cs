using System.Threading;
using System.Threading.Tasks;

namespace Data.Common.Contracts
{
    public interface IRepository<TKey, TItem>
    {
        TItem? Find(TKey key);
        void Save(TItem item);
    }

    public interface IAsyncRepository<TKey, TItem>
    {
        Task<TItem?> FindAsync(TKey key, CancellationToken token);
        Task SaveAsync(TItem item, CancellationToken token);
    }

    //Template for specific implementations: SqlSpec(string ToSqlClase()), GenericSpec(bool IsSatisfiedBy(condition))... etc.
    public interface ISpecification
    {

    }

    public interface IRepository<TItem>
    {
        TItem? Find(ISpecification specs);
        void Save(TItem item);
    }

    public interface IAsyncRepository<TItem>
    {
        Task<TItem?> FindAsync(ISpecification specs, CancellationToken token);
        Task SaveAsync(TItem item, CancellationToken token);
    }
}
