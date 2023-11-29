using Application.DataAccess.Base;

namespace Application.DataAccess.Contracts;

public interface IBaseRepository<T> where T: BaseEntity
{
    Task AddOrUpdateAsync(T subject); 
}