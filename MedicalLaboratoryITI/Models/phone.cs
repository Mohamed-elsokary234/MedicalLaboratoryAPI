namespace MedicalLaboratoryITI.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="phone" />.
    /// </summary>
    [Table("phone")]
    public partial class phone
    {
        /// <summary>
        /// Gets or sets the phone_num.
        /// </summary>
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string phone_num { get; set; }

        /// <summary>
        /// Gets or sets the pat_Id_fk.
        /// </summary>
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int pat_Id_fk { get; set; }

        /// <summary>
        /// Gets or sets the patient.
        /// </summary>
        public virtual patient patient { get; set; }
    }
}
