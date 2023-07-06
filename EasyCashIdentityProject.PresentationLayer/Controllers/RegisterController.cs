using EasyCashIdentityProject.DtoLayer.Dtos.AppUserDtos;
using EasyCashIdentityProject.EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;


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
                Random random = new Random();
                int code;
                code = random.Next(100000, 1000000);
                AppUser appUser = new AppUser()
                {
                    UserName = appUserAddDto.Username,
                    Name = appUserAddDto.Name,
                    Surname = appUserAddDto.Surname,
                    Email = appUserAddDto.Email,
                    City="İstanbul",
                    District="Kartal",
                    ImageUrl="Manzara",
                    ConfirmCode=code
                  
                  
                };
                var result = await _userManager.CreateAsync(appUser, appUserAddDto.Password);
                if (result.Succeeded)
                {

                    // Mail gönderme kodu ilk olarak projeye mailkit eklenir nuget managerdam ardından aşşağıdaki kodlar yazılır.
                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Easy Cash Admin", "tolunayyilmaz011@gmail.com");
                    MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);
                    mimeMessage.From.Add(mailboxAddressFrom);
                    mimeMessage.To.Add(mailboxAddressTo);

                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = "Kayıt işlemi gerçekleştirmek için onay kodunuz:  "+code;
                    mimeMessage.Body = bodyBuilder.ToMessageBody();

                    mimeMessage.Subject = "Easy Cash Onay Kodu";

                    SmtpClient smtpClient = new SmtpClient();

                    smtpClient.Connect("smtp.gmail.com",587,false);
                    smtpClient.Authenticate("tolunayyilmaz011@gmail.com", "hguurnctwvxyjqdu");
                    smtpClient.Send(mimeMessage);
                    smtpClient.Disconnect(true);
                    //
                    TempData["Mail"] = appUser.Email;

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

    //hguurnctwvxyjqdu
}
