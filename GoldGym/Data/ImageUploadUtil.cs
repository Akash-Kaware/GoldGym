namespace GoldGym.Data
{
    public class ImageUploadUtil
    {
        public static string UploadedFile(string webRootPath, IFormFile? profileImage, string uniqueFileName)
        {
            if (profileImage != null)
            {
                string uploadsFolder = Path.Combine(webRootPath, "images");
                uniqueFileName += Path.GetExtension(profileImage.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    profileImage.CopyTo(fileStream);
                }
            }
            else
            {
                uniqueFileName = string.Empty;
            }
            return uniqueFileName;
        }

        public static void DeleteFile(string webRootPath, string uniqueFileName)
        {
            string uploadsFolder = Path.Combine(webRootPath, "images");
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public static string getCustomerPhotoPath(string photo)
        {
            return Path.Combine("/images/", string.IsNullOrEmpty(photo) ? "default-avatar.png" : string.Concat("customers/" + photo));
        }
    }
}
