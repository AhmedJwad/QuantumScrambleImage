using Microsoft.EntityFrameworkCore;
using QuantumScrambleImage.Data.Entities;
using QuantumScrambleImage.Helpers;

namespace QuantumScrambleImage.Data
{
    public class Seed
    {
        private readonly DataContext _context;
        private readonly IBlobHelper _blobHelper;

        public Seed(DataContext context ,IBlobHelper blobHelper )
        {
           _context = context;
           _blobHelper = blobHelper;
        }
        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckImagesAsync();          

        }

        private async Task CheckImagesAsync()
        {
            if(!_context.Images.Any())
            {
                var images = new List<Image>
                {
                    new Image { ImageId = "image1.jpg" , isEncrypted=false},
                    new Image { ImageId = "image2.jpg" , isEncrypted=false},
                    // Add more images as needed
                };

                foreach (var image in images)
                {
                    //string imagePath = $"{Environment.CurrentDirectory}\\wwwroot\\images\\upload\\{image}";

                    // Upload the image to blob storage and get the URL
                   // string imageId = await _blobHelper.UploadBlobAsync($"{Environment.CurrentDirectory}\\wwwroot\\images\\upload\\{image}", $"{Environment.CurrentDirectory}\\wwwroot\\images\\ImagesEncrypted");

                    // Set the ImageId property to the URL or identifier returned by blob storage
                  //  image.ImageId = imageId;

                    // Add the image to the context
                    _context.Images.Add(image);
                }

            }

            await _context.SaveChangesAsync();
        }
    }
}
