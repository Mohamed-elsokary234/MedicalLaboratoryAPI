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
    ///     Defines the <see cref="billsController" /> .
    /// </summary>
    public class billsController : ApiController
    {
        /// <summary>
        ///     Defines the db.
        /// </summary>
        private MedicalLaboratoryContext db = new MedicalLaboratoryContext();

        // DELETE: api/bills/5
        /// <summary>
        ///     The Deletebill.
        /// </summary>
        /// <param name="id">The id <see cref="System.Int32" /> .</param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(bill))]
        public IHttpActionResult Deletebill(int id)
        {
            var bill = this.db.bills.Find(id);
            if (bill == null) return this.NotFound();

            this.db.bills.Remove(bill);
            this.db.SaveChanges();

            return this.Ok(bill);
        }

        // GET: api/bills/{id}
        /// <summary>
        ///     The Getbill.
        /// </summary>
        /// <param name="id">The id <see cref="System.Int32" /> .</param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(bill))]
        public IHttpActionResult Getbill(int id)
        {
            var bill = this.db.bills.Find(id);
            if (bill == null) return this.NotFound();

            return this.Ok(bill);
        }

        // GET: api/bills
        /// <summary>
        ///     The Getbills.
        /// </summary>
        /// <returns>
        ///     The <see cref="System.Linq.IQueryable" /> .
        /// </returns>
        public IQueryable<bill> Getbills()
        {
            return this.db.bills;
        }

        // POST: api/bills
        /// <summary>
        ///     The Postbill.
        /// </summary>
        /// <param name="bill">
        ///     The bill <see cref="MedicalLaboratoryITI.Models.bill" /> .
        /// </param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(bill))]
        public IHttpActionResult Postbill(bill bill)
        {
            if (!this.ModelState.IsValid) return this.BadRequest(this.ModelState);

            this.db.bills.Add(bill);
            this.db.SaveChanges();
            return this.CreatedAtRoute("DefaultApi", new { id = bill.bill_Id }, bill);
        }

        // PUT: api/bills/{id}
        /// <summary>
        ///     The Putbill.
        /// </summary>
        /// <param name="id">The id <see cref="System.Int32" /> .</param>
        /// <param name="bill">
        ///     The bill <see cref="MedicalLaboratoryITI.Models.bill" /> .
        /// </param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult Putbill(int id, bill bill)
        {
            if (!this.ModelState.IsValid) return this.BadRequest(this.ModelState);

            if (id != bill.bill_Id) return this.BadRequest();

            this.db.Entry(bill).State = EntityState.Modified;
            var billExists = this.db.bills.Count(e => e.bill_Id == id) > 0;
            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!billExists) return this.NotFound();
                throw;
            }

            return this.StatusCode(HttpStatusCode.NoContent);
        }
    }
}