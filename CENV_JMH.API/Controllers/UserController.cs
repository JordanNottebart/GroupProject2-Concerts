using CENV_JMH.API.Dto;
using CENV_JMH.API.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace CENV_JMH.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtHelper _jwtHelper;


        public UserController(UserManager<IdentityUser> userManager, JwtHelper jwtHelper)
        {
            _userManager = userManager;
            _jwtHelper = jwtHelper;
        }

        [HttpPost("create")]
        public async Task<ActionResult<UserDto>> PostUser(UserDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var result = await _userManager.CreateAsync(
                new IdentityUser() { UserName = user.UserName, Email = user.Email },
                user.Password
            );


            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }


            user.Password = null;
            // Created("", user);
            //this will include location header where we can find newly created user.
            return CreatedAtAction("GetUser", new { username = user.UserName }, user);
        }

        // GET: api/Users/username
        [HttpGet("{username}")]
        public async Task<ActionResult<UserDto>> GetUser(string username)
        {
            IdentityUser user = await _userManager.FindByNameAsync(username);


            if (user == null)
            {
                return NotFound();
            }


            return new UserDto
            {
                UserName = user.UserName,
                Email = user.Email
            };
        }

        // POST: api/Users/BearerToken
        [HttpPost("authenticate")]
        public async Task<ActionResult<AuthResDto>> CreateBearerToken(AuthorizationDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Bad credentials");
            }


            var user = await _userManager.FindByNameAsync(request.UserName);


            if (user == null)
            {
                return BadRequest("Bad credentials");
            }


            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);


            if (!isPasswordValid)
            {
                return BadRequest("Bad credentials");
            }

            var token = _jwtHelper.CreateToken(user);

            return Ok(token);
        }
    }
}
