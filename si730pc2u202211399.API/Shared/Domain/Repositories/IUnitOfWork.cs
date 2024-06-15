namespace si730pc2u202211399.API.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}