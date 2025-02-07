namespace Pixelart.Customers.Application.Intefaces;
public interface IQueryHandler<TQuery,TResult> where TQuery : IQuery<TResult>{
    Task<TResult> HandleAsync(TQuery query);
}