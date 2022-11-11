using cis4951.sprint.w41._4.Models;
using cis4951.sprint.w41._4.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace cis4951.sprint.w41._4.Controllers
{
     public class lp : Controller
     {
          public IActionResult Index()
          {
               //temp
               //return View()
               return View();
          }

          //temp
          public IActionResult Ex()
          {
               return View("Index");
          }

          public IActionResult AddUserModel()
          {            
               UsersDAO d = new UsersDAO();
               //temp
               IdList idList = new IdList(); 
               idList.add(1);
               idList.add(3);

               List <UserModel> users = d.GetUser(idList.getid());


                return View("ViewUserModel", users);
               
          }
     }
}
