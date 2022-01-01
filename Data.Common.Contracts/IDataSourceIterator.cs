using System;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Common.Contracts
{
    public interface IDataSourceIterator<T>
    {
        void Iterate(Action<T> itemCallback);
    }

    public interface IAsyncDataSourceIterator<T>
    {
        Task IterateAsync(Action<T> itemCallback, CancellationToken token);
    }
}
