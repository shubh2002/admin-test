using InventoryManagement.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement
{
    public interface IFileService
    {
        public Task<string> UploadFile(Stream stream, FileType fileType, string fileName, string mimeType, string pincode, string uploadType = "Web");
    }
}
