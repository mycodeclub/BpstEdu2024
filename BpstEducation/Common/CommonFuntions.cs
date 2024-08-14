using System.Collections.Specialized;

namespace BpstEducation.Common
{
    public static class CommonFuntions
    {
        public static string GetDefaultPassword(DateTime dob)
        {
            return "Bpst@" + dob.Month.ToString() + dob.Year.ToString();
        }


        public static async Task<string> UploadFile(IFormFile? file, string userType, int userId, string docType)
        {
            string filePath = string.Empty;
            if (file != null && file.Length > 0)
            {
                switch (userType)
                {
                    case "Student":
                        filePath = Directory.GetCurrentDirectory() + "\\" + StaticVariables.FileUploadDefaultPath + StaticVariables.StudentFilesDefaultPath + "\\"+userId.ToString() + "\\";
                        break;
                    case "Staff":
                        filePath = Directory.GetCurrentDirectory()+ "\\"+ StaticVariables.FileUploadDefaultPath+ StaticVariables.StaffFilesDefaultPath + "\\"+userId.ToString() + "\\";
                        break;
                }

                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);
                var fileName = docType + "." + file.FileName.Split('.').LastOrDefault();
                using (var stream = new FileStream(filePath + fileName, FileMode.Create))
                    await file.CopyToAsync(stream);
            }
            return filePath;
        }

    }
}
