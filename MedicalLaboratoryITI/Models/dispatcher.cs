namespace MedicalLaboratoryITI.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="dispatcher" />.
    /// </summary>
    [Table("dispatcher")]
    public partial class dispatcher
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="dispatcher"/> class.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public dispatcher()
        {
            patients = new HashSet<patient>();
        }

        /// <summary>
        /// Gets or sets the dis_Id.
        /// </summary>
        [Key]
        public int dis_Id { get; set; }

        /// <summary>
        /// Gets or sets the disp_name.
        /// </summary>
        public string disp_name { get; set; }

        /// <summary>
        /// Gets or sets the disp_phone.
        /// </summary>
        [StringLength(50)]
        public string disp_phone { get; set; }

        /// <summary>
        /// Gets or sets the patients.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<patient> patients { get; set; }
    }
}
