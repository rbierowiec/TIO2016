using Library1;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class BooksController : ApiController
    {

        BookManager.Service1 bookManager = new BookManager.Service1();

        // GET api/books
        public HttpResponseMessage Get()
        {
            try
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, bookManager.GetAllBooks());
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
                return this.Request.CreateResponse(HttpStatusCode.OK, bookManager.GetAllBooks().Where(x => x.BookTitle.Contains(search)));
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        // POST api/books
        public HttpResponseMessage Post([FromBody]Book value)
        {
            try
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, bookManager.Add(value));
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        // PUT api/books/5
        public HttpResponseMessage Put(int id, [FromBody]Book value)
        {
            try
            {
                value.Id = id;
                return this.Request.CreateResponse(HttpStatusCode.OK, bookManager.Update(value));
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
                return this.Request.CreateResponse(HttpStatusCode.OK, bookManager.Delete(id));
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
    }
}
