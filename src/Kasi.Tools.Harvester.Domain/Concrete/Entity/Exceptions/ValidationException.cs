using System.Collections.Generic;

namespace Kasi.Tools.Harvester.Domain.Concrete.Entity.Exceptions
{
    /// <summary>
    /// Exception thrown when validation fails.
    /// </summary>
    public class ValidationException : KasiDomainException
    {
        private ICollection<ValidationErrorMessage> mFieldErrors;
        private bool mWasThrownAfterFirstError;

        /// <summary>
        /// Contains a list of all the errors which caused the exception. 
        /// </summary>
        ICollection<ValidationErrorMessage> FieldErrors { get { return mFieldErrors; } }

        /// <summary>
        /// True if the validation exception was thrown after finding one error of possible multiple errors.
        /// </summary>
        bool WasThrownAfterFirstError { get { return mWasThrownAfterFirstError; } }


        public ValidationException(ICollection<ValidationErrorMessage> fieldErrors, bool wasThrownAfterFirstError)
        {
            mFieldErrors = fieldErrors;
            mWasThrownAfterFirstError = wasThrownAfterFirstError;
        }
    }
}
