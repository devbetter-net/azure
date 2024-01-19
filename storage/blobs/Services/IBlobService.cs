namespace blobs.Services;

public interface IBlobService
{
    /// <summary>
    /// Uploads a file to a blob container asynchronously.
    /// </summary>
    /// <param name="localFilePath">The local file path.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task UploadFromFileAsync(string localFilePath);
}
