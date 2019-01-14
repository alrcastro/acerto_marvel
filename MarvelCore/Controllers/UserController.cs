using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MarvelCore.Models;
using MarvelCore.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarvelCore.Controllers
{
    
    public class UserController : BaseController
    {
        IUserService _userService;
        IHistorySearchService _searchHistoryService;

        public UserController(IUserService userService, IHistorySearchService searchHistoryService) {
            _userService = userService;
            _searchHistoryService = searchHistoryService;
        }
        // GET: /<controller>/
        public IActionResult Login()
        {
            ViewData["NoHeader"] = true;
            return View();
        }

        [Authorize]
        public async Task<IActionResult> List()
        {
            var list = await _searchHistoryService.GetAllHistory(GetUser());
            return View("List",list);

        }

        [Authorize]
        public async Task<IActionResult> DeleteHistory(string id)
        {
            _searchHistoryService.DeleteHistory(GetUser(),id);

            
            return await List();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind] User user)
        {
            if (ModelState.IsValid)
            {
                User logUser = await _userService.Authenticate(user);

                if (logUser != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, logUser.Id)
                    };
                    ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["UserLoginFailed"] = "Login Invalido!";
                    return View();
                }
            }
            else
                return View();

        }
    }
}

