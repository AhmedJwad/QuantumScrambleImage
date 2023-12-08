
namespace QuantumScrambleImage.Helpers
{
    public class BlobHelper : IBlobHelper
    {
        public Task DeleteBlobAsync(string id, string containerName)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UploadBlobAsync(IFormFile imageFile, string containerName)
        {
            //upload image to server
            string guid = Guid.NewGuid().ToString();
            string file = $"{guid}.jpg";
            string path = Path.Combine(
                Directory.GetCurrentDirectory(),
                $"wwwroot\\images\\{containerName}",
                file);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            return $"images/{containerName}/{file}";
        }

        public async Task<string> UploadBlobAsync(byte[] imageFile, string containerName)
        {
            MemoryStream stream = new MemoryStream(imageFile);
            string guid = Guid.NewGuid().ToString();
            string file = $"{guid}.jpg";

            try
            {
                stream.Position = 0;
                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\images\\{containerName}", file);
                File.WriteAllBytes(path, stream.ToArray());
            }
            catch
            {
                return string.Empty;
            }

            return $"images/{containerName}/{file}";
        }

        public async Task<string> UploadBlobAsync(string imageFile, string containerName)
        {
            string guid = Guid.NewGuid().ToString();
            imageFile = $"{guid}.jpg";
            string path = Path.Combine(
                Directory.GetCurrentDirectory(),
                $"wwwroot\\images\\{containerName}",
                imageFile);

            Stream stream = File.OpenRead(imageFile);
            using (FileStream stream1 = new FileStream(path, FileMode.Create))
            {
                await stream.CopyToAsync(stream);
            }


            return $"images/{containerName}/{imageFile}";
        }
    }
}
