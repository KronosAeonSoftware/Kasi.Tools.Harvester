using Kasi.Tools.Harvester.Domain.Abstract.Repository;
using Kasi.Tools.Harvester.Domain.Utility;
using System;
using System.IO;

namespace Kasi.Tools.Harvester.Domain.Concrete.Entity
{
    public class FileSystemRecord : IFileSystemRecord
    {
        #region " Properties "

        public Guid Id { get; set; }
        public string URI => throw new NotImplementedException();

        public string Path { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }

        private string mContentHash;
        public string ContentsHash { get { return mContentHash; } }

        private string mFilePathHash;
        public string FilelPathHash { get { return mFilePathHash;} }

        public string Contents => throw new NotImplementedException();

        public string FileName { get { return String.Format("{0}.{1}", Name, Extension.TrimStart('.')); } }
        public string FullFilePath { get { return System.IO.Path.Combine(Path, FileName); } }

        /// <summary>
        /// Gets the ContentsHash and FilePathHash.  This operation can be expensinve.
        /// Using the LoadHashesAsync() for a more flexible solution.
        /// </summary>
        public bool LoadHashes()
        {

            mFilePathHash = Encryption.GetHash(FullFilePath);
            
            try
            {
                using (var fs = new StreamReader(FullFilePath))
                {
                    var content = fs.ReadToEnd();

                    mContentHash = Encryption.GetHash(content);
                }
            } catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        #endregion


        #region " Validation "

        public bool IsValid()
        {
            throw new NotImplementedException();
        }
        public void Validate(bool stopOnFirstError)
        {
            throw new NotImplementedException();
        }
        public string[] ValidationErrors(bool stopOnFirstError)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
