namespace MedicalLaboratoryITI.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="job" />.
    /// </summary>
    [Table("job")]
    public partial class job
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="job"/> class.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public job()
        {
            employees = new HashSet<employee>();
        }

        /// <summary>
        /// Gets or sets the job_Id.
        /// </summary>
        [Key]
        public int job_Id { get; set; }

        /// <summary>
        /// Gets or sets the job_name.
        /// </summary>
        public string job_name { get; set; }

        /// <summary>
        /// Gets or sets the job_description.
        /// </summary>
        public string job_description { get; set; }

        /// <summary>
        /// Gets or sets the employees.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<employee> employees { get; set; }
    }
}
