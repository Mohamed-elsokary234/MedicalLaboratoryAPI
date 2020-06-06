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
    ///     Defines the <see cref="phonesController" /> .
    /// </summary>
    public class phonesController : ApiController
    {
        /// <summary>
        ///     Defines the db.
        /// </summary>
        private MedicalLaboratoryContext db = new MedicalLaboratoryContext();

        // DELETE: api/phones/{id}
        /// <summary>
        ///     The Deletephone.
        /// </summary>
        /// <param name="id">The id <see cref="System.String" /> .</param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(phone))]
        public IHttpActionResult Deletephone(string id)
        {
            var phone = this.db.phones.Find(id);
            if (phone == null) return this.NotFound();

            this.db.phones.Remove(phone);
            this.db.SaveChanges();

            return this.Ok(phone);
        }

        // GET: api/phones/{id}
        /// <summary>
        ///     The Getphone.
        /// </summary>
        /// <param name="id">The id <see cref="System.String" /> .</param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(phone))]
        public IHttpActionResult Getphone(string id)
        {
            var phone = this.db.phones.Find(id);
            if (phone == null) return this.NotFound();

            return this.Ok(phone);
        }

        // GET: api/phones
        /// <summary>
        ///     The Getphones.
        /// </summary>
        /// <returns>
        ///     The <see cref="System.Linq.IQueryable" /> .
        /// </returns>
        public IQueryable<phone> Getphones()
        {
            return this.db.phones;
        }

        // POST: api/phones
        /// <summary>
        ///     The Postphone.
        /// </summary>
        /// <param name="phone">
        ///     The phone <see cref="MedicalLaboratoryITI.Models.phone" /> .
        /// </param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(phone))]
        public IHttpActionResult Postphone(phone phone)
        {
            if (!this.ModelState.IsValid) return this.BadRequest(this.ModelState);

            this.db.phones.Add(phone);
            var phoneExists = this.db.phones.Count(e => e.phone_num == phone.phone_num) > 0;
            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (phoneExists) return this.Conflict();
                throw;
            }

            return this.CreatedAtRoute("DefaultApi", new { id = phone.phone_num }, phone);
        }

        // PUT: api/phones/5
        /// <summary>
        ///     The Putphone.
        /// </summary>
        /// <param name="id">The id <see cref="System.String" /> .</param>
        /// <param name="phone">
        ///     The phone <see cref="MedicalLaboratoryITI.Models.phone" /> .
        /// </param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult Putphone(string id, phone phone)
        {
            if (!this.ModelState.IsValid) return this.BadRequest(this.ModelState);

            if (id != phone.phone_num) return this.BadRequest();

            this.db.Entry(phone).State = EntityState.Modified;
            var phoneExists = this.db.phones.Count(e => e.phone_num == id) > 0;
            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!phoneExists) return this.NotFound();
                throw;
            }

            return this.StatusCode(HttpStatusCode.NoContent);
        }
    }
}