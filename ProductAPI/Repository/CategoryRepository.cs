using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryAPI
{
    public static class CategoryRepository
    {
        public static async Task<IEnumerable<Category>> Get(int? categoryId)
        {
            IEnumerable<Category> categories = new List<Category>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["connectionString"]))
            {
                await connection.OpenAsync();
                var predicate = categoryId.HasValue ? Predicates.Field<Category>(f => f.CategoryID, Operator.Eq, categoryId.Value) : null;
                categories = await connection.GetListAsync<Category>(predicate);
                connection.Close();
            }

            return categories;
        }
    }
}
