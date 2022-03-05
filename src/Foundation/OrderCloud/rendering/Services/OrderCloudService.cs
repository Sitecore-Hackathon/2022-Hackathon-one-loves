using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using Microsoft.CSharp.RuntimeBinder;
using OrderCloud.SDK;

namespace Hackathon.Foundation.OrderCloud.Services
{
    public class OrderCloudService : IOrderCloudService
    {
        private readonly IOrderCloudClient _client;
        private const string DefaultCatalogId = "004";
        string clientId = "3FC135FA-3974-45A7-9956-24008AF6139C";
        string clientSecret = "FQsSnUPREzsmvHvGiFGP2FWT6Bg0axkTblXvevPWt1plk0j3fd53Nik83YUm";
        string apiUrl = "https://sandboxapi.ordercloud.io";
        string authUrl = "https://sandboxapi.ordercloud.io";

        public OrderCloudService()
        {
            _client = new OrderCloudClient(new OrderCloudClientConfig
            {
                ApiUrl = apiUrl,
                AuthUrl = authUrl,
                ClientId = clientId,
                ClientSecret = clientSecret,
                GrantType = GrantType.ClientCredentials,
                Roles = new ApiRole[]{ ApiRole.CatalogAdmin,
                    ApiRole.CategoryAdmin,
                    ApiRole.PriceScheduleAdmin,
                    ApiRole.ProductAdmin,
                    ApiRole.ProductAssignmentAdmin,
                    ApiRole.ProductFacetAdmin,
                    ApiRole.OrderAdmin,ApiRole.FullAccess}

            });
        }

        delegate string GetValueDelegate();

        bool IsProperty(GetValueDelegate getValueMethod)
        {
            try
            {
                var v = getValueMethod();
                return v != null;
            }
            catch (RuntimeBinderException)
            {
                return false;
            }
            catch
            {
                return true;
            }
        }

        public bool HasProperty(ExpandoObject obj, string propertyName)
        {
            return obj != null && ((IDictionary<string, object>)obj).ContainsKey(propertyName);
        }

        public async Task<IList<Product>> GetProducts(string catalogId = DefaultCatalogId, int page=1, int size=100)
        {
            var result = await _client.Products.ListAsync(catalogId, page: page, pageSize: size);
            return result?.Items;
        }

        public async Task<Product> GetProductById(string productId)
        {
            return await _client.Products.GetAsync(productId);
        }

        public async Task<Order> Checkout(Order order)
        {
            return await _client.Orders.CreateAsync(OrderDirection.Incoming, order);
        }

    }
}
