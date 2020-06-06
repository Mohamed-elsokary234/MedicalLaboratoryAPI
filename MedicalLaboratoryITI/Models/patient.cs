namespace MedicalLaboratoryITI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="patient" />.
    /// </summary>
    [Table("patient")]
    public partial class patient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="patient"/> class.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public patient()
        {
            bills = new HashSet<bill>();
            phones = new HashSet<phone>();
            results = new HashSet<result>();
            samples = new HashSet<sample>();
        }

        /// <summary>
        /// Gets or sets the pat_Id.
        /// </summary>
        [Key]
        public int pat_Id { get; set; }

        /// <summary>
        /// Gets or sets the pat_f_name.
        /// </summary>
        public string pat_f_name { get; set; }

        /// <summary>
        /// Gets or sets the pat_l_name.
        /// </summary>
        public string pat_l_name { get; set; }

        /// <summary>
        /// Gets or sets the pat_gender.
        /// </summary>
        [StringLength(50)]
        public string pat_gender { get; set; }

        /// <summary>
        /// Gets or sets the pat_age.
        /// </summary>
        public int? pat_age { get; set; }

        /// <summary>
        /// Gets or sets the dis_Id_fk.
        /// </summary>
        public int? dis_Id_fk { get; set; }

        /// <summary>
        /// Gets or sets the pat_address.
        /// </summary>
        [StringLength(100)]
        public string pat_address { get; set; }

        /// <summary>
        /// Gets or sets the pat_email.
        /// </summary>
        [StringLength(50)]
        public string pat_email { get; set; }

        /// <summary>
        /// Gets or sets the pat_password.
        /// </summary>
        [StringLength(15)]
        public string pat_password { get; set; }

        /// <summary>
        /// Gets or sets the pat_date.
        /// </summary>
        [Column(TypeName = "date")]
        public DateTime? pat_date { get; set; }

        /// <summary>
        /// Gets or sets the bills.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bill> bills { get; set; }

        /// <summary>
        /// Gets or sets the dispatcher.
        /// </summary>
        public virtual dispatcher dispatcher { get; set; }

        /// <summary>
        /// Gets or sets the phones.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<phone> phones { get; set; }

        /// <summary>
        /// Gets or sets the results.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<result> results { get; set; }

        /// <summary>
        /// Gets or sets the samples.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sample> samples { get; set; }
    }
}
