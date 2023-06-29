

namespace BurberDinner.Application.Common.Interfaces.services;

public interface IDateTimeProvider {
  DateTime UtcNow { get; }
}