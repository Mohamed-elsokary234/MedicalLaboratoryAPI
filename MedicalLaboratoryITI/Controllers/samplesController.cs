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
    ///     Defines the <see cref="samplesController" /> .
    /// </summary>
    public class samplesController : ApiController
    {
        /// <summary>
        ///     Defines the db.
        /// </summary>
        private MedicalLaboratoryContext db = new MedicalLaboratoryContext();

        // DELETE: api/samples/{id}
        /// <summary>
        ///     The Deletesample.
        /// </summary>
        /// <param name="id">The id <see cref="System.Int32" /> .</param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(sample))]
        public IHttpActionResult Deletesample(int id)
        {
            var sample = this.db.samples.Find(id);
            if (sample == null) return this.NotFound();

            this.db.samples.Remove(sample);
            this.db.SaveChanges();

            return this.Ok(sample);
        }

        // GET: api/samples/{id}
        /// <summary>
        ///     The Getsample.
        /// </summary>
        /// <param name="id">The id <see cref="System.Int32" /> .</param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(sample))]
        public IHttpActionResult Getsample(int id)
        {
            var sample = this.db.samples.Find(id);
            if (sample == null) return this.NotFound();

            return this.Ok(sample);
        }

        // GET: api/samples
        /// <summary>
        ///     The Getsamples.
        /// </summary>
        /// <returns>
        ///     The <see cref="System.Linq.IQueryable`1" /> .
        /// </returns>
        public IQueryable<sample> Getsamples()
        {
            return this.db.samples;
        }

        // POST: api/samples
        /// <summary>
        ///     The Postsample.
        /// </summary>
        /// <param name="sample">
        ///     The sample <see cref="MedicalLaboratoryITI.Models.sample" /> .
        /// </param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(sample))]
        public IHttpActionResult Postsample(sample sample)
        {
            if (!this.ModelState.IsValid) return this.BadRequest(this.ModelState);

            this.db.samples.Add(sample);
            this.db.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = sample.sample_Id }, sample);
        }

        // PUT: api/samples/{id}
        /// <summary>
        ///     The Putsample.
        /// </summary>
        /// <param name="id">The id <see cref="System.Int32" /> .</param>
        /// <param name="sample">
        ///     The sample <see cref="MedicalLaboratoryITI.Models.sample" /> .
        /// </param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult Putsample(int id, sample sample)
        {
            if (!this.ModelState.IsValid) return this.BadRequest(this.ModelState);

            if (id != sample.sample_Id) return this.BadRequest();

            this.db.Entry(sample).State = EntityState.Modified;
            var sampleExists = this.db.samples.Count(e => e.sample_Id == id) > 0;
            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!sampleExists) return this.NotFound();
                throw;
            }

            return this.StatusCode(HttpStatusCode.NoContent);
        }
    }
}