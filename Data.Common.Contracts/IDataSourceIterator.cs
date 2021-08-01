using System;

namespace Data.Common.Contracts
{
    public interface IDataSourceIterator<T>
    {
        void Iterate(Action<T> itemCallback);
    }
}
