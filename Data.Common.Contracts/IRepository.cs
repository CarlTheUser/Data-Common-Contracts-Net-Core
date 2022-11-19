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
        Task<TItem?> FindAsync(TKey key, CancellationToken cancellationToken = default);
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
            TItem? Find(TSpecification specification);
        }

        public interface IHandlesSpecificationAsync<TSpecification, TItem> where TSpecification : ISpecification<TItem>
        {
            Task<TItem?> FindAsync(TSpecification specification, CancellationToken cancellationToken = default);
        }

        public interface IRepository<TKey, TItem> : IHandlesSpecification<KeySpecification<TItem, TKey>, TItem>
        {
            void Save(TItem item);
        }

        public interface IAsyncRepository<TKey, TItem> : IHandlesSpecificationAsync<KeySpecification<TItem, TKey>, TItem>
        {
            Task SaveAsync(TItem item, CancellationToken cancellationToken = default);
        }
    }
}
