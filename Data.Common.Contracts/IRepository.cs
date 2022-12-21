using System.Threading;
using System.Threading.Tasks;

namespace Data.Common.Contracts
{
    public interface IReadOnlyRepository<TKey, TItem>
    {
        TItem? Find(TKey key);
    }

    public interface IRepository<TKey, TItem> : IReadOnlyRepository<TKey,TItem>
    {
        void Save(TItem item);
    }

    public interface IAsyncReadOnlyRepository<TKey, TItem>
    {
        Task<TItem?> FindAsync(TKey key, CancellationToken cancellationToken = default);
    }

    public interface IAsyncRepository<TKey, TItem> : IAsyncReadOnlyRepository<TKey, TItem>
    {
        Task SaveAsync(TItem item, CancellationToken cancellationToken = default);
    }

    namespace SpecificationRepositories
    {
        public interface ISpecification<T>
        {

        }

        public class KeySpecification<TItem, TKey> : ISpecification<TItem>
        {
            public TKey Key { get; }

            public KeySpecification(TKey key)
            {
                Key = key;
            }
        }

        public interface IHandlesSpecification<TSpecification, TItem> where TSpecification : ISpecification<TItem>
        {
            TItem Find(TSpecification specification);
        }

        public interface IHandlesSpecificationAsync<TSpecification, TItem> where TSpecification : ISpecification<TItem>
        {
            Task<TItem> FindAsync(TSpecification specification, CancellationToken cancellationToken = default);
        }

        public interface IReadOnlyRepository<TKey, TItem> : IHandlesSpecification<KeySpecification<TItem, TKey>, TItem>
        {
        }

        public interface IRepository<TKey, TItem> : IReadOnlyRepository<TKey, TItem>
        {
            void Save(TItem item);
        }

        public interface IAsyncReadOnlyRepository<TKey, TItem> : IHandlesSpecificationAsync<KeySpecification<TItem, TKey>, TItem>
        {
        }

        public interface IAsyncRepository<TKey, TItem> : IAsyncReadOnlyRepository<TKey, TItem>
        {
            Task SaveAsync(TItem item, CancellationToken cancellationToken = default);
        }
    }
}
