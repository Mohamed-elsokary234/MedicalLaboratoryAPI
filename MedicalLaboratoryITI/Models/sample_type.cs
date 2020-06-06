namespace MedicalLaboratoryITI.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="sample_type" />.
    /// </summary>
    public partial class sample_type
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="sample_type"/> class.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sample_type()
        {
            samples = new HashSet<sample>();
        }

        /// <summary>
        /// Gets or sets the sam_type_Id.
        /// </summary>
        [Key]
        public int sam_type_Id { get; set; }

        /// <summary>
        /// Gets or sets the type_name.
        /// </summary>
        public string type_name { get; set; }

        /// <summary>
        /// Gets or sets the samples.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sample> samples { get; set; }
    }
}
