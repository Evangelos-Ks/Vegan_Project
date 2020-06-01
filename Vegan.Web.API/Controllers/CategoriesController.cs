using System.Collections.Generic;
using System.Web.Http;
using Vegan.Database;
using Vegan.Entities;
using Vegan.Services;

namespace Vegan.Web.API.Controllers
{
    public class CategoriesController : ApiController
    {
        
        // GET: api/Categories
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        /// <summary>
        /// This will bring all of the categories with the products including the orders in which they were included
        /// </summary>
        // GET: api/Products
        public IEnumerable<IEnumerable<Product>> GetProducts()
        {
            List<IEnumerable<Product>> allCategories = new List<IEnumerable<Product>>();

            allCategories.Add(unitOfWork.Cares.GetAll());
            allCategories.Add(unitOfWork.FoodHerbs.GetAll());
            allCategories.Add(unitOfWork.Homes.GetAll());
            allCategories.Add(unitOfWork.Supplements.GetAll());

            return allCategories;
        }
    }
}