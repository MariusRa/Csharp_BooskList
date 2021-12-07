using BookList.Api.viewModels;
using FavoriteBook;
using Microsoft.AspNetCore.Mvc;
using MyBook.Services;

namespace BookList.Api.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _service;
        public AuthController(IUserService service)
        {
            _service = service;
        }
        public IActionResult Index() => RedirectToAction("Registration");
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public  IActionResult Registration(RegistrationViewModel model)
        {
            if (ModelState.IsValid && (model.Password == model.ConfirmPassword))
            {
                User user = new User();
                user.Name = model.Name;
                user.Email = model.Email;
                user.Password = model.Password;

                var myUser = _service.AddUser(user);
                return RedirectToAction("index", "Home");
            }

            return View(model);
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(RegistrationViewModel model)
        {
            var user = _service.CheckUser(model.Email);
            
            if (model.Name == user.Name && model.Password == user.Password)
            {
                return RedirectToAction("index", "Home");
            }

            return View(model);
        }
    }
}
