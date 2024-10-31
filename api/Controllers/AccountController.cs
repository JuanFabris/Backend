using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.Account;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signignManager;
        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signignManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signignManager = signignManager;
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.UserLog.ToLower());

            if(user == null)
            {
                return Unauthorized("Invalid Username!");
            }

            var result = await _signignManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if(!result.Succeeded)
            {
                return Unauthorized("username not found or password incorrect!");
            }

            return Ok(
                new NewUserDto
                {
                    UserLog = user.UserName,
                    EmailAddress = user.Email,
                    Token = _tokenService.CreateToken(user)
                    
                }
            );
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register ([FromBody] RegisterDto registerDto)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                
                var appUser = new AppUser
                {
                    UserName = registerDto.UserLog,
                    Email = registerDto.EmailAddress 
                };

                var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

                //Every new Registration is gonna be save as user
                if(createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                    
                    if(roleResult.Succeeded)
                    {
                        return Ok(

                            new NewUserDto
                            {
                                UserLog = appUser.UserName,
                                EmailAddress = appUser.Email,
                                Token = _tokenService.CreateToken(appUser)
                            }
                        );
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch(Exception e)
            {
                return StatusCode(500, e);
            }
        }

    }
}