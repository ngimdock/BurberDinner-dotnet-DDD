namespace BurberDinner.Application.Common.Interfaces.Authentication;
public interface IJwtTokenGenerator {
  
  string GenerateToken(Guid userId, string firstName, string lastName);
}