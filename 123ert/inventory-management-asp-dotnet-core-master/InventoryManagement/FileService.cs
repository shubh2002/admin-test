using InventoryManagement.Enums;
using InventoryManagement.FileUploader;
using System;
using System.IO;
using System.Threading.Tasks;

namespace InventoryManagement
{
    public class FileService : IFileService
    {
        public async Task<string> UploadFile(Stream stream, FileType fileType, string fileName, string mimeType,string pincode, string uploadType = "Web")
        {
            if (fileType == FileType.Banner)
            {
                fileName = GetContainer(fileType) + (uploadType.ToLower() == "web" ? "/wcdn/" + fileName : "/mcdn/" + fileName);
                pincode = "assets";
            }
            else
            {
                fileName = GetContainer(fileType) + (uploadType.ToLower() == "web" ? "/wcdn/" + fileName : "/mcdn/" + fileName);
            }
            return await FileUploadHelper.Upload(stream, pincode, fileName, mimeType);
        }
        private string GetContainer(FileType fileType)
        {
            string containerName = "Unknown";
            switch (fileType)
            {
                case FileType.Category:
                    containerName = "Category"; break;
                case FileType.Product:
                    containerName = "Product"; break;
                case FileType.ProductGallary:
                    containerName = "ProductGallary"; break;
                case FileType.Banner:
                    containerName = "Banner"; break;
                default:
                    containerName = "Unknown"; break;
            }
            return (containerName).ToLower();
        }
    }
}
