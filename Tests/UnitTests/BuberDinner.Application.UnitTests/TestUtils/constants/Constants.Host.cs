using System;
using BurberDinner.Domain.HostAggregate.ValueObjects;


namespace BuberDinner.Application.UnitTests.TestUtils.constants;


public static partial class Constants {

  public static class Host {
    public static readonly HostId Id = HostId.Create(new Guid());
  }
}