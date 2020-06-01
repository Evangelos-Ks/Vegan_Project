using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using Vegan.Database;
using Vegan.Entities;
using Vegan.Services;

namespace Vegan.Web.API.Controllers
{
    public class ProductsController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        /// <summary>
        /// This will bring all the products including the orders in which they were included
        /// </summary>
        // GET: api/Products
        public IEnumerable<Product> GetProducts()
        {
            return unitOfWork.Products.GetAll();
        }

        /// <summary>
        /// This will bring a product based on id including the orders in which it was included
        /// </summary>
        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
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