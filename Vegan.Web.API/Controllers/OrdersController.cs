using System.Collections.Generic;
using System.Web.Http;
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