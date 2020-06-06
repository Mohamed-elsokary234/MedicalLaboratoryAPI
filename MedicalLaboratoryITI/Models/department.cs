namespace MedicalLaboratoryITI.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="department" />.
    /// </summary>
    [Table("department")]
    public partial class department
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="department"/> class.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public department()
        {
            tests = new HashSet<test>();
        }

        /// <summary>
        /// Gets or sets the dep_Id.
        /// </summary>
        [Key]
        public int dep_Id { get; set; }

        /// <summary>
        /// Gets or sets the dep_name.
        /// </summary>
        public string dep_name { get; set; }

        /// <summary>
        /// Gets or sets the tests.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<test> tests { get; set; }
    }
}
