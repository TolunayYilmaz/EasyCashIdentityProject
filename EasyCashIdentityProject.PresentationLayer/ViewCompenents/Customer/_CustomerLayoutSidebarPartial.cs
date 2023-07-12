using Microsoft.AspNetCore.Mvc;
namespace EasyCashIdentityProject.PresentationLayer.ViewCompenents.Customer
{
    public class _CustomerLayoutSidebarPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
