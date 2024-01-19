using Azure.Storage.Blobs;

namespace blobs.Services;

public class BlobService : IBlobService
{
    private readonly string _connectionString;
    private readonly string _containerName;

    public BlobService(IConfiguration configuration)
    {
        _connectionString = configuration["BlobContainer:ConnectionString"]!;
        _containerName = configuration["BlobContainer:ContainerName"]!;
    }
    public async Task UploadFromFileAsync(
        string localFilePath)
    {
        // Create a BlobContainerClient
        BlobContainerClient containerClient = new BlobContainerClient(_connectionString, _containerName);

        string fileName = Path.GetFileName(localFilePath);
        BlobClient blobClient = containerClient.GetBlobClient(fileName);

        await blobClient.UploadAsync(localFilePath, true);
    }
}
