
using BurberDinner.Application.Common.Interfaces.services;
namespace BurberDinner.Infrastructure.services;

public class DateTimeProvider : IDateTimeProvider
{
  public DateTime UtcNow => throw new NotImplementedException();
}