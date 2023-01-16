using Election.CORE.Data;
using Election.CORE.Repository;
using Election.CORE.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
namespace Election.INFR.Service
{
    public class JWTService : IJWTService
    {
        private readonly IJWTRepository _jWTRepository;

        public JWTService(IJWTRepository jWTRepository)
        {
            _jWTRepository = jWTRepository;
        }

        public string Auth(Euser euser)
        {
            var result = _jWTRepository.Auth(euser);
            if (result == null)
            {
                return null;
            }
            else if(result.Verified == 0)
            {
                return "0";
            }
            else 
            {
                string userName = result.Firstname + " " + result.Lastname;
                var securtyKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ElectionProjectTeamSecurityKey<3NeverGiveUp<3"));
                var signingCredentials = new SigningCredentials(securtyKey, SecurityAlgorithms.HmacSha256);
                var claims = new List<Claim>
                {
                    new Claim("UserId" , result.Id.ToString()),
                    new Claim("Name" , userName),
                    new Claim("RoleId" , result.Roleid.ToString()),
                };
                var tokenOption = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: signingCredentials
                    );
                var token = new JwtSecurityTokenHandler().WriteToken(tokenOption);
                return token;
            }
        }
    }
}
