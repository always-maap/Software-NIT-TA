using IAM.Application.AuthenticationService;
using Microsoft.AspNetCore.Mvc;

namespace IAM.Presentation.Controllers;

[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly IRegisterService _registerService;
    private readonly ILoginService _loginService;

    public AuthController(IRegisterService registerService, ILoginService loginService)
    {
        _registerService = registerService;
        _loginService = loginService;
    }

    [HttpPost("register")]
    public ActionResult Register(string firstName, string lastName, string phone)
    {
        var result = _registerService.Handle(firstName, lastName, phone);
        return Ok(result);
    }
    
    [HttpPost("login")]
    public ActionResult Login(string phone, int code)
    {
        var result = _loginService.Handle(phone, code);
        return Ok(result);
    }
}