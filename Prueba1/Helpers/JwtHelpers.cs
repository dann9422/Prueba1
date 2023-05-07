using Microsoft.IdentityModel.Tokens;
using Prueba1.Models.DataModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Prueba1.Helpers
{
    public static class JwtHelpers
    {
        public static IEnumerable<Claim> GetClaim(this UserTokens userAccount, Guid Id)
        {

            List<Claim> claims = new List<Claim>
            {
                new Claim("Id",userAccount.Id.ToString()),
                new Claim (ClaimTypes.Name, userAccount.UserName),
                new Claim (ClaimTypes.Email, userAccount.EmailId),
                new Claim(ClaimTypes.NameIdentifier, Id.ToString()),
                new Claim(ClaimTypes.Expiration, DateTime.UtcNow.AddDays(1).ToString("MMM dd dd yyyy HH:mm:ss tt"))
                
            };
            if(userAccount.UserName == "Admin")
            {
                claims.Add(new Claim(ClaimTypes.Role, "Administrator"));
            }
            else if (userAccount.UserName == "User 1")
            {
                claims.Add(new Claim(ClaimTypes.Role, "User"));
                claims.Add(new Claim("UserOnly", "User 1"));
            }
            return claims;

        }

        public static IEnumerable<Claim>GetClaims(this UserTokens userAccount, out Guid Id)
        {
            Id= Guid.NewGuid();
            return GetClaim(userAccount, Id);
        }


        public static UserTokens GenTokenKey(UserTokens model, JwtSettings jwtSettings)
        {
            try
            {
                var UserToken = new UserTokens();
                if(model == null)
                {
                    throw new InvalidOperationException(nameof(model));
                }
                //Obtein secret kay
                var key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.IssuerSigningKey);
                Guid Id;
                DateTime Expiredtime =DateTime.UtcNow.AddDays(1);
                UserToken.Validity = Expiredtime.TimeOfDay;
                var jwtToken = new JwtSecurityToken(
                    issuer: jwtSettings.ValidIuuser,
                    audience: jwtSettings.ValidAudience,
                    claims: GetClaims(model, out Id),
                    notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                    expires: new DateTimeOffset(Expiredtime).DateTime,
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256 ));

                UserToken.Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
                UserToken.UserName =model.UserName;
                UserToken.Id = model.Id;
                UserToken.GuidId = Id;

                return UserToken;


            }
            catch (Exception ex)
            {

                throw new Exception("Error genereting the jwt");
            }
        }
        //Obtener el token



    }
}
