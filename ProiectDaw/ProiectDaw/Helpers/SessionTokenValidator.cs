using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.JsonWebTokens;
using ProiectDaw.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDaw.Helpers
{
    public class SessionTokenValidator
    {
        public static async Task ValidateSessionToken(TokenValidatedContext context)
        {
            var repository = context.HttpContext.RequestServices.GetRequiredService<IRepositoryWrapper>();

            if(context.Principal.HasClaim(c => c.Type.Equals(JwtRegisteredClaimNames.Jti)))
            {
                var jti = context.Principal.Claims.FirstOrDefault(c => c.Type.Equals(JwtRegisteredClaimNames.Jti)).Value;

                var tokenInDb = await repository.SessionToken.GetByJTI(jti);
                if(tokenInDb != null && tokenInDb.ExpirationDate > DateTime.Now)
                {
                    return;
                }

            }

            context.Fail("");
        }
    }
}
