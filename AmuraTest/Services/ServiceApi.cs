using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AmuraTest.Models;

namespace AmuraTest.Services
{
    public class ServiceApi
    {
        private Uri uriApi;

        public ServiceApi(String urlApi)
        {
            this.uriApi = new Uri(urlApi);
        }

        #region CallApi
        private async Task<List<Product>> CallApi<T>(String request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = this.uriApi;
                client.DefaultRequestHeaders.Accept.Clear();
                HttpResponseMessage response = await client.GetAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    int first = content.IndexOf("[");
                    int last = content.LastIndexOf("]");
                    string realContent = content.Substring(first, (last-first) + 1);
                    List<Product> products = JsonConvert.DeserializeObject<List<Product>>(realContent);
                    return products;
                }
                else
                {
                    return default(List<Product>);
                }
            }
        }
        #endregion

        #region Get
        public async Task<List<Product>> GetProductsAsync()
        {
            String request = "/products";
            var response = await this.CallApi<List<Product>>(request);
            return response.Take(5).ToList();
        }

        public async Task<List<Product>> GetProducts(string TitleSelected)
        {
            List<Product> listProducts = await this.GetProductsAsync();
            listProducts = listProducts.Where(x => x.title == TitleSelected).ToList();
            return listProducts;
        }
        #endregion
    }
}
