using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tonyzeman.Models;
using Tonyzeman.ViewModel;

namespace Tonyzeman.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountApiController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountApiController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserViewModel userVM)
        {
            if (ModelState.IsValid)
            {

                var user = new User();
                user.Adress = userVM.Address;
                user.PhoneNumber = userVM.Phone;
                user.UserName = userVM.UserName;
                user.Name = userVM.Name;
                user.PasswordHash = userVM.Password;
                user.IsAdmin = false;

                IdentityResult result = await userManager.CreateAsync(user, userVM.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return Ok(user);
                }
                else
                {
                    return BadRequest(result.Errors.Select(error => error.Description));
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel userVm)
        {
            if (ModelState.IsValid)
            {
                User user = await userManager.FindByNameAsync(userVm.UserName);

                if (user != null)
                {
                    bool found = await userManager.CheckPasswordAsync(user, userVm.Password);

                    if (found)
                    {
                        await signInManager.SignInAsync(user, userVm.RememberMe);
                        return Ok(user);
                    }
                }

                return BadRequest("Username or password is wrong");
            }

            return BadRequest("Username or password is wrong");
        }
    }
}
