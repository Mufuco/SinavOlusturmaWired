using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectTek.CoreLayer.Repositoires.UserRep;
using ProjectTek.EntityLayer.Entities;
using System.Security.Claims;

namespace ProjectTek.Controllers
{
    public class UserController : Controller
    {
        readonly private IUserWriteRepository _userWrite;
        readonly private IUserReadRepository _userRead;

        public UserController(IUserWriteRepository userWrite, IUserReadRepository userRead)
        {
            _userWrite = userWrite;
            _userRead = userRead;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {

            
            
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(User p)
        {

            User data =_userRead.GetSingle(x=>x.UserName==p.UserName && x.Password==p.Password);

            if (data != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,p.UserName)
                };
                var useridentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index","WeridArticle");
            }
            else if (!ModelState.IsValid)
            {
                var messages = ModelState.ToList();
                return View();
            }
            else
            {
                ViewData["LoginFlag"] = "Yanlış kullanıcı adı veya şifre girdiniz!";
                return View();
            }
            
        }
    }
}
