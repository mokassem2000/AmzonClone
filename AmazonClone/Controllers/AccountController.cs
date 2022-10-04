using AmazonClone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AmazonClone.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(UserManager<IdentityUser> usermanger,SignInManager<IdentityUser> signInManager)
        {
            this.usermanger = usermanger;
           this.signInManager = signInManager;
        }

        public UserManager<IdentityUser> usermanger { get; }
        public SignInManager<IdentityUser> signInManager { get; }
        public async Task<IActionResult> Signup() {
            
            return View();

        }
        [HttpPost]
        public  async Task<IActionResult>  Signup(SignUpVM model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()

                {
                    UserName = model.UserName,
                    Email = model.Email,

                };
               var rslt=await usermanger.CreateAsync(user,model.Password);
                if (rslt.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else {

                    foreach (var error in rslt.Errors)
                    {

                        ModelState.AddModelError("", error.Description);
                    
                    }
                
                
                }
            
            
            }
            return View(model);
        }


        public IActionResult Login()
        {


            return View();        
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
              
                var rslt= await  signInManager.PasswordSignInAsync(model.UserName, model.password,model.remberMe,false);
                if (rslt.Succeeded)
                {
                    return RedirectToAction("Index","Home");

                }
                else {
                   ModelState.AddModelError("", "Invalid Username or password");
                   
                
                }


             }

            return View(model);
        }
        public async  Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Redirect("Login");
        
        
        
        }

    }
}
