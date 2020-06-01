using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Vegan.Database;
using Vegan.Entities;
using Vegan.Services;

namespace Vegan.Web.ControllersAPI
{
    public class ProductsAPIController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        // GET: api/ProductsAPI
        public IEnumerable<Product> GetProducts()
        {
            return unitOfWork.Products.GetAll();
        }

        // GET: api/ProductsAPI/5
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> GetProduct(int id)
        {
            var product = unitOfWork.Products.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
    }
}