using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using AuthorManager;
using Library1;

namespace WebApplication1.Controllers
{
    public class AuthorsController : ApiController
    {

        AuthorManager.Service1 authorManager = new AuthorManager.Service1();

        // GET api/books
        public HttpResponseMessage Get()
        {
            try
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, authorManager.GetAllAuthors());
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        // GET api/books?search=
        public HttpResponseMessage Get([FromUri] string search)
        {
            try
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, authorManager.GetAllAuthors().Where(x => x.AuthorName.Contains(search)));
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        // POST api/books
        public HttpResponseMessage Post([FromBody]Author value)
        {
            try
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, authorManager.Add(value));
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        // PUT api/books/5
        public HttpResponseMessage Put(int id, [FromBody]Author value)
        {
            try
            {
                value.Id = id;
                return this.Request.CreateResponse(HttpStatusCode.OK, authorManager.Update(value));
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        // DELETE api/books/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, authorManager.Delete(id));
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
    }
}
