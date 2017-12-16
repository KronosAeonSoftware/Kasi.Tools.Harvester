namespace Kasi.Tools.Harvester.Domain.Abstract.Repository
{
    /// <summary>
    /// Represents a file in the file system.
    /// </summary>
    public interface IFileSystemRecord : IRecord
    {
        /// <summary>
        /// Directory where the file lives.
        /// </summary>
        string Path { get; set; }
        /// <summary>
        /// Name of the file, no extension.
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// File type exntesion
        /// </summary>
        string Extension { get; set; }

        /// <summary>
        /// SHA1 hash of the file contents.
        /// </summary>
        string ContentsHash { get; }
        /// <summary>
        /// SHA1 has of the full file path.
        /// </summary>
        string FilelPathHash { get; }

        /// <summary>
        /// Contents of the file.
        /// </summary>
        string Contents { get; }

        /// <summary>
        /// File name and extension.
        /// </summary>
        string FileName { get; }
        /// <summary>
        /// Full file path with directory, name, and extension of the file.
        /// </summary>
        string FullFilePath { get; }
    }
}
