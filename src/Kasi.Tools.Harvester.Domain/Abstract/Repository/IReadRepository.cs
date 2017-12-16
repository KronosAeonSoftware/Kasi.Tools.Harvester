using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Kasi.Tools.Harvester.Domain.Abstract.Repository
{
    /// <summary>
    /// Generic repository with basic functionality.
    /// </summary>
    /// <typeparam name="TEntity">Type of entity stored in the repository.</typeparam>
    public interface IReadRepository<TEntity> where TEntity : IRecord
    {
        /// <summary>
        /// Gets a single record from the repository by using the record Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity GetById(Guid id);

        /// <summary>
        /// Gets a record using the SHA1 hash as the identifier.
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        TEntity GetBySha1Hash(string hash);

        /// <summary>
        /// Gets a limited set of records based on the filter ans specific number of records to skip.  This method is useful for paging.
        /// </summary>
        /// <param name="filter">Filter used on the records to reduce the result set.</param>
        /// <param name="skip">The number of records to skip before returning the rest.</param>
        /// <param name="take">The number of records to return after skipping the specified number.</param>
        /// <returns>The subset of records found.</returns>
        /// <exception cref="ArgumentException">If the skip parameter is greater than the take parameter.</exception>
        IEnumerable<TEntity> GetSome(Func<TEntity, bool> filter, int skip, int take);

        /// <summary>
        /// Gets all of the records in the repository.
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Gets all records in the repository in an asynchronous mode.
        /// </summary>
        /// <returns>The subset of records found.</returns>
        IEnumerable<TEntity> GetAllAsync();
    }
}
