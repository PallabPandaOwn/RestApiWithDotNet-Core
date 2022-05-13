using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace RestApiWithCore_5.HelperClass
{
    public static class FileUpload
    {
        public static async Task<string> Fileupload(IFormFile file)
        {
            string CS = @"DefaultEndpointsProtocol=https;AccountName=devidcb223;AccountKey=boN1U2Hb+m1ooAXT4jUsCowN3uV6VtGVHaM5a7yg776DPgO9c1+gNPOKt1TiMe6B7/UcFwKKIi3CZYCPMv7YKg==;EndpointSuffix=core.windows.net";
            //bool overwrite = false;
            string containerName = "restapitest";

            BlobContainerClient blobContainerClient = new BlobContainerClient(CS, containerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(file.FileName);
            var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            await blobClient.UploadAsync(memoryStream,overwrite:true);

            return blobClient.Uri.AbsoluteUri;

        }
    }
}
