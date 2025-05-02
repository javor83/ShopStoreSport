using Microsoft.AspNetCore.Mvc;
using ShopStoreSport.Models;

namespace ShopStoreSport.Views.Shared
{
    public class NavViewComponent:ViewComponent
    {
        private IStoreRepository rp = null;
        public NavViewComponent(IStoreRepository sp)
        {
            this.rp = sp;
        }

        public IViewComponentResult Invoke()
        {
            
        }

    }
}
