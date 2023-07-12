using Microsoft.AspNetCore.Mvc;
namespace EasyCashIdentityProject.PresentationLayer.ViewCompenents.Customer
{
    public class _CustomerLayoutNavbarPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
