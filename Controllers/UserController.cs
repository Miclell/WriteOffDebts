using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using WriteOffDebts.Models;
using WriteOffDebts.Data;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace WriteOffDebts.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public IActionResult Personal()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new UserModel
            {
                UserName = model.UserName,
                Password = model.Password // BCrypt для хеширования паролей
            };

            if (!CheckLoginAndPassword(user))
            {
                return View(model);
            }

            user = _context.Users.FirstOrDefault(u => u.UserName == model.UserName && u.Password == model.Password);
            //поменять поиск, нахуй тут метод CheckUserLogin не сдался

            // Логика аутентификации пользователя
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return RedirectToAction("Personal", "User");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new UserModel
                {
                    UserName = model.UserName,
                    Password = model.Password // BCrypt для хеширования паролей
                };

                if (IsUserNameAvailable(user.UserName))
                {
                    ModelState.AddModelError("UserName", "Пользователь с таким именем уже существует!");
                    return View(model);
                }

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                // Логика регистрации пользователя
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Personal", "User");
            }

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "User");
        }

        public bool IsUserNameAvailable(string userName)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("МЕНЯ ВЫЗЫВАЛИ");

            return _context.Users.Any(x => x.UserName == userName);
        }

        public bool CheckLoginAndPassword(UserModel user) => 
            _context.Users
                .Any(x => x.UserName == user.UserName && x.Password == user.Password);
    }
}
