using System.Collections.Generic;
using System.Web.Http;
using Vegan.Database;
using Vegan.Entities;
using Vegan.Services;

namespace Vegan.Web.ControllersAPI
{
    public class CategoriesAPIController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        // GET: api/CategoriesAPI
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