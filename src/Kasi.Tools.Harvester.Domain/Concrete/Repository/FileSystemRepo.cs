using System;
using System.Linq;
using System.Collections.Generic;
using Kasi.Tools.Harvester.Domain.Abstract.Repository;
using Kasi.Tools.Harvester.Domain.Concrete.Entity;
using System.IO;

namespace Kasi.Tools.Harvester.Domain.Concrete.Repository
{
    public class FileSystemRepo : IFileSystemRepo<FileSystemRecord>
    {
        #region " Properties "
        /// <summary>
        /// Stores the enumerable records inside the directory.
        /// </summary>
        private IEnumerable<FileSystemRecord> mRecords;

        /// <summary>
        /// Gets or sets the root directory from which to extract files.
        /// </summary>
        private string mSearchDirectory;
        /// <summary>
        /// Gets the root directory from which files for the repo are retrieved.
        /// </summary>
        public string SearchDirectory { get { return mSearchDirectory; } }

        /// <summary>
        /// Gets or sets the search pattern for the files we want to retrieve.
        /// </summary>
        private string mSearchPattern;
        /// <summary>
        /// Gets the search pattern used to filter files that are retrieved from the root directory.
        /// </summary>
        public string SearchPattern { get { return mSearchPattern; } }

        /// <summary>
        /// Gets or sets the search options that we want to use when retrieving files from the root directory.
        /// </summary>
        private SearchOption mSearchOptions;
        /// <summary>
        /// Gets the search options used when retrieving files from the root directory.
        /// </summary>
        public SearchOption SearchOptions { get { return mSearchOptions; } }
        #endregion


        #region " Constructors "

        /// <summary>
        /// Complete constructor for the class that accepts all properties used for the repository.
        /// </summary>
        /// <param name="root">Root directory from which to retrive files.</param>
        /// <param name="searchPattern">Pattern used to filter records from the root directory.</param>
        /// <param name="option">Options used to retrieve files from the root and subdirectories.</param>
        public FileSystemRepo(string root, string searchPattern, SearchOption options)
        {
            mSearchDirectory = root;
            mSearchPattern = searchPattern;
            mSearchOptions = options;

            mRecords = Directory.EnumerateFiles(root, searchPattern, options).Select(x => new FileSystemRecord {
                Id = new Guid(),
                Name = Path.GetFileNameWithoutExtension(x),
                Path = Path.GetDirectoryName(x),
                Extension = Path.GetExtension(x)
            });
        }

        #endregion


        #region " IFileSystemRepo "

        public IEnumerable<FileSystemRecord> GetAll()
        {
            return mRecords;
        }

        public IEnumerable<FileSystemRecord> GetAllAsync()
        {
            foreach(var record in mRecords)
            {
                yield return record;
            }
        }

        public FileSystemRecord GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public FileSystemRecord GetBySha1Hash(string hash)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FileSystemRecord> GetSome(Func<FileSystemRecord, bool> filter, int skip, int take)
        {
            throw new NotImplementedException();
        }
        
        #endregion
    }
}
