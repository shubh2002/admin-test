using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;
using System.Threading.Tasks;

namespace InventoryManagement.FileUploader
{
    public class FileUploadHelper
    {
        static string ConnectionSting = "DefaultEndpointsProtocol=https;AccountName=yournotebook;AccountKey=eoaYfqdcwbbJobI4xbT4k+SWyLYedV2KnAfc1Kzz6uNTfKXmjD1Z5bOSCil/MZIhRvoExcsbV/9y+AStYKXwqQ==;EndpointSuffix=core.windows.net";
        public async static Task<string> Upload(Stream stream, string containerName, string fileName, string mimeType)
        {
            try
            {
                // create object of storage account
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConnectionSting);

                // create client of storage account
                CloudBlobClient client = storageAccount.CreateCloudBlobClient();

                // create the reference of your storage account
                CloudBlobContainer container = client.GetContainerReference(containerName);

                // check if the container exists or not in your account
                var isCreated = await container.CreateIfNotExistsAsync();
                // set the permission to blob type
                await container.SetPermissionsAsync(new BlobContainerPermissions
                { PublicAccess = BlobContainerPublicAccessType.Blob });

                // create the object of blob which will be created
                // Test-log.txt is the name of the blob, pass your desired name
                CloudBlockBlob blob = container.GetBlockBlobReference(fileName);

                // set the mime type
                blob.Properties.ContentType = mimeType;

                // upload the stream to blob
                await blob.UploadFromStreamAsync(stream);

                return blob.Uri.AbsoluteUri;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
