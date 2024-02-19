using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmuraTest.Data;
using AmuraTest.Models;

namespace AmuraTest.Repositories
{
    public class ProductRepo
    {
        BackContext context;
        
        public ProductRepo(BackContext Context) { this.context = Context; }

        #region Get
        public List<Product> GetProducts()
        {
            var query = from datos in this.context.Products
                        select datos;
            return query.ToList();
        }

        public Product GetProduct(string TitleSelected)
        {
            var query = from datos in this.context.Products
                        where datos.title == TitleSelected
                        select datos;

            return query.FirstOrDefault();
        }
        #endregion
    }
}
