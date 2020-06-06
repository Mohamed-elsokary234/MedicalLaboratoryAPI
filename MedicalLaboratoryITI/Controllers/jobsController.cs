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
    ///     Defines the <see cref="jobsController" /> .
    /// </summary>
    public class jobsController : ApiController
    {
        /// <summary>
        ///     Defines the db.
        /// </summary>
        private MedicalLaboratoryContext db = new MedicalLaboratoryContext();

        // DELETE: api/jobs/{id}
        /// <summary>
        ///     The Deletejob.
        /// </summary>
        /// <param name="id">The id <see cref="System.Int32" /> .</param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(job))]
        public IHttpActionResult Deletejob(int id)
        {
            var job = this.db.jobs.Find(id);
            if (job == null) return this.NotFound();

            this.db.jobs.Remove(job);
            this.db.SaveChanges();

            return this.Ok(job);
        }

        // GET: api/jobs/5
        /// <summary>
        ///     The Getjob.
        /// </summary>
        /// <param name="id">The id <see cref="System.Int32" /> .</param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(job))]
        public IHttpActionResult Getjob(int id)
        {
            var job = this.db.jobs.Find(id);
            if (job == null) return this.NotFound();

            return this.Ok(job);
        }

        // GET: api/jobs
        /// <summary>
        ///     The Getjobs.
        /// </summary>
        /// <returns>
        ///     The <see cref="System.Linq.IQueryable" /> .
        /// </returns>
        public IQueryable<job> Getjobs()
        {
            return this.db.jobs;
        }

        // POST: api/jobs
        /// <summary>
        ///     The Postjob.
        /// </summary>
        /// <param name="job">
        ///     The job <see cref="MedicalLaboratoryITI.Models.job" /> .
        /// </param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(job))]
        public IHttpActionResult Postjob(job job)
        {
            if (!this.ModelState.IsValid) return this.BadRequest(this.ModelState);

            this.db.jobs.Add(job);
            this.db.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = job.job_Id }, job);
        }

        // PUT: api/jobs/{id}
        /// <summary>
        ///     The Putjob.
        /// </summary>
        /// <param name="id">The id <see cref="System.Int32" /> .</param>
        /// <param name="job">
        ///     The job <see cref="MedicalLaboratoryITI.Models.job" /> .
        /// </param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult Putjob(int id, job job)
        {
            if (!this.ModelState.IsValid) return this.BadRequest(this.ModelState);

            if (id != job.job_Id) return this.BadRequest();

            this.db.Entry(job).State = EntityState.Modified;
            var jobExists = this.db.jobs.Count(e => e.job_Id == id) > 0;
            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!jobExists) return this.NotFound();
                throw;
            }

            return this.StatusCode(HttpStatusCode.NoContent);
        }
    }
}