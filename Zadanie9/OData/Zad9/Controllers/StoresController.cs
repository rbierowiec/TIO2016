﻿using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using Library;

namespace Zad9.Controllers
{
    public class StoresController : ODataController
    {
        GamesContext db = new GamesContext();

        [EnableQuery]
        public IQueryable<Store> Get()
        {
            return db.Stores;
        }

        [EnableQuery]
        public SingleResult<Store> Get([FromODataUri] int key)
        {
            IQueryable<Store> result = db.Stores.Where(p => p.Id == key);
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(Store Store)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Stores.Add(Store);
            await db.SaveChangesAsync();
            return Created(Store);
        }

        public async Task<IHttpActionResult> Put([FromODataUri] int key, Store update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.Id)
            {
                return BadRequest();
            }
            db.Entry(update).State = EntityState.Modified;
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(update);
        }

        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            var product = await db.Stores.FindAsync(key);
            if (product == null)
            {
                return NotFound();
            }
            db.Stores.Remove(product);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }

        private bool StoreExists(int key)
        {
            return db.Stores.Any(p => p.Id == key);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}