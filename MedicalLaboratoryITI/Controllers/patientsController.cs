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
    ///     Defines the <see cref="patientsController" /> .
    /// </summary>
    public class patientsController : ApiController
    {
        /// <summary>
        ///     Defines the db.
        /// </summary>
        private MedicalLaboratoryContext db = new MedicalLaboratoryContext();

        // DELETE: api/patients/{id}
        /// <summary>
        ///     The Deletepatient.
        /// </summary>
        /// <param name="id">The id <see cref="System.Int32" /> .</param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(patient))]
        public IHttpActionResult Deletepatient(int id)
        {
            var patient = this.db.patients.Find(id);
            if (patient == null) return this.NotFound();

            this.db.patients.Remove(patient);
            this.db.SaveChanges();

            return this.Ok(patient);
        }

        // GET: api/patients/{id}
        /// <summary>
        ///     The Getpatient.
        /// </summary>
        /// <param name="id">The id <see cref="System.Int32" /> .</param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(patient))]
        public IHttpActionResult Getpatient(int id)
        {
            var patient = this.db.patients.Find(id);
            if (patient == null) return this.NotFound();

            return this.Ok(patient);
        }

        // GET: api/patients
        /// <summary>
        ///     The Getpatients.
        /// </summary>
        /// <returns>
        ///     The <see cref="System.Linq.IQueryable" /> .
        /// </returns>
        public IQueryable<patient> Getpatients()
        {
            return this.db.patients;
        }

        // POST: api/patients
        /// <summary>
        ///     The Postpatient.
        /// </summary>
        /// <param name="patient">
        ///     The patient <see cref="MedicalLaboratoryITI.Models.patient" /> .
        /// </param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(patient))]
        public IHttpActionResult Postpatient(patient patient)
        {
            if (!this.ModelState.IsValid) return this.BadRequest(this.ModelState);

            this.db.patients.Add(patient);
            this.db.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = patient.pat_Id }, patient);
        }

        // PUT: api/patients/{id}
        /// <summary>
        ///     The Putpatient.
        /// </summary>
        /// <param name="id">The id <see cref="System.Int32" /> .</param>
        /// <param name="patient">
        ///     The patient <see cref="MedicalLaboratoryITI.Models.patient" /> .
        /// </param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult Putpatient(int id, patient patient)
        {
            if (!this.ModelState.IsValid) return this.BadRequest(this.ModelState);

            if (id != patient.pat_Id) return this.BadRequest();

            this.db.Entry(patient).State = EntityState.Modified;
            var patientExists = this.db.patients.Count(e => e.pat_Id == id) > 0;
            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!patientExists) return this.NotFound();
                throw;
            }

            return this.StatusCode(HttpStatusCode.NoContent);
        }
    }
}