using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
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


        //// PUT: api/ProductsAPI/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutProduct(int id, Product product)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != product.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(product).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProductExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/ProductsAPI
        //[ResponseType(typeof(Product))]
        //public async Task<IHttpActionResult> PostProduct(Product product)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Products.Add(product);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        //}

        //// DELETE: api/ProductsAPI/5
        //[ResponseType(typeof(Product))]
        //public async Task<IHttpActionResult> DeleteProduct(int id)
        //{
        //    Product product = await db.Products.FindAsync(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Products.Remove(product);
        //    await db.SaveChangesAsync();

        //    return Ok(product);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool ProductExists(int id)
        //{
        //    return db.Products.Count(e => e.Id == id) > 0;
        //}
    }
}