namespace MedicalLaboratoryITI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="test" />.
    /// </summary>
    [Table("test")]
    public partial class test
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="test"/> class.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public test()
        {
            bills = new HashSet<bill>();
            results = new HashSet<result>();
        }

        /// <summary>
        /// Gets or sets the test_Id.
        /// </summary>
        [Key]
        public int test_Id { get; set; }

        /// <summary>
        /// Gets or sets the test_name.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string test_name { get; set; }

        /// <summary>
        /// Gets or sets the test_price.
        /// </summary>
        public int? test_price { get; set; }

        /// <summary>
        /// Gets or sets the reference_value.
        /// </summary>
        [StringLength(100)]
        public string reference_value { get; set; }

        /// <summary>
        /// Gets or sets the Dep_fk.
        /// </summary>
        public int? Dep_fk { get; set; }

        /// <summary>
        /// Gets or sets the test_date.
        /// </summary>
        [Column(TypeName = "date")]
        public DateTime? test_date { get; set; }

        /// <summary>
        /// Gets or sets the bills.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bill> bills { get; set; }

        /// <summary>
        /// Gets or sets the department.
        /// </summary>
        public virtual department department { get; set; }

        /// <summary>
        /// Gets or sets the results.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<result> results { get; set; }
    }
}
