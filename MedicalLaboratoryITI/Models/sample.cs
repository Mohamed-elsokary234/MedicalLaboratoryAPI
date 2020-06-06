namespace MedicalLaboratoryITI.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="sample" />.
    /// </summary>
    [Table("sample")]
    public partial class sample
    {
        /// <summary>
        /// Gets or sets the sample_Id.
        /// </summary>
        [Key]
        public int sample_Id { get; set; }

        /// <summary>
        /// Gets or sets the pat_Id_fk.
        /// </summary>
        public int? pat_Id_fk { get; set; }

        /// <summary>
        /// Gets or sets the sam_type_Id_fk.
        /// </summary>
        public int? sam_type_Id_fk { get; set; }

        /// <summary>
        /// Gets or sets the details.
        /// </summary>
        public string details { get; set; }

        /// <summary>
        /// Gets or sets the patient.
        /// </summary>
        public virtual patient patient { get; set; }

        /// <summary>
        /// Gets or sets the sample_type.
        /// </summary>
        public virtual sample_type sample_type { get; set; }
    }
}
