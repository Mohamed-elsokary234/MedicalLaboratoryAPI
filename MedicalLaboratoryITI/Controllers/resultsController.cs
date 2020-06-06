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
    ///     Defines the <see cref="resultsController" /> .
    /// </summary>
    public class resultsController : ApiController
    {
        /// <summary>
        ///     Defines the db.
        /// </summary>
        private MedicalLaboratoryContext db = new MedicalLaboratoryContext();

        // DELETE: api/results/{id}
        /// <summary>
        ///     The Deleteresult.
        /// </summary>
        /// <param name="id">The id <see cref="System.Int32" /> .</param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(result))]
        public IHttpActionResult Deleteresult(int id)
        {
            var result = this.db.results.Find(id);
            if (result == null) return this.NotFound();

            this.db.results.Remove(result);
            this.db.SaveChanges();

            return this.Ok(result);
        }

        // GET: api/results/{id}
        /// <summary>
        ///     The Getresult.
        /// </summary>
        /// <param name="id">The id <see cref="System.Int32" /> .</param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(result))]
        public IHttpActionResult Getresult(int id)
        {
            var result = this.db.results.Find(id);
            if (result == null) return this.NotFound();

            return this.Ok(result);
        }

        // GET: api/results
        /// <summary>
        ///     The Getresults.
        /// </summary>
        /// <returns>
        ///     The <see cref="System.Linq.IQueryable`1" /> .
        /// </returns>
        public IQueryable<result> Getresults()
        {
            return this.db.results;
        }

        // POST: api/results
        /// <summary>
        ///     The Postresult.
        /// </summary>
        /// <param name="result">
        ///     The result <see cref="MedicalLaboratoryITI.Models.result" /> .
        /// </param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(result))]
        public IHttpActionResult Postresult(result result)
        {
            if (!this.ModelState.IsValid) return this.BadRequest(this.ModelState);

            this.db.results.Add(result);
            var resultExists = this.db.results.Count(e => e.pat_Id_fk == result.pat_Id_fk) > 0;
            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (resultExists) return this.Conflict();
                throw;
            }

            return this.CreatedAtRoute("DefaultApi", new { id = result.pat_Id_fk }, result);
        }

        // PUT: api/results/{id}
        /// <summary>
        ///     The Putresult.
        /// </summary>
        /// <param name="id">The id <see cref="System.Int32" /> .</param>
        /// <param name="result">
        ///     The result <see cref="MedicalLaboratoryITI.Models.result" /> .
        /// </param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult Putresult(int id, result result)
        {
            if (!this.ModelState.IsValid) return this.BadRequest(this.ModelState);

            if (id != result.pat_Id_fk) return this.BadRequest();

            this.db.Entry(result).State = EntityState.Modified;
            var resultExists = this.db.results.Count(e => e.pat_Id_fk == id) > 0;

            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!resultExists) return this.NotFound();
                throw;
            }

            return this.StatusCode(HttpStatusCode.NoContent);
        }
    }
}