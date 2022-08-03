using Azure.Storage.Blobs;
using PizzaApi.Models;
using PizzaApi.Services.Implementations;
using System.Text.Json;

namespace PizzaApi.Services
{
    public class BackupService :IBackupService
    {

        
        public BackupService()
        {

        }

        public async Task SaveObject<T>(T obj)
        {
            string objectString = JsonSerializer.Serialize(obj) + "\r\n";
            string[] typeName = obj.GetType().ToString().Split(separator: ".");
            await File.AppendAllTextAsync("SavedObjects.txt", $"{typeName.Last()} : {objectString}" );

            BlobServiceClient blobServiceClient = new BlobServiceClient
                ("DefaultEndpointsProtocol=https;AccountName=storagecontainerfilip;AccountKey=QbLK3ja6D6n/y8ChfC7sZBuHY+qhN0AgpbFIWWN1LF0vQbeP4Y/S59zvVolk0mu0XkL6n10hUKGq+ASt6AaiTA==;EndpointSuffix=core.windows.net");

            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("file-upload");

            BlobClient blobClient = containerClient.GetBlobClient("Filip");

            using FileStream uploadFileStream = File.OpenRead("SavedObjects.txt");
            blobClient.Upload(uploadFileStream, overwrite: true);
            uploadFileStream.Close();
        }

        public async Task SaveDeletedPizza(Pizza pizza)
        {
            string pizzaString = JsonSerializer.Serialize(pizza) + "\r\n";
            await File.AppendAllTextAsync("SavedPizzas.txt", pizzaString);

            BlobServiceClient blobServiceClient = new BlobServiceClient
                ("DefaultEndpointsProtocol=https;AccountName=storagecontainerfilip;AccountKey=QbLK3ja6D6n/y8ChfC7sZBuHY+qhN0AgpbFIWWN1LF0vQbeP4Y/S59zvVolk0mu0XkL6n10hUKGq+ASt6AaiTA==;EndpointSuffix=core.windows.net");

            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("file-upload");

            BlobClient blobClient = containerClient.GetBlobClient("Filip");

            using FileStream uploadFileStream = File.OpenRead("SavedPizzas.txt");
            blobClient.Upload(uploadFileStream, overwrite: true);
            uploadFileStream.Close();

        }
        
    }
}
