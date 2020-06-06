namespace MedicalLaboratoryITI.ViewModels
{
    using MedicalLaboratoryITI.Models;

    /// <summary>
    ///     Defines the <see cref="BillReportViewModel" /> .
    /// </summary>
    public class BillReportViewModel
    {
        /// <summary>
        ///     Gets or sets the Bill.
        /// </summary>
        public bill Bill { get; set; }

        /// <summary>
        ///     Gets or sets the Dispatcher.
        /// </summary>
        public dispatcher Dispatcher { get; set; }

        /// <summary>
        ///     Gets or sets the Patient.
        /// </summary>
        public patient Patient { get; set; }

        /// <summary>
        ///     Gets or sets the Test.
        /// </summary>
        public test Test { get; set; }
    }
}