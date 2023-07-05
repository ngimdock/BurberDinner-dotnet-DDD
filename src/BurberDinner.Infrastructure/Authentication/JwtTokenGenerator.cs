using System.Text;
using System.Security.Claims;
namespace BurberDinner.Infrastructure.Authentication;

using System.IdentityModel.Tokens.Jwt;
using BurberDinner.Application.Common.Interfaces.Authentication;
using BurberDinner.Application.Common.Interfaces.services;
using BurberDinner.Domain.entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

public class JwtTokenGenerator : IJwtTokenGenerator
{


  private readonly JwtSettings _jwtSettings;
  private readonly IDateTimeProvider _dateTimeProvider;

  public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtOptions) {
    _dateTimeProvider = dateTimeProvider;
    _jwtSettings = jwtOptions.Value;
  }

  public string GenerateToken(User user)
  {


    var signingCredentials = new SigningCredentials(
      new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(_jwtSettings.Secret)
      ),
      SecurityAlgorithms.HmacSha256
    );
    
    var claims = new[]  {

      new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
      new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
      new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName)
    };

    var securityToken = new JwtSecurityToken(
      issuer: _jwtSettings.Issuer,
      audience: _jwtSettings.Audience,
      expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
      claims: claims,
      signingCredentials: signingCredentials); 


    return new JwtSecurityTokenHandler().WriteToken(securityToken);
  }
}