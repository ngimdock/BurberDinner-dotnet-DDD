namespace BurberDinner.Infrastructure.Authentication;



public class JwtSettings {


public const String Servicename = "SectionName";
  public String Secret { get; init; } = null!;
  public int ExpiryMinutes { get; init; }
  public String Issuer { get; init; } = null!;
  public String Audience { get; init; } = null!;
}