using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Vegan.Database;
using Vegan.Entities;
using Vegan.Services;

namespace Vegan.Web.API.Controllers
{
    public class CategoriesController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        // GET: api/Categories
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