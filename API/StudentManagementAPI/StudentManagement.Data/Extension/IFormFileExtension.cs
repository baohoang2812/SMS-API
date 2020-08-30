using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace StudentManagement.Data.Extension
{
    public static class ImageExtensionConstant
    {
        public const string JPG = ".jpg";
        public const string PNG = ".png";
        public const string GIF = ".gif";
        public const string JPEG = ".jpeg";
    }
    public static class IFormFileExtension
    {
        public static bool IsImage(this IFormFile file)
        {
            if (file.Length > 0 && file.ContentType.Contains("image"))
            {
                return true;
            }
            string[] formats = new string[]
            {
                ImageExtensionConstant.JPG,
                ImageExtensionConstant.PNG,
                ImageExtensionConstant.GIF,
                ImageExtensionConstant.JPEG
            };
            return formats.Any(item => file.FileName.EndsWith(item, StringComparison.OrdinalIgnoreCase));
        }
    }
}
