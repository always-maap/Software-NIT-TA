using IAM.Application.AuthenticationService;
using IAM.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace IAM.Presentation.Controllers;

[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly IRegisterService _registerService;
    private readonly ILoginService _loginService;
    private readonly IVerifyService _verifyService;

    public AuthController(IRegisterService registerService, ILoginService loginService, IVerifyService verifyService)
    {
        _registerService = registerService;
        _loginService = loginService;
        _verifyService = verifyService;
    }
    
    [HttpPost("verify")]
    public async Task<ActionResult> Verify([FromBody] VerifyRequest request)
    {
        await _verifyService.Handle(request.phone, request.code);
        return Ok();
    }
    
    [HttpPost("register")]
    public async Task<ActionResult> Register([FromBody] RegisterRequest request)
    {
        var result = await _registerService.Handle(request.firstName, request.lastName, request.phone, request.password);
        return Ok(result);
    }
    
    [HttpPost("login")]
    public ActionResult Login([FromBody] LoginRequest request)
    {
        var result = _loginService.Handle(request.phone, request.password);
        return Ok(result);
    }
}