using Kasi.Tools.Harvester.Domain.Abstract.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string ContentsHash => throw new NotImplementedException();
        public string FilelPathHash => throw new NotImplementedException();

        public string Contents => throw new NotImplementedException();

        public string FileName { get { return String.Format("{0}.{1}", Name, Extension.TrimStart('.')); } }
        public string FullFilePath { get { return System.IO.Path.Combine(Path, FileName); } }

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
