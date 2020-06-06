namespace MedicalLaboratoryITI.ViewModels
{
    using MedicalLaboratoryITI.Models;

    /// <summary>
    ///     Defines the <see cref="ResultReportViewModel" /> .
    /// </summary>
    public class ResultReportViewModel
    {
        /// <summary>
        ///     Gets or sets the Employee.
        /// </summary>
        public employee Employee { get; set; }

        /// <summary>
        ///     Gets or sets the Patient.
        /// </summary>
        public patient Patient { get; set; }

        /// <summary>
        ///     Gets or sets the Sample.
        /// </summary>
        public sample Sample { get; set; }

        /// <summary>
        ///     Gets or sets the Test.
        /// </summary>
        public test Test { get; set; }
    }
}