using System.Collections.Generic;
using System.Threading.Tasks;
using Hackathon.Foundation.OrderCloud.Models;
using Hackathon.Foundation.OrderCloud.Services;
using Microsoft.AspNetCore.Mvc;
using OrderCloud.SDK;
using Sitecore.AspNet.RenderingEngine.Binding;

namespace Hackathon.Foundation.OrderCloud.ViewComponents
{
    public class CatalogViewComponent : ViewComponent
    {
        private readonly IViewModelBinder _modelBinder;
        private readonly IOrderCloudService _orderCloudService;
        public CatalogViewComponent(IViewModelBinder modelBinder, IOrderCloudService orderCloudService)
        {
            _modelBinder = modelBinder;
            _orderCloudService = orderCloudService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            IList<Product> products = null;

            var model = await _modelBinder.Bind<CatalogModel>(this.ViewContext);
            if (!string.IsNullOrEmpty(model.CatalogId?.Value))
            {
                products = await _orderCloudService.GetProducts(model.CatalogId?.Value);
            }
 
            return View(products);
        }
    }
}
