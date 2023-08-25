using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using RestAPI.API.Controllers;
using RestAPI.Application.ViewModels.Users;
using RestAPI.Infrastructure.Services;
using RestAPI.Core.Services;
using RestAPI.Application.Repositories;
using RestAPI.Persistence.Repositories;

namespace RestAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        readonly private ICustomerWriteRepository _customerWriteRepository;
        readonly private ICustomerReadRepository _customerReadRepository;

        public AuthController(IUserService userService, ICustomerReadRepository customerReadRepository)
        {
            _customerReadRepository = customerReadRepository;
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userService.RegisterUserAsync(model);

            if (result.Success)
            {
                return Ok(new { message = "Kayıt başarılı." });
            }
            return BadRequest(new { errors = result.Errors });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userService.LoginUserAsync(model);
            if(result.Success)
            {
                return Ok(new { message = "Giriş Başarılı." });
            }
            return BadRequest(new {errors = result.Errors});
        }
        [HttpGet("profile")]
        public async Task<IActionResult> GetUserProfile()
        {
            var loggedInUsername = HttpContext.User.Identity.Name;

            var userProfile = await _customerReadRepository.GetSingleAsync(c => c.Username == loggedInUsername);
            //await _userService.GetUserProfileAsync(loggedInUsername);

            if (userProfile == null)
            {
                return NotFound();
            }
            return Ok(userProfile);
        }




    }


}

