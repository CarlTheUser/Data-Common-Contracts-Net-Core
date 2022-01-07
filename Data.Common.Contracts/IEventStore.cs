using System.Collections.Generic;

namespace Data.Common.Contracts
{
    public class DataEvent
    {

    }

    public interface IEventStore
    {
        IEnumerable<DataEvent> ReleaseEvents();
    }
}
