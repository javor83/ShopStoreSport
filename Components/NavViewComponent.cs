using Microsoft.AspNetCore.Mvc;
using ShopStoreSport.database;
using ShopStoreSport.Models;

namespace ShopStoreSport.Components
{
    public class NavViewComponent : ViewComponent
    {
        private IStoreRepository rp = null;
        public NavViewComponent(IStoreRepository sp)
        {
            rp = sp;
        }

        public IViewComponentResult Invoke(int? category)
        {
            IEnumerable<Category> list = rp.GetCategories();
            ViewBag.category = category;
            return View(list);
        }

    }
}
