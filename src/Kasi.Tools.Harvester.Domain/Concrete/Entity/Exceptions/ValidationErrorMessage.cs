namespace Kasi.Tools.Harvester.Domain.Concrete.Entity.Exceptions
{
    /// <summary>
    /// Contains the information for each validation error encountered when validating an object.
    /// </summary>
    public class ValidationErrorMessage
    {
        /// <summary>
        /// Id of the validation error.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the field that contains the error.
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// Error description.
        /// </summary>
        public string FieldError { get; set; }
    }
}
