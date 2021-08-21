using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APCore.Services;
using APCore.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;
        //private IMailService _mailService;
        //private IConfiguration _configuration;
        public AuthController(IUserService userService/*, IMailService mailService, IConfiguration configuration*/)
        {
            _userService = userService;
            //_mailService = mailService;
            //_configuration = configuration;
        }

        // /api/auth/register
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync(/*[FromBody]*/ RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterUserAsync(model);

                if (result.IsSuccess)
                    return Ok(result); // Status Code: 200 

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid"); // Status code: 400
        }

        // /api/auth/login
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(/*[FromBody]*/ LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.LoginUserAsync(model);

                if (result.IsSuccess)
                {
                   // await _mailService.SendEmailAsync(model.Email, "New login", "<h1>Hey!, new login to your account noticed</h1><p>New login to your account at " + DateTime.Now + "</p>");
                    return Ok(result);
                }

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid");
        }

        // /api/auth/login
        [HttpGet("syncsec")]
        public async Task<IActionResult> syncsec()
        {

            var result = await _userService.UpdateSecurityStamp();

                

            return Ok(result);
        }



    }
}
