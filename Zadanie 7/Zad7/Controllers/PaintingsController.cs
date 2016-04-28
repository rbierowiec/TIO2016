using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;
using Zad7.Interfaces;
using Zad7.Models;

namespace Zad7.Controllers
{
    public class PaintingsController : ApiController
    {
        private readonly IPaintingsRepository db;
        private readonly ILogger logger;

        public PaintingsController(IPaintingsRepository _db, ILogger _logger)
        {
            db = _db;
            logger = _logger;
        }

        // GET api/artists
        public IEnumerable<Painting> Get()
        {
            logger.Write("Get for Paintings was called", LogLevel.INFO);
            return db.GetAllPaintings();
        }

        // GET api/artists/5
        public Painting Get(int id)
        {
            logger.Write("Get for Paintings was called", LogLevel.INFO);
            return db.GetPainting(id);
        }

        // POST api/artists
        public void Post([FromBody]Painting value)
        {
            db.AddPainting(value);
        }

        // PUT api/artists/5
        public void Put(int id, [FromBody]Painting value)
        {
            logger.Write("Put for Paintings was called", LogLevel.INFO);
            db.UpdatePainting(value);
        }

        // DELETE api/artists/5
        public void Delete(int id)
        {
            db.DeletePainting(id);
        }
    }
}