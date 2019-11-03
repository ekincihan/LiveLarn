using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppLog.Core.Abstract;
using LiveLarn.Service.User.Models;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LiveLarn.Service.User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ODataRoutePrefix("Account")]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole<string>> _roleManager;
        private readonly AppLog.Core.Abstract.ILogger<AccountController> _logger;
        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole<string>> roleManager,
            ILogger<AccountController> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }
        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterDto model)
        {
            try
            {
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return Ok(user);
                }

                string errorMessages = string.Join("|", result.Errors.Select(x => x.Description));
                await _logger.Current().ErrorAsync(model.Email, errorMessages);

                return BadRequest(new ApplicationException(errorMessages));
            }
            catch (Exception ex)
            {
                await _logger.Current().CriticalAsync(model.Email, ex);
                return BadRequest(ex);
            }
        }
        [HttpPost("CreateRole")]
        public async Task<ActionResult> CreateRole([FromForm]string name)
        {
            try
            {
                if (!(await _roleManager.RoleExistsAsync(name)))
                {
                    var result = await _roleManager.CreateAsync(new IdentityRole<string> { Name = name });
                    if (result.Succeeded)
                        return Ok(result.Succeeded);

                    string errorMessages = string.Join("|", result.Errors.Select(x => x.Description));
                    await _logger.Current().ErrorAsync(name, errorMessages);

                    return BadRequest(new ApplicationException(errorMessages));
                }
                await _logger.Current().WarningAsync(name, "Role Exists");
                return BadRequest("Role exists");
            }
            catch (Exception ex)
            {
                await _logger.Current().CriticalAsync(name, ex);
                return BadRequest(ex);
            }

        }
        [HttpPost("AddToRole")]
        public async Task<ActionResult> AddToRole([FromForm]string email, [FromForm]string role)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    await _logger.Current().ErrorAsync(email, "User Not Found");
                    return BadRequest("User Not Found");
                }
                var result = await _userManager.AddToRoleAsync(user, role);
                if (result.Succeeded)
                    return Ok(result.Succeeded);

                string errorMessages = string.Join("|", result.Errors.Select(f => f.Description));
                await _logger.Current().ErrorAsync(email, role, errorMessages);

                return BadRequest(new ApplicationException(errorMessages));
            }
            catch (Exception ex)
            {
                await _logger.Current().CriticalAsync(email, role, ex);
                return BadRequest(ex);
            }
        }
    }
}