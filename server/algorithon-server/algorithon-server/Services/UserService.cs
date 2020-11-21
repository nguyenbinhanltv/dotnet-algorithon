using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using algorithon_server.Helpers;
using algorithon_server.Interfaces;
using algorithon_server.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace algorithon_server.Services
{
    public class UserService : IUserService
    {
        // hardcode, get from database later
        private List<User> _users = new List<User>
        {
            new User { Id = "1", FirstName = "Test", LastName = "User", UserName = "test", Password = "test" },
            new User { Id = "2", FirstName = "Test", LastName = "User", UserName = "test1", Password = "123456" }
        };

        private readonly AppSetting _appSettings;

        // get Secret which is the secret key.
        public UserService(IOptions<AppSetting> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        private string generateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {new Claim("id", user.Id), }),
                // Token valid for 90 days.
                Expires = DateTime.UtcNow.AddDays(90),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _users.SingleOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);
            
            // if user not found -> return null
            if (user == null) return null;
            // else, generateToken
            var token = generateJwtToken(user);
            
            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User GetById(string id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }
    }
}