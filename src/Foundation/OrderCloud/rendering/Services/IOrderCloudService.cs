using OrderCloud.SDK;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.Foundation.OrderCloud.Services
{
    public interface IOrderCloudService
    {
        Task<IList<Product>> GetProducts(string catalogId, int page=1, int size=100);
        Task<Product> GetProductById(string productId);
        Task<Order> Checkout(Order order);
    }
}
