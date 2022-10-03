using AmazonClone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AmazonClone.Controllers
{
    public class AdminController : Controller
    {
        public AdminController(RoleManager<IdentityRole> roleMg)
        {
            RoleMg = roleMg;
        }
        
        public RoleManager<IdentityRole> RoleMg { get; }
        public IActionResult Index()
        {
            

            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> Index(RoleVM role)
        {
            var myRole = new IdentityRole(role.RoleName);
            var rslt= await RoleMg.CreateAsync(myRole);
            if (rslt.Succeeded)
            {
                RedirectToAction("Index", "Admin");
            }
          
            return View(role);
        }
    }
}
