using BTTLDay03.Models;
using Microsoft.AspNetCore.Mvc;

namespace BTTLDay03.ViewComponents
{
    public class HotProductViewComponent : ViewComponent
    {
        protected Product product = new Product();

        public IViewComponentResult Invoke()
        {
            var products = product.GetProductsList();
            return View(products);
        }
    }
}
