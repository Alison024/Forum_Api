using System.Runtime.InteropServices.ComTypes;
using System;
using System.Linq;
using System.Text;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using ForumApi.Domain.Models;

namespace ForumApi.Extensions
{
    public static class UserExtension
    {
        public static void GenerateToken(this User user, string secret, int expire){
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);

            var claims = new List<Claim>();
            claims.AddRange(user.User_Roles.Select(x => new Claim(ClaimTypes.Role, x.Role.Name)));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            //claims.AddRange(roleClaims);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(claims),//claims
                Expires = DateTime.UtcNow.AddMinutes(expire),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)//HmacSha256Signature
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            user.Password = null;
        }
    }
}