using IAM.Application.UserService;
using IAM.Contracts.User;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IAM.Presentation.Controllers;

[Microsoft.AspNetCore.Components.Route("user")]
public class UserController : ControllerBase
{
    private readonly IUserInfoService _userInfoService;
    private readonly IMapper _mapper;

    public UserController(IUserInfoService userInfoService, IMapper mapper)
    {
        _userInfoService = userInfoService;
        _mapper = mapper;
    }

    [HttpGet("userinfo")]
    [Authorize]
    public async Task<ActionResult> UserInfo()
    {
        var user = await _userInfoService.Handle();
        return Ok(_mapper.Map<UserInfoResponse>(user));
    }
}