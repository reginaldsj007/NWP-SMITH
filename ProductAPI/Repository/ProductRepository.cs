using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI
{
    public static class ProductRepository
    {
        public static async Task<IEnumerable<Product>> Get(int? productId)
        {
            IEnumerable<Product> products = new List<Product>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["connectionString"]))
            {
                await connection.OpenAsync();
                var predicate = productId.HasValue ? Predicates.Field<Product>(f => f.ProductID, Operator.Eq, productId.Value) : null;
                products = await connection.GetListAsync<Product>(predicate);
                connection.Close();
            }

            return products;
        }
        public static async Task<IEnumerable<Product>> GetByCategory(int? categoryId)
        {
            IEnumerable<Product> products = new List<Product>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["connectionString"]))
            {
                await connection.OpenAsync();                
                var predicate = categoryId.HasValue ? Predicates.Field<Product>(f => f.CategoryID, Operator.Eq, categoryId.Value) : null;
                products = await connection.GetListAsync<Product>(predicate);
                connection.Close();
            }

            return products;
        }

        public static async Task<int> Add(Product p)
        {
            var id = -1;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["connectionString"]))
            {
                await connection.OpenAsync();
                id = await connection.Insert<Product>(p);
                connection.Close();
            }

            return id;
        }
        public static async Task<bool> Update(int productId, Product p)
        {
            bool success = false;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["connectionString"]))
            {
                await connection.OpenAsync();
                var predicate = Predicates.Field<Product>(f => f.ProductID, Operator.Eq, productId);
                success = connection.Update<Product>(p);
                connection.Close();
            }

            return success;
        }

        public static async Task<bool> Delete(int? productId)
        {
            bool success = false;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["connectionString"]))
            {
                await connection.OpenAsync();
                var predicate = productId.HasValue ? Predicates.Field<Product>(f => f.ProductID, Operator.Eq, productId.Value) : null;
                success = connection.Delete<Product>(predicate);
                connection.Close();
            }

            return success;
        }
    }
}
