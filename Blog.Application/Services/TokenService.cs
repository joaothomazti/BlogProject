using Blog.Application.Interfaces;
using Blog.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

// namespace Blog.Application.Services
// {
//     public class TokenService : ITokenService
//     {
//         private readonly IConfiguration _config;
//
//         public TokenService(IConfiguration configuration)
//         {
//             _config = configuration;
//             //_key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
//         }
//         
//         public string GenerateToken(User user)
//         {
//             
//             var tokenHandler = new JwtSecurityTokenHandler();
//             
//             //var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
//
//             var tokenDescriptor = new SecurityTokenDescriptor
//             {
//                 Expires = DateTime.UtcNow.AddDays(1),
//                 SigningCredentials = creds,
//                 Issuer = _config["Jwt:Issuer"],
//                 Audience = _config["JWT:Audience"],
//             };
//             
//             var token = tokenHandler.CreateToken(tokenDescriptor);
//             
//             return tokenHandler.WriteToken(token);
//
//         }
//     }
// }
