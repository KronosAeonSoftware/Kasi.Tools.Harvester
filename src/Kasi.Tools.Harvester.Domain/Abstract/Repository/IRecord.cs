using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasi.Tools.Harvester.Domain.Abstract.Repository
{
    /// <summary>
    /// Generic record in a repository.
    /// </summary>
    public interface IRecord
    {
        Guid Id { get; set; }

        /// <summary>
        /// Validates the record.
        /// </summary>
        /// <returns>True if it's valid, false otherwise.</returns>
        bool IsValid();

        /// <summary>
        /// Validates the record.
        /// </summary>
        /// <param name="stopOnFirstError">True if it should stop processing after the first error is encountered, false otherwise</param>
        /// <exception cref="ValidationException"></exception>
        void Validate(bool stopOnFirstError);

        /// <summary>
        /// Validates the record and returns any validation errors found.
        /// </summary>
        /// <param name="stopOnFirstError">True if the validation should stop and return the first error encountered, false if it should continue until all validations are completed.</param>
        /// <returns>Null or string array with validation error.</returns>
        string[] ValidationErrors(bool stopOnFirstError);
    }
}
