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
    ///     Defines the <see cref="departmentsController" /> .
    /// </summary>
    public class departmentsController : ApiController
    {
        /// <summary>
        ///     Defines the db.
        /// </summary>
        private MedicalLaboratoryContext db = new MedicalLaboratoryContext();

        // DELETE: api/departments/5
        /// <summary>
        ///     The Deletedepartment.
        /// </summary>
        /// <param name="id">The id <see cref="System.Int32" /> .</param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(department))]
        public IHttpActionResult Deletedepartment(int id)
        {
            var department = this.db.departments.Find(id);
            if (department == null) return this.NotFound();

            this.db.departments.Remove(department);
            this.db.SaveChanges();

            return this.Ok(department);
        }

        // GET: api/departments/{id}
        /// <summary>
        ///     The Getdepartment.
        /// </summary>
        /// <param name="id">The id <see cref="System.Int32" /> .</param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(department))]
        public IHttpActionResult Getdepartment(int id)
        {
            var department = this.db.departments.Find(id);
            if (department == null) return this.NotFound();

            return this.Ok(department);
        }

        // GET: api/departments
        /// <summary>
        ///     The Getdepartments.
        /// </summary>
        /// <returns>
        ///     The <see cref="System.Linq.IQueryable" /> .
        /// </returns>
        public IQueryable<department> Getdepartments()
        {
            return this.db.departments;
        }

        // POST: api/departments
        /// <summary>
        ///     The Postdepartment.
        /// </summary>
        /// <param name="department">
        ///     <para>
        ///         The department <see cref="MedicalLaboratoryITI.Models.department" />
        ///     </para>
        ///     <para>.</para>
        /// </param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(department))]
        public IHttpActionResult Postdepartment(department department)
        {
            if (!this.ModelState.IsValid) return this.BadRequest(this.ModelState);

            this.db.departments.Add(department);
            this.db.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = department.dep_Id }, department);
        }

        // PUT: api/departments/{id}
        /// <summary>
        ///     The Putdepartment.
        /// </summary>
        /// <param name="id">The id <see cref="System.Int32" /> .</param>
        /// <param name="department">
        ///     <para>
        ///         The department <see cref="MedicalLaboratoryITI.Models.department" />
        ///     </para>
        ///     <para>.</para>
        /// </param>
        /// <returns>
        ///     The <see cref="System.Web.Http.IHttpActionResult" /> .
        /// </returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult Putdepartment(int id, department department)
        {
            if (!this.ModelState.IsValid) return this.BadRequest(this.ModelState);

            if (id != department.dep_Id) return this.BadRequest();

            this.db.Entry(department).State = EntityState.Modified;
            var departmentExists = this.db.departments.Count(e => e.dep_Id == id) > 0;
            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!departmentExists) return this.NotFound();
                throw;
            }

            return this.StatusCode(HttpStatusCode.NoContent);
        }
    }
}