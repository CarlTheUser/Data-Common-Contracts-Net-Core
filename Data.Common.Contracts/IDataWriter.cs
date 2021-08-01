namespace Data.Common.Contracts
{
    public interface IDataWriter<TData>
    {
        void Write(TData data);

    }
}
