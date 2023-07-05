

using BurberDinner.Domain.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BurberDinner.Infrastructure.Persistence.Interceptors;


public class PublishDomainEventsInterceptor: SaveChangesInterceptor {

  private readonly IPublisher _mediator;

  public PublishDomainEventsInterceptor(IPublisher mediator) {
    _mediator = mediator;
  }

  public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
  {

    PublishDomainEvents(eventData.Context).GetAwaiter().GetResult();
    return base.SavingChanges(eventData, result);
  }

  public async  override  ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
  {
    await PublishDomainEvents(eventData.Context);
    return await base.SavingChangesAsync(eventData, result, cancellationToken);
  }


  private async Task PublishDomainEvents(DbContext? dbContext) {

    if(dbContext is null) return;
    
    // STEP 1: Get hold of all the various entities
    var entitiesWithDomainEvents = dbContext.ChangeTracker.Entries<IHasDomainEvent>()
      .Where(entry => entry.Entity.DomainEvents.Any())
      .Select(entry => entry.Entity)
      .ToList();

    // STEP 2: Get hold of all the various domain events
    var domainEvents = entitiesWithDomainEvents.SelectMany(entry => entry.DomainEvents).ToList();

    // STEP 3: Clear the domain events
    entitiesWithDomainEvents.ForEach(entity => entity.ClearDomainEvents());

    // STEP 4: Publish the domain events
    foreach(var domainEvent in domainEvents) {
      await _mediator.Publish(domainEvent);
    }
  }

}