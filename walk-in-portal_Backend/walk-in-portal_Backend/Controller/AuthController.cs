using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using walk_in_portal_Backend.Dtos;
using walk_in_portal_Backend.Models;

namespace walk_in_portal_Backend.Controller;

[Route("api/Auth")]
[ApiController]

public class AuthController : ControllerBase
{
    
    private readonly DbWalkInPortalContext _appDbContext;
    private IConfiguration _config;
        
    public AuthController(DbWalkInPortalContext appDbContext,IConfiguration config)
    {
        _appDbContext = appDbContext;
        _config = config;
    }
    
    [HttpPost("login")]
    
    public async Task<IActionResult> Login([FromBody] LoginDto bodyUser)
    {
        
        var User = await _appDbContext.TblUserInformations.Where(u => u.EmailId == bodyUser.Email).FirstOrDefaultAsync();

        if (User is null)
        {
            return BadRequest(new { error = "User Does not exist" });
        }
        
        if (User.Password != bodyUser.Password)
        {
            return BadRequest(new { error = "Email/Password does not match" });
        }
        
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        List<Claim> claims = new List<Claim>()
        {
            new Claim("Email",bodyUser.Email)
        };
        
        var SToken = new JwtSecurityToken(_config["Jwt:Issuer"],
            _config["Jwt:Issuer"],
            claims,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials);
        var token = new JwtSecurityTokenHandler().WriteToken(SToken);
        return Ok(new {token=token , userId=User.Id}); 
    }
}