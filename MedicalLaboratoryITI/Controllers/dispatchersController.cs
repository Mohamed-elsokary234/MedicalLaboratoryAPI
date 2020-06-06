namespace MedicalLaboratoryITI.Controllers
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Description;

    using MedicalLaboratoryITI.Models;

    /// <summary>
    ///     Defines the <see cref="dispatchersController" /> .
    /// </summary>
    public class dispatchersController : ApiController
    {
        /// <summary>
        ///     Defines the db.
        /// </summary>
        private MedicalLaboratoryContext db = new MedicalLaboratoryContext();

        // DELETE: api/dispatchers/{id}
        /// <summary>
        ///     The Deletedispatcher.
        /// </summary>
        /// <param name="id">The id <see cref="System.Int32" /> .</param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(dispatcher))]
        public IHttpActionResult Deletedispatcher(int id)
        {
            var dispatcher = this.db.dispatchers.Find(id);
            if (dispatcher == null) return this.NotFound();

            this.db.dispatchers.Remove(dispatcher);
            this.db.SaveChanges();

            return this.Ok(dispatcher);
        }

        // GET: api/dispatchers/5
        /// <summary>
        ///     The Getdispatcher.
        /// </summary>
        /// <param name="id">The id <see cref="System.Int32" /> .</param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(dispatcher))]
        public IHttpActionResult Getdispatcher(int id)
        {
            var dispatcher = this.db.dispatchers.Find(id);
            if (dispatcher == null) return this.NotFound();

            return this.Ok(dispatcher);
        }

        // GET: api/dispatchers
        /// <summary>
        ///     The Getdispatchers.
        /// </summary>
        /// <returns>
        ///     The <see cref="System.Linq.IQueryable`1" /> .
        /// </returns>
        public IQueryable<dispatcher> Getdispatchers()
        {
            return this.db.dispatchers;
        }

        // POST: api/dispatchers
        /// <summary>
        ///     The Postdispatcher.
        /// </summary>
        /// <param name="dispatcher">
        ///     The dispatcher <see cref="MedicalLaboratoryITI.Models.dispatcher" />
        ///     .
        /// </param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(dispatcher))]
        public IHttpActionResult Postdispatcher(dispatcher dispatcher)
        {
            if (!this.ModelState.IsValid) return this.BadRequest(this.ModelState);

            this.db.dispatchers.Add(dispatcher);
            this.db.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = dispatcher.dis_Id }, dispatcher);
        }

        // PUT: api/dispatchers/5
        /// <summary>
        ///     The Putdispatcher.
        /// </summary>
        /// <param name="id">The id <see cref="System.Int32" /> .</param>
        /// <param name="dispatcher">
        ///     The dispatcher <see cref="MedicalLaboratoryITI.Models.dispatcher" />
        ///     .
        /// </param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult Putdispatcher(int id, dispatcher dispatcher)
        {
            if (!this.ModelState.IsValid) return this.BadRequest(this.ModelState);

            if (id != dispatcher.dis_Id) return this.BadRequest();

            this.db.Entry(dispatcher).State = EntityState.Modified;
            var dispatcherExists = this.db.dispatchers.Count(e => e.dis_Id == id) > 0;
            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!dispatcherExists) return this.NotFound();
                throw;
            }

            return this.StatusCode(HttpStatusCode.NoContent);
        }
    }
}