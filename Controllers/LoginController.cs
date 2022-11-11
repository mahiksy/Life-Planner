using cis4951.sprint.w41._4.Models;
using cis4951.sprint.w41._4.Services;
using Microsoft.AspNetCore.Mvc;

namespace cis4951.sprint.w41._4.Controllers
{
     public class LoginController : Controller
     {
          public IActionResult Index()
          {
               return View();
          }

          public IActionResult ProcessLogin(UserModel userModel)
          {
               SecurityService securityService = new SecurityService();
               
               if (securityService.isValid(userModel))
               {
                    return View("LoginSuccess", userModel);
               }
               else
               {
                    return View("LoginFailure", userModel);
               }
               
          }
     }
}
