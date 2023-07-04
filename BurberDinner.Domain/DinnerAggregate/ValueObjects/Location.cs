
using BurberDinner.Domain.Common.Models;

namespace BurberDinner.Domain.DinnerAggregate.Entities;

public sealed class Location: ValueObject{

  public string Name { get; private set; }
  public string Address { get; private set; }
  public float Latitude { get; private set; }
  public float Longitude { get; private set; }

  private Location(
    string name,
    String addess,
    float latitude,
    float longitude) {

    Name = name;
    Address = addess;
    Latitude = latitude;
    Longitude = longitude;

  }

  public Location Create(
    string name,
    string address,
    float latitude,
    float longitude){

      return new Location(
        name,
        address,
        latitude,
        longitude);
    }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Name;
    yield return Address;
    yield return Latitude;
    yield return Longitude;
  }
}