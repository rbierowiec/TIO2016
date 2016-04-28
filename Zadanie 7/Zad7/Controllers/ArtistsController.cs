using System.Collections.Generic;
using System.Web.Mvc;
using Zad7.Interfaces;
using System.Web.Http;
using Zad7.Models;

namespace Zad7.Controllers
{
    public class ArtistsController : ApiController
    {
        private readonly IArtistsRepository db;
        private readonly ILogger logger;

        public ArtistsController(IArtistsRepository _db, ILogger _logger)
        {
            db = _db;
            logger = _logger;
        }

        // GET api/artists
        public IEnumerable<Artist> Get()
        {
            logger.Write("Get for Artists was called", LogLevel.INFO);
            return db.GetAllArtists();
        }

        // GET api/artists/5
        public Artist Get(int id)
        {
            logger.Write("Get for Artists was called", LogLevel.INFO);
            return db.GetArtist(id);
        }

        // POST api/artists
        public void Post([FromBody]Artist value)
        {
            db.AddArtits(value);
        }

        // PUT api/artists/5
        public void Put(int id, [FromBody]Artist value)
        {
            logger.Write("Put for Artists was called", LogLevel.INFO);
            db.UpdateArtist(value);
        }

        // DELETE api/artists/5
        public void Delete(int id)
        {
            db.DeleteArtist(id);
        }
    }
}