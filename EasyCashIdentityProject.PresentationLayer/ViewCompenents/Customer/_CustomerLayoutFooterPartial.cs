using Microsoft.AspNetCore.Mvc;
namespace EasyCashIdentityProject.PresentationLayer.ViewCompenents.Customer
{
    public class _CustomerLayoutFooterPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
