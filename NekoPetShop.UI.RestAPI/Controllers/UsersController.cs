using System;
using Microsoft.AspNetCore.Mvc;
using NekoPetShop.Core.Entity;
using NekoPetShop.Core.Helpers;
using NekoPetShop.Core.ApplicationService;

namespace NekoPetShop.UI.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
		private readonly IUserService _userService;
		private IAuthenticationHelper _authenticationHelper;

		public UsersController(IUserService userService, IAuthenticationHelper authenticationHelper)
		{
			_userService = userService;
			_authenticationHelper = authenticationHelper;
		}

		// POST api/users -- LOG IN
		[HttpPost]
		public ActionResult Login([FromBody] LoginInputModel loginInputModel)
		{
			try
			{
				User user = _userService.ValidateUser(loginInputModel);
				string token = _authenticationHelper.GenerateToken(user);
				return Ok(new { user.Username, user.IsAdmin, token});
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
	}
}