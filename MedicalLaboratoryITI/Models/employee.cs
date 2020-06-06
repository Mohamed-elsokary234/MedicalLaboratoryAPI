namespace MedicalLaboratoryITI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="employee" />.
    /// </summary>
    [Table("employee")]
    public partial class employee
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="employee"/> class.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public employee()
        {
            results = new HashSet<result>();
        }

        /// <summary>
        /// Gets or sets the empl_Id.
        /// </summary>
        [Key]
        public int empl_Id { get; set; }

        /// <summary>
        /// Gets or sets the empl_name.
        /// </summary>
        public string empl_name { get; set; }

        /// <summary>
        /// Gets or sets the empl_phone.
        /// </summary>
        [StringLength(50)]
        public string empl_phone { get; set; }

        /// <summary>
        /// Gets or sets the empl_address.
        /// </summary>
        public string empl_address { get; set; }

        /// <summary>
        /// Gets or sets the empl_salary.
        /// </summary>
        [Column(TypeName = "money")]
        public decimal? empl_salary { get; set; }

        /// <summary>
        /// Gets or sets the empl_quantification.
        /// </summary>
        public string empl_quantification { get; set; }

        /// <summary>
        /// Gets or sets the empl_work_period.
        /// </summary>
        public string empl_work_period { get; set; }

        /// <summary>
        /// Gets or sets the empl_email.
        /// </summary>
        public string empl_email { get; set; }

        /// <summary>
        /// Gets or sets the job_Id_fk.
        /// </summary>
        public int? job_Id_fk { get; set; }

        /// <summary>
        /// Gets or sets the emp_date.
        /// </summary>
        [Column(TypeName = "date")]
        public DateTime? emp_date { get; set; }

        /// <summary>
        /// Gets or sets the job.
        /// </summary>
        public virtual job job { get; set; }

        /// <summary>
        /// Gets or sets the results.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<result> results { get; set; }
    }
}
