using System.Text;
using System.Security.Claims;
namespace BurberDinner.Infrastructure.Authentication;

using System.IdentityModel.Tokens.Jwt;
using BurberDinner.Application.Common.Interfaces.Authentication;
using Microsoft.IdentityModel.Tokens;

public class JwtTokenGenerator : IJwtTokenGenerator
{
  public string GenerateToken(Guid userId, string firstName, string lastName)
  {


    var signingCredentials = new SigningCredentials(
      new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes("super-secret-key")
      ),
      SecurityAlgorithms.HmacSha256
    );
    
    var claims = new[]  {

      new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
      new Claim(JwtRegisteredClaimNames.GivenName, firstName),
      new Claim(JwtRegisteredClaimNames.FamilyName, lastName)
    };

    var securityToken = new JwtSecurityToken(
      issuer: "BuberDinner",
      expires: DateTime.Now.AddDays(1),
      claims: claims,
      signingCredentials: signingCredentials); 


    return new JwtSecurityTokenHandler().WriteToken(securityToken);
  }
}
