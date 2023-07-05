using BurberDinner.Domain.entities;

namespace BurberDinner.Application.Common.Interfaces.Authentication;
public interface IJwtTokenGenerator {
  
  string GenerateToken(User user);
}