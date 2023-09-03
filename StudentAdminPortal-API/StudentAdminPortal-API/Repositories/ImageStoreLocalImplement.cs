namespace StudentAdminPortal_API.Repositories
{
    public class ImageStoreLocalImplement : IImageRepository
    {
        public async Task<string> UploadImage(IFormFile file, string fileName)
        {
            //below path refers to the local path -where the project is in the local directory. Eg: F:\DotNet\StudentAPI\Resources\Images\GUID.jpg
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"Resources\Images", fileName);
            //the below stream is pointing to the above obtained path - the stream enables CREATING file.
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);
            return GetRelativePath(fileName);
        }
        private string GetRelativePath(string fileName)
        {
            //this provides the relative path, which is only the path from the current project 
            //eg: from the above found local path, only "Resources\Images\GUID.jpg" which is a relative path. - it will be relative to wherever the project is deployed.
            return Path.Combine(@"Resources\Images", fileName);
        }

    }
}
