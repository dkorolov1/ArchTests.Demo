using ArchUnitNET.Demo.Application.Common.Persistence;
using ArchUnitNET.Demo.Domain.Common.Persistence;
using MediatR;

namespace  ArchUnitNET.Demo.Infrastructure.Common.Persistence;

public class BaseRepository<TEntity>(IPublisher mediator) : IBaseRepository<TEntity> where TEntity : Entity
{
    protected List<TEntity> Items = [];

    public async Task AddAsync(TEntity entity)
    {
        Items.Add(entity);
        await PublishDomainEvents(entity);
    }

    public async Task UpdateAsync(TEntity entity)
    {
        Items[Items.FindIndex(e => e.Id == entity.Id)] = entity;
        await PublishDomainEvents(entity);
    }

    public async Task DeleteAsync(TEntity entity)
    {
        Items.Remove(entity);
        await PublishDomainEvents(entity);
    }

    public Task<TEntity?> GetByIdAsync(Guid id) => 
        Task.Run(() => Items.FirstOrDefault(e => e.Id == id));

    public Task<IEnumerable<TEntity>> GetAllAsync() => 
        Task.Run(() => Items.AsEnumerable());

    protected async Task PublishDomainEvents(params TEntity[] entities)
    {
        var domainEvents = entities
            .SelectMany(entry => entry.DomainEvents)
            .ToList();

        entities.ToList().ForEach(
            entity => entity.ClearDomainEvents()
        );

        foreach (var domainEvent in domainEvents)
        {
            await mediator.Publish(domainEvent);
        }
    }
}

