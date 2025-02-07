// AuthController.cs
using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.Services;
using TaskManagementAPI.Models;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest model)
    {
        var token = _userService.Authenticate(model.UserName, model.Password);
        if (token == null)
            return Unauthorized("Invalid username or password");

        return Ok(new { Token = token });
    }
}

public class LoginRequest
{
    public string UserName { get; set; }
    public string Password { get; set; }
}
