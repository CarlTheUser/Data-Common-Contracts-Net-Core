using System.Collections.Generic;

namespace Data.Common.Contracts
{
    public interface IOneWayDataSource<T>
    {
        IEnumerable<T> Next();
    }
}
