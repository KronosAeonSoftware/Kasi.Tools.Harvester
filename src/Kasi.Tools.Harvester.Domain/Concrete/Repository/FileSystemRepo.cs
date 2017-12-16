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
        private IEnumerable<FileSystemRecord> mRecords;

        public FileSystemRepo(string root, string searchPattern, SearchOption option)
        {
            mRecords = Directory.EnumerateFiles(root, searchPattern, option).Select(x => new FileSystemRecord {
                Id = new Guid(),
                Name = Path.GetFileNameWithoutExtension(x),
                Path = Path.GetDirectoryName(x),
                Extension = Path.GetFullPath(x)
            });
        }

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
    }
}
