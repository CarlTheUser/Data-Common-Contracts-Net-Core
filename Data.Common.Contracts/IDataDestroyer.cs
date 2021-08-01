namespace Data.Common.Contracts
{
    public interface IDataDestroyer<T>
    {
        void Destroy(T item);
    }
}
