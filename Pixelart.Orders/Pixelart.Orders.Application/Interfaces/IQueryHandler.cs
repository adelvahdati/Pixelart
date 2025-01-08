using Pixelart.Orders.Application.Intefaces;

namespace Pixelart.Orders.Application.Interfaces;
public interface IQueryHandler<TQuery,TResult> where TQuery : IQuery<TResult>{
    Task<TResult> HandleAsync(TQuery query);
}