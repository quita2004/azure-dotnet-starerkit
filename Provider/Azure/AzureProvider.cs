using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace WebApplicationMVC.Provider.Azure
{
    public class AzureProvider
    {
        public static BlobContainerClient CreateBlobContainerClient(string url)
        {
            var uri = new Uri(url);

            var credential = new DefaultAzureCredential();
            return new BlobContainerClient(uri, credential);
        }

        public static async Task<string> DownloadBase64FromAzureBlob(IConfiguration _configuration, string? imageName)
        {
            var uri = _configuration.GetValue("BlobUrl", string.Empty);
            var blobContainerClient = CreateBlobContainerClient(uri);
            BlobClient blobClient = blobContainerClient.GetBlobClient(imageName);
            BlobDownloadInfo download = await blobClient.DownloadAsync();
            using MemoryStream ms = new();
            download.Content.CopyTo(ms);
            return Convert.ToBase64String(ms.ToArray());
        }
    }
}
