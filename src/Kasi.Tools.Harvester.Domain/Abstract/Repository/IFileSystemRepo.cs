using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasi.Tools.Harvester.Domain.Abstract.Repository
{
    public interface IFileSystemRepo<TFileEntity> : IReadRepository<TFileEntity>
        where TFileEntity : class, IFileSystemRecord, new()
    {
    }
}
