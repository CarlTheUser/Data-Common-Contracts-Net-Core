namespace Data.Common.Contracts
{
    public interface IDataWriter<TData>
    {
        void Write(TData data);

    }

    public interface IDataWriter<TData, TGeneratedId>
    {
        TGeneratedId Write(TData data);

    }
}
