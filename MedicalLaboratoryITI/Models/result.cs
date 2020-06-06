namespace MedicalLaboratoryITI.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="result" />.
    /// </summary>
    [Table("result")]
    public partial class result
    {
        /// <summary>
        /// Gets or sets the pat_Id_fk.
        /// </summary>
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int pat_Id_fk { get; set; }

        /// <summary>
        /// Gets or sets the sam_Id_fk.
        /// </summary>
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int sam_Id_fk { get; set; }

        /// <summary>
        /// Gets or sets the emp_Id_fk.
        /// </summary>
        public int emp_Id_fk { get; set; }

        /// <summary>
        /// Gets or sets the test_Id_fk.
        /// </summary>
        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int test_Id_fk { get; set; }

        /// <summary>
        /// Gets or sets the Result_value.
        /// </summary>
        public string Result_value { get; set; }

        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        public virtual employee employee { get; set; }

        /// <summary>
        /// Gets or sets the patient.
        /// </summary>
        public virtual patient patient { get; set; }

        /// <summary>
        /// Gets or sets the test.
        /// </summary>
        public virtual test test { get; set; }
    }
}
