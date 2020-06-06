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
    ///     Defines the <see cref="testsController" /> .
    /// </summary>
    public class testsController : ApiController
    {
        /// <summary>
        ///     Defines the db.
        /// </summary>
        private MedicalLaboratoryContext db = new MedicalLaboratoryContext();

        // DELETE: api/tests/{id}
        /// <summary>
        ///     The Deletetest.
        /// </summary>
        /// <param name="id">The id <see cref="System.Int32" /> .</param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(test))]
        public IHttpActionResult Deletetest(int id)
        {
            var test = this.db.tests.Find(id);
            if (test == null) return this.NotFound();

            this.db.tests.Remove(test);
            this.db.SaveChanges();

            return this.Ok(test);
        }

        // GET: api/tests/{id}
        /// <summary>
        ///     The Gettest.
        /// </summary>
        /// <param name="id">The id <see cref="System.Int32" /> .</param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(test))]
        public IHttpActionResult Gettest(int id)
        {
            var test = this.db.tests.Find(id);
            if (test == null) return this.NotFound();

            return this.Ok(test);
        }

        // GET: api/tests
        /// <summary>
        ///     The Gettests.
        /// </summary>
        /// <returns>
        ///     The <see cref="System.Linq.IQueryable`1" /> .
        /// </returns>
        public IQueryable<test> Gettests()
        {
            return this.db.tests;
        }

        // POST: api/tests
        /// <summary>
        ///     The Posttest.
        /// </summary>
        /// <param name="test">
        ///     The test <see cref="MedicalLaboratoryITI.Models.test" /> .
        /// </param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(test))]
        public IHttpActionResult Posttest(test test)
        {
            if (!this.ModelState.IsValid) return this.BadRequest(this.ModelState);

            this.db.tests.Add(test);
            this.db.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = test.test_Id }, test);
        }

        // PUT: api/tests/{id}
        /// <summary>
        ///     The Puttest.
        /// </summary>
        /// <param name="id">The id <see cref="System.Int32" /> .</param>
        /// <param name="test">
        ///     The test <see cref="MedicalLaboratoryITI.Models.test" /> .
        /// </param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttest(int id, test test)
        {
            if (!this.ModelState.IsValid) return this.BadRequest(this.ModelState);

            if (id != test.test_Id) return this.BadRequest();

            this.db.Entry(test).State = EntityState.Modified;
            var testExists = this.db.tests.Count(e => e.test_Id == id) > 0;
            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!testExists) return this.NotFound();
                throw;
            }

            return this.StatusCode(HttpStatusCode.NoContent);
        }
    }
}