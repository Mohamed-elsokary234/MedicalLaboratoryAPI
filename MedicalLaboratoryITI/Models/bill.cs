namespace MedicalLaboratoryITI.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="bill" />.
    /// </summary>
    [Table("bill")]
    public partial class bill
    {
        /// <summary>
        /// Gets or sets the bill_Id.
        /// </summary>
        [Key]
        public int bill_Id { get; set; }

        /// <summary>
        /// Gets or sets the bill_paid.
        /// </summary>
        public int? bill_paid { get; set; }

        /// <summary>
        /// Gets or sets the discount.
        /// </summary>
        [Column(TypeName = "money")]
        public decimal? discount { get; set; }

        /// <summary>
        /// Gets or sets the net.
        /// </summary>
        [Column(TypeName = "money")]
        public decimal? net { get; set; }

        /// <summary>
        /// Gets or sets the pat_Id_fk.
        /// </summary>
        public int? pat_Id_fk { get; set; }

        /// <summary>
        /// Gets or sets the test_Id_fk.
        /// </summary>
        public int? test_Id_fk { get; set; }

        /// <summary>
        /// Gets or sets the bill_date.
        /// </summary>
        [Column(TypeName = "date")]
        public DateTime? bill_date { get; set; }

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
