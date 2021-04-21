using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EncodingFinalProject.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace EncodingFinalProject.Models
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly AppSettings _appSettings;
        public AuthenticateService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        private List<Teacher> Teachers = new List<Teacher>()
{
new Teacher{TeacherId =1, Fname = "Keerthy Raaj", Lname="Shanmugam", UserName="Keerthy", Password ="Lovelearning"}
};
        public Teacher Authenticate(string userName, string password)
        {
            var teacher = Teachers.SingleOrDefault(x => x.UserName == userName && x.Password == password);
           
            if (teacher == null)
            {
                return null;
            }
            else
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Key);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
new Claim(ClaimTypes.Name, teacher.TeacherId.ToString()),
new Claim(ClaimTypes.Role, "Admin"),
new Claim(ClaimTypes.Version, "V3.1")
}),
                    Expires = DateTime.UtcNow.AddDays(2),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                teacher.Token = tokenHandler.WriteToken(token);
                return teacher;
                teacher.Password = null;
            }
        }
    }
}
