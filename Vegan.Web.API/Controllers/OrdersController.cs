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
    public class OrdersController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        /// <summary>
        /// This will bring all the orders 
        /// </summary>
        // GET: api/Orders
        public IEnumerable<Order> GetOrders()
        {
            return unitOfWork.Orders.GetAll();
        }


    }
}