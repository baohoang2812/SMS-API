using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.WindowsAzure.ServiceRuntime;
using StudentManagement.Data.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement.Data.Services
{
    public class BlobStorageService
    {
        private static string accessKey = AppConfig.GetConfiguration("AccessKey"); 

        public static CloudBlobContainer GetCloudBlobContainer()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(accessKey);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer blobContainer = blobClient.GetContainerReference("images");
            if (blobContainer.CreateIfNotExists())
            {
                blobContainer.SetPermissions(new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                });
            }
            return blobContainer;
        }
    }
}
