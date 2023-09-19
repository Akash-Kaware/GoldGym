namespace GoldGym.Data
{
    public class ImageUploadUtil
    {
        public static string UploadedFile(string webRootPath, IFormFile? profileImage, string uniqueFileName, string folderName= "customers")
        {
            if (profileImage != null)
            {
                string uploadsFolder = Path.Combine(webRootPath, "images", folderName);
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

        public static void DeleteFile(string webRootPath, string uniqueFileName, string folderName = "customers")
        {
            string uploadsFolder = Path.Combine(webRootPath, "images", folderName);
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
