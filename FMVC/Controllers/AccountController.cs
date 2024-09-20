using FMVC.Data;
using FMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FMVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
public class AccountController : Controller
{
    ApplicationDbContext context;
    public AccountController(ApplicationDbContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
    public IActionResult Login() => View();

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        var user = context.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);
        if (user == null)
        {
            ViewBag.Error = "Invalid credentials";
            return View();
        }

        // Set role in session or claims
      
        return RedirectToAction("Index", user.Role == "Admin" ? "Admin" : "User");
    }

    [HttpGet]
    public IActionResult Register() => View();

    [HttpPost]
    public IActionResult Register(string username, string password ,int Id)
    {
        var count = 0;
        Id = count++;
    var user = new User { UserName = username, Password = password,UserId=Id };
        if (username== "leenAdmin"&& password=="123")
        {
            user.Role = "Admin";
        }
        else
        {
            user.Role = "User";
        }
        
       

        context.Users.Add(user);
        context.SaveChanges();
        return RedirectToAction("Login()");
    }


}

