using BookStore.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ITokenService _tokenService;

    public AuthController(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            return Unauthorized();

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, request.Username)
        };

        var accessToken = _tokenService.GenerateAccessToken(claims);
        var refreshToken = _tokenService.GenerateRefreshToken();

        // Print the tokens to the console (or log them)
        System.Console.WriteLine($"Generated Access Token: {accessToken}");
        System.Console.WriteLine($"Generated Refresh Token: {refreshToken}");

        return Ok(new { AccessToken = accessToken, RefreshToken = refreshToken });
    }
}
