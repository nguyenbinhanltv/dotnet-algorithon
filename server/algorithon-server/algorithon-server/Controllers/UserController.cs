using System.ComponentModel.DataAnnotations;
using algorithon_server.Interfaces;
using algorithon_server.Models;
using Microsoft.AspNetCore.Mvc;

namespace algorithon_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        // /user/authenticate
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [Authorize]
        [HttpGet("getAll")]
        // /user/getAll
        public IActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }

        [Authorize]
        [HttpGet("getById")]
        // /user/getById
        public IActionResult GetById([FromQuery]string id)
        {
            return Ok(_userService.GetById(id));
        }

        [HttpPost("signup")]
        // user/signup
        public IActionResult SignUp(UserDto userDto)
        {
            User user = new User()
            {
                Email = userDto.Email,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Password = userDto.Password.GetHashCode().ToString(),
                UserName = userDto.UserName
            };
            var response = _userService.SignUp(user);
            if (response.Result)
            {
                return Ok();
            }

            return BadRequest(new {message = "username is already exist."});
        }
    }

    public class UserDto
    {
        
        [Required]
        public string UserName { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}