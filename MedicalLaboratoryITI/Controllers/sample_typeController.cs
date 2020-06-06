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
    ///     Defines the <see cref="sample_typeController" /> .
    /// </summary>
    public class sample_typeController : ApiController
    {
        /// <summary>
        ///     Defines the db.
        /// </summary>
        private MedicalLaboratoryContext db = new MedicalLaboratoryContext();

        // DELETE: api/sample_type/{id}
        /// <summary>
        ///     The Deletesample_type.
        /// </summary>
        /// <param name="id">The id <see cref="System.Int32" /> .</param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(sample_type))]
        public IHttpActionResult Deletesample_type(int id)
        {
            var sample_type = this.db.sample_type.Find(id);
            if (sample_type == null) return this.NotFound();

            this.db.sample_type.Remove(sample_type);
            this.db.SaveChanges();

            return this.Ok(sample_type);
        }

        // GET: api/sample_type
        /// <summary>
        ///     The Getsample_type.
        /// </summary>
        /// <returns>
        ///     The <see cref="System.Linq.IQueryable`1" /> .
        /// </returns>
        public IQueryable<sample_type> Getsample_type()
        {
            return this.db.sample_type;
        }

        // GET: api/sample_type/{id}
        /// <summary>
        ///     The Getsample_type.
        /// </summary>
        /// <param name="id">The id <see cref="System.Int32" /> .</param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(sample_type))]
        public IHttpActionResult Getsample_type(int id)
        {
            var sample_type = this.db.sample_type.Find(id);
            if (sample_type == null) return this.NotFound();

            return this.Ok(sample_type);
        }

        // POST: api/sample_type
        /// <summary>
        ///     The Postsample_type.
        /// </summary>
        /// <param name="sample_type">
        ///     The sample_type
        ///     <see cref="MedicalLaboratoryITI.Models.sample_type" /> .
        /// </param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(sample_type))]
        public IHttpActionResult Postsample_type(sample_type sample_type)
        {
            if (!this.ModelState.IsValid) return this.BadRequest(this.ModelState);

            this.db.sample_type.Add(sample_type);
            this.db.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = sample_type.sam_type_Id }, sample_type);
        }

        // PUT: api/sample_type/{id}
        /// <summary>
        ///     The Putsample_type.
        /// </summary>
        /// <param name="id">The id <see cref="System.Int32" /> .</param>
        /// <param name="sample_type">
        ///     The sample_type
        ///     <see cref="MedicalLaboratoryITI.Models.sample_type" /> .
        /// </param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult Putsample_type(int id, sample_type sample_type)
        {
            if (!this.ModelState.IsValid) return this.BadRequest(this.ModelState);

            if (id != sample_type.sam_type_Id) return this.BadRequest();

            this.db.Entry(sample_type).State = EntityState.Modified;
            var sample_typeExists = this.db.sample_type.Count(e => e.sam_type_Id == id) > 0;
            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!sample_typeExists) return this.NotFound();
                throw;
            }

            return this.StatusCode(HttpStatusCode.NoContent);
        }
    }
}