using AutoMapper;
using CWProject.Models.DtoModels;
using CWProject.Models.Models;
using CWProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APICourseWorkProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }


        //User Register and Login Methods
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            _authService.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = _mapper.Map<User>(request);

            user.Username = request.UserName;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            return Ok(user);
        }
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            var user = _mapper.Map<User>(request);
            // check if Username is here already
            if (user.Username != request.UserName)
            {
                return BadRequest(" User NOT found ");
            } 

            // check password
            if(!_authService.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest(" Wrong password ");
            }

            //json web token
            string token = _authService.CreateJwt(user);

            return Ok(token);

        }
    }
}
