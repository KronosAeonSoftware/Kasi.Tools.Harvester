namespace Kasi.Tools.Harvester.Domain.Abstract.Repository
{
    public interface IFileSystemRepo<TFileEntity> : IReadRepository<TFileEntity>
        where TFileEntity : class, IFileSystemRecord, new()
    {
    }
}
