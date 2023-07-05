


namespace BurberDinner.Domain.Common.Models;

public interface IHasDomainEvent {
  public IReadOnlyList<IDomainEvent> DomainEvents { get; }

  public void ClearDomainEvents();
} 