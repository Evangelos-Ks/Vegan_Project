using System.Collections.Generic;
using System.Web.Http;
using Vegan.Database;
using Vegan.Entities;
using Vegan.Services;

namespace Vegan.Web.ControllersAPI
{
    public class OrdersAPIController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new MyDatabase());

        // GET: api/OrdersAPI
        public IEnumerable<Order> GetOrders()
        {
            return unitOfWork.Orders.GetAll();
        }
    }
}