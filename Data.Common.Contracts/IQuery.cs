using System.Threading;
using System.Threading.Tasks;

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

    public interface IAsyncQuery<TReturn>
    {
        Task<TReturn> ExecuteAsync(CancellationToken token);
    }

    public interface IAsyncQuery<TReturn, TParameter>
    {
        Task<TReturn> ExecuteAsync(TParameter parameter, CancellationToken token);
    }
}
