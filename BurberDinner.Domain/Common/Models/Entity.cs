
namespace BurberDinner.Domain.Common.Models;


public abstract class Entity<TId>: IEquatable<Entity<TId>>
  where TId: notnull
{

  public TId Id { get; private set; }

  protected Entity(TId id) {
    Id = id;
  }

  public override bool Equals(object? obj)
  {
    return obj is Entity<TId> entity && Id.Equals(entity.Id);
  }

  public static bool operator ==(Entity<TId> left, Entity<TId> right) {
    return Equals(left, right);
  } 

  public static bool operator !=(Entity<TId> left, Entity<TId> right) {
    return !Equals(left, right);
  } 

  public bool Equals(Entity<TId>? other)
  {
    return Equals((object?)other);
  }

  public override int GetHashCode()
  {
    return Id.GetHashCode();
  }
}
