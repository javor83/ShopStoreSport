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

        public IViewComponentResult Invoke()
        {
            IEnumerable<Category> list = rp.GetCategories();
            return View(list);
        }

    }
}
