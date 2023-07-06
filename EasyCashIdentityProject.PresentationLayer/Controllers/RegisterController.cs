using EasyCashIdentityProject.DtoLayer.Dtos.AppUserDtos;
using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserAddDto appUserAddDto)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    UserName = appUserAddDto.Username,
                    Name = appUserAddDto.Name,
                    Surname = appUserAddDto.Surname,
                    Email = appUserAddDto.Email,
                    City="İstanbul",
                    District="Kartal",
                    ImageUrl="Manzara"
                   
                  
                };
                var result = await _userManager.CreateAsync(appUser, appUserAddDto.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","ConfirmMail");
                }
                else
                {// girdileri inceler hatalı girdiyi döner.
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }
    }
    //Identity sınıfında şifre
    //en az 6 karakter olmalıdır
    //en az 1 büyük harf
    // en az 1 küçük harf
    //en az 1 sembol
    //en az 1 sayı içermeli
}
