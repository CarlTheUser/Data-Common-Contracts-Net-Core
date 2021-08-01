namespace Data.Common.Contracts
{
    public interface IQuery<TReturn>
    {
        TReturn Execute();
    }

    public interface IQuery<TReturn, TParameter>
    {
        TReturn Execute(TParameter parameter);
    }
}
