using System.Drawing.Imaging;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using E_Commerce_WebAPI.DTOs.UserDTO;
using E_Commerce_WebAPI.Models;
using E_Commerce_WebAPI.Repos.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace E_Commerce_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfiguration configuration;
        public AuthController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            this.unitOfWork = unitOfWork;
            this.configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO dTO)
        {
            if (dTO == null)
            {
                return BadRequest("Registration data is null");
            }
            var user = new User
            {
                FullName = dTO.FullName,
                Email = dTO.Email,
                PasswordHash = dTO.PasswordHash,
                Role = dTO.Role,
            };
            await unitOfWork.userRepo.AddAsync(user);
            await unitOfWork.SaveAsync();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO dTO)
        {
            var user=await unitOfWork.userRepo.GetByEmail(dTO.Email);
            if (user == null)
            {
                return BadRequest("Invalid Email");
            }
            if (dTO.PasswordHash != user.PasswordHash)
            {
                return BadRequest("Invalid Password");
            }
            var token = GenerateToken(user);
            return Ok(token);
        }

        private string GenerateToken(User user)
        {
            //Generate claims
            var Claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.FullName),
                new Claim(ClaimTypes.Role,user.Role),
            };

            //Get key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:key"]));

            //Generate creds
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Token

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:issuer"],
                audience: configuration["JWT:audience"],
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(configuration["JWT:duration"])),
                signingCredentials: creds
                );

            //Convert to string
            var Tokenstring=new JwtSecurityTokenHandler().WriteToken(token);
            return Tokenstring;


        }
    }
}
