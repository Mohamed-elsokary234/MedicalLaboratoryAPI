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
    ///     Defines the <see cref="employeesController" /> .
    /// </summary>
    public class employeesController : ApiController
    {
        /// <summary>
        ///     Defines the db.
        /// </summary>
        private MedicalLaboratoryContext db = new MedicalLaboratoryContext();

        // DELETE: api/employees/{id}
        /// <summary>
        ///     The Deleteemployee.
        /// </summary>
        /// <param name="id">The id <see cref="System.Int32" /> .</param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(employee))]
        public IHttpActionResult Deleteemployee(int id)
        {
            var employee = this.db.employees.Find(id);
            if (employee == null) return this.NotFound();

            this.db.employees.Remove(employee);
            this.db.SaveChanges();

            return this.Ok(employee);
        }

        // GET: api/employees/5
        /// <summary>
        ///     The Getemployee.
        /// </summary>
        /// <param name="id">The id <see cref="System.Int32" /> .</param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(employee))]
        public IHttpActionResult Getemployee(int id)
        {
            var employee = this.db.employees.Find(id);
            if (employee == null) return this.NotFound();

            return this.Ok(employee);
        }

        // GET: api/employees
        /// <summary>
        ///     The Getemployees.
        /// </summary>
        /// <returns>
        ///     The <see cref="System.Linq.IQueryable" /> .
        /// </returns>
        public IQueryable<employee> Getemployees()
        {
            return this.db.employees;
        }

        // POST: api/employees
        /// <summary>
        ///     The Postemployee.
        /// </summary>
        /// <param name="employee">
        ///     The employee <see cref="MedicalLaboratoryITI.Models.employee" /> .
        /// </param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(employee))]
        public IHttpActionResult Postemployee(employee employee)
        {
            if (!this.ModelState.IsValid) return this.BadRequest(this.ModelState);

            this.db.employees.Add(employee);
            this.db.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = employee.empl_Id }, employee);
        }

        // PUT: api/employees/{id}
        /// <summary>
        ///     The Putemployee.
        /// </summary>
        /// <param name="id">The id <see cref="System.Int32" /> .</param>
        /// <param name="employee">
        ///     The employee <see cref="MedicalLaboratoryITI.Models.employee" /> .
        /// </param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult Putemployee(int id, employee employee)
        {
            if (!this.ModelState.IsValid) return this.BadRequest(this.ModelState);

            if (id != employee.empl_Id) return this.BadRequest();

            this.db.Entry(employee).State = EntityState.Modified;
            var employeeExists = this.db.employees.Count(e => e.empl_Id == id) > 0;
            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!employeeExists) return this.NotFound();
                throw;
            }

            return this.StatusCode(HttpStatusCode.NoContent);
        }
    }
}