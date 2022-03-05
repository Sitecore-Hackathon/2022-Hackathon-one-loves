using System.Threading.Tasks;
using Hackathon.Foundation.OrderCloud.Models;
using Hackathon.Foundation.OrderCloud.Services;
using Microsoft.AspNetCore.Mvc;
using OrderCloud.SDK;
using Sitecore.AspNet.RenderingEngine.Binding;

namespace Hackathon.Foundation.OrderCloud.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        private readonly IViewModelBinder _modelBinder;
        private readonly IOrderCloudService _orderCloudService;
        public ProductViewComponent(IViewModelBinder modelBinder, IOrderCloudService orderCloudService)
        {
            _modelBinder = modelBinder;
            _orderCloudService = orderCloudService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Product product = null;

            var model = await _modelBinder.Bind<ProductPageModel>(this.ViewContext);
            if (!string.IsNullOrEmpty(model.ProductId?.Value))
            {
                product = await _orderCloudService.GetProductById(model.ProductId?.Value);
            }
 
            return View(product);
        }
    }
}
