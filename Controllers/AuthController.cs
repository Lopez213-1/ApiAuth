using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskApi.Data;
using TaskApi.DTOs;
using TaskApi.Models;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _config;

    public AuthController(AppDbContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    [HttpPost("register")]
    public IActionResult Register(AuthDto dto)
    {
        var usuarioExiste = _context.Users
            .FirstOrDefault(u => u.Email == dto.Email);

        if (usuarioExiste != null)
        {
            return BadRequest("El email ya está registrado");
        }
            

        var usuario = new User
        {
            Email = dto.Email,
            Password = dto.Password
        };

        _context.Users.Add(usuario);
        _context.SaveChanges();
        return Ok("Usuario registrado correctamente");
    }

    [HttpPost("login")]
    public IActionResult Login(AuthDto dto)
    {
        var usuario = _context.Users
            .FirstOrDefault(u => u.Email == dto.Email);

        if (usuario == null  || dto.Password != usuario.Password)
        {
            return Unauthorized("Credenciales incorrectas");

        }


        var token = GenerarToken(usuario.Id);
        return Ok(new { token });
    }

    private string GenerarToken(int userId)
    {
        var claims = new[]
        {
        new Claim("id", userId.ToString())
    };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

        var creds = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256
        );

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(15),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}