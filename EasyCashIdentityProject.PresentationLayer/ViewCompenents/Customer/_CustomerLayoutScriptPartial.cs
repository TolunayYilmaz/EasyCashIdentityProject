using Microsoft.AspNetCore.Mvc;
namespace EasyCashIdentityProject.PresentationLayer.ViewCompenents.Customer
{
    public class _CustomerLayoutScriptPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
