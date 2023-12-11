using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BB205_Pronia.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
      public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm registerVm)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            AppUser user = new AppUser()
            {
                Name = registerVm.Name,
                Email = registerVm.Email,
                Surname= registerVm.Surname,
                UserName=registerVm.Username,
            };
            var result= await _userManager.CreateAsync(user, registerVm.Password);
            if(!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("",error.Description);
                }
                return View();
            }
           
            await _userManager.AddToRoleAsync(user,UserRole.Member.ToString());
            return RedirectToAction(nameof(Index), "home");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVm loginVm,string? ReturnUrl)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            AppUser user = await _userManager.FindByNameAsync(loginVm.UsernameOrEmail);
            if(user is null)
            {
                user = await _userManager.FindByEmailAsync(loginVm.UsernameOrEmail);
                if(user ==null)
                {
                    ModelState.AddModelError("", "Username/Email or Password yanlisdir ");
                    return View();
                }
            }
            var result = _signInManager.CheckPasswordSignInAsync(user, loginVm.Password, true).Result;
            if(result.IsLockedOut)
            {
                ModelState.AddModelError(String.Empty, "Biraz sonra yeniden cehd edin");
                return View();
            }
            if(!result.Succeeded)
            {
                ModelState.AddModelError(String.Empty, "Username/Email or Password yanlisdir");
                return View();
            }
            await _signInManager.SignInAsync(user, loginVm.RememberMe);


            if(ReturnUrl!=null&&!ReturnUrl.Contains("Login"))
            {
                return Redirect(ReturnUrl);
            }
            return RedirectToAction(nameof(Index),"Home");
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index), "Home");
        }
        public async Task<IActionResult> CreateRole()
        {
            foreach(UserRole item in Enum.GetValues(typeof(UserRole)))
            {
                if(await _roleManager.FindByNameAsync(item.ToString())==null)
                {
                    await _roleManager.CreateAsync(new IdentityRole()
                    {
                        Name = item.ToString(),
                    });
                }
            }

            return RedirectToAction(nameof(Index), "Home");
        }
    }
}
