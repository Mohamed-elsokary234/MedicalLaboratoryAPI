namespace MedicalLaboratoryITI.Models
{
    using System.Data.Entity;

    /// <summary>
    /// Defines the <see cref="MedicalLaboratoryContext" />.
    /// </summary>
    public partial class MedicalLaboratoryContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MedicalLaboratoryContext"/> class.
        /// </summary>
        public MedicalLaboratoryContext()
            : base("name=MedicalLaboratoryContext")
        {
        }

        /// <summary>
        /// Gets or sets the bills.
        /// </summary>
        public virtual DbSet<bill> bills { get; set; }

        /// <summary>
        /// Gets or sets the departments.
        /// </summary>
        public virtual DbSet<department> departments { get; set; }

        /// <summary>
        /// Gets or sets the dispatchers.
        /// </summary>
        public virtual DbSet<dispatcher> dispatchers { get; set; }

        /// <summary>
        /// Gets or sets the employees.
        /// </summary>
        public virtual DbSet<employee> employees { get; set; }

        /// <summary>
        /// Gets or sets the jobs.
        /// </summary>
        public virtual DbSet<job> jobs { get; set; }

        /// <summary>
        /// Gets or sets the patients.
        /// </summary>
        public virtual DbSet<patient> patients { get; set; }

        /// <summary>
        /// Gets or sets the phones.
        /// </summary>
        public virtual DbSet<phone> phones { get; set; }

        /// <summary>
        /// Gets or sets the results.
        /// </summary>
        public virtual DbSet<result> results { get; set; }

        /// <summary>
        /// Gets or sets the samples.
        /// </summary>
        public virtual DbSet<sample> samples { get; set; }

        /// <summary>
        /// Gets or sets the sample_type.
        /// </summary>
        public virtual DbSet<sample_type> sample_type { get; set; }

        /// <summary>
        /// Gets or sets the tests.
        /// </summary>
        public virtual DbSet<test> tests { get; set; }

        /// <summary>
        /// The OnModelCreating.
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder<see cref="DbModelBuilder"/>.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<bill>()
                .Property(e => e.discount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<bill>()
                .Property(e => e.net)
                .HasPrecision(19, 4);

            modelBuilder.Entity<department>()
                .HasMany(e => e.tests)
                .WithOptional(e => e.department)
                .HasForeignKey(e => e.Dep_fk);

            modelBuilder.Entity<dispatcher>()
                .HasMany(e => e.patients)
                .WithOptional(e => e.dispatcher)
                .HasForeignKey(e => e.dis_Id_fk);

            modelBuilder.Entity<employee>()
                .Property(e => e.empl_salary)
                .HasPrecision(19, 4);

            modelBuilder.Entity<employee>()
                .HasMany(e => e.results)
                .WithRequired(e => e.employee)
                .HasForeignKey(e => e.emp_Id_fk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<job>()
                .HasMany(e => e.employees)
                .WithOptional(e => e.job)
                .HasForeignKey(e => e.job_Id_fk);

            modelBuilder.Entity<patient>()
                .HasMany(e => e.bills)
                .WithOptional(e => e.patient)
                .HasForeignKey(e => e.pat_Id_fk);

            modelBuilder.Entity<patient>()
                .HasMany(e => e.phones)
                .WithRequired(e => e.patient)
                .HasForeignKey(e => e.pat_Id_fk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<patient>()
                .HasMany(e => e.results)
                .WithRequired(e => e.patient)
                .HasForeignKey(e => e.pat_Id_fk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<patient>()
                .HasMany(e => e.samples)
                .WithOptional(e => e.patient)
                .HasForeignKey(e => e.pat_Id_fk);

            modelBuilder.Entity<sample_type>()
                .HasMany(e => e.samples)
                .WithOptional(e => e.sample_type)
                .HasForeignKey(e => e.sam_type_Id_fk);

            modelBuilder.Entity<test>()
                .HasMany(e => e.bills)
                .WithOptional(e => e.test)
                .HasForeignKey(e => e.test_Id_fk);

            modelBuilder.Entity<test>()
                .HasMany(e => e.results)
                .WithRequired(e => e.test)
                .HasForeignKey(e => e.test_Id_fk)
                .WillCascadeOnDelete(false);
        }
    }
}
