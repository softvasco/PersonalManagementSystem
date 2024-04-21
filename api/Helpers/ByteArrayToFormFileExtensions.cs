namespace api.Helpers
{
    using Microsoft.AspNetCore.Http;
    using System.Collections.Generic;
    using System.IO;

    public static class ByteArrayToFormFileExtensions
    {
        public static IFormFile GetFormFile(this byte[] fileBytes, string? fileName = null)
        {
            // Infer the file extension from the byte content
            string fileExtension = InferFileExtension(fileBytes);

            // Determine the content type based on the file extension
            string contentType = GetContentTypeFromExtension(fileExtension);

            // If the file name is not provided, generate a default name based on the extension
            fileName = fileName ?? $"file{fileExtension}";

            // Create a MemoryStream from the byte array
            using var memoryStream = new MemoryStream(fileBytes);

            // Create a FormFile instance from the MemoryStream
            var formFile = new FormFile(memoryStream, 0, fileBytes.Length, "file", fileName)
            {
                Headers = new HeaderDictionary(),
                ContentType = contentType
            };

            return formFile;
        }

        public static string GetFileName(byte[] fileBytes)
        {
            // Infer the file extension from the byte content
            string fileExtension = InferFileExtension(fileBytes);

            // If the file name is not provided, generate a default name based on the extension
            return $"file{fileExtension}";
        }

        public static string InferFileExtension(byte[] fileBytes)
        {
            // Basic implementation to infer file extension based on common file signatures
            if (fileBytes.Length > 4 && fileBytes[0] == 0x25 && fileBytes[1] == 0x50 && fileBytes[2] == 0x44 && fileBytes[3] == 0x46)
            {
                return ".pdf";
            }
            else if (fileBytes.Length > 2 && fileBytes[0] == 0xFF && fileBytes[1] == 0xD8)
            {
                return ".jpg";
            }
            else if (fileBytes.Length > 3 && fileBytes[0] == 0x89 && fileBytes[1] == 0x50 && fileBytes[2] == 0x4E && fileBytes[3] == 0x47)
            {
                return ".png";
            }

            // Add more checks for other common file types as needed

            return ".bin"; // Default to binary if extension cannot be inferred
        }

        public static string GetContentTypeFromExtension(string fileExtension)
        {
            // Map file extensions to MIME types
            var extensionToContentType = new Dictionary<string, string>
        {
            { ".pdf", "application/pdf" },
            { ".jpg", "image/jpeg" },
            { ".png", "image/png" },
            { ".txt", "text/plain" },
            // Add more mappings as needed
        };

            if (extensionToContentType.TryGetValue(fileExtension.ToLowerInvariant(), out var contentType))
            {
                return contentType;
            }

            return "application/octet-stream";
        }
    }
}