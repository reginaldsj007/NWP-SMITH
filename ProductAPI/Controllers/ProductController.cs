using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProductAPI
{
    public class ProductController : ApiController
    {
        [HttpGet()]
        public async Task<IEnumerable<Product>> Get(int id)
        {
            IEnumerable<Product> products = new List<Product>();
            return await ProductRepository.Get(id);
        }

        [HttpGet()]
        [ActionName("ByCategory")]
        public async Task<IEnumerable<Product>> GetByCategory(int id)
        {
            IEnumerable<Product> products = new List<Product>();
            return await ProductRepository.GetByCategory(id);
        }

        [HttpPost()]
        public async Task<int> Add(Product p)
        {
            IEnumerable<Product> products = new List<Product>();
            return await ProductRepository.Add(p);
        }

        [HttpPut()]
        public async Task<bool> Update(int id, Product p)
        {
            IEnumerable<Product> products = new List<Product>();
            return await ProductRepository.Update(id, p);
        }

        [HttpDelete()]
        public async Task<bool> Delete(int id)
        {
            bool success = false;
            return await ProductRepository.Delete(id);
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            IEnumerable<Product> products = new List<Product>();
            return await ProductRepository.Get(null);
        }
    }
}
