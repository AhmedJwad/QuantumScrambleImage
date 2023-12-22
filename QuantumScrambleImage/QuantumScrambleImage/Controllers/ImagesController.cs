using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuantumScrambleImage.Data;
using QuantumScrambleImage.Data.Entities;
using QuantumScrambleImage.Helpers;
using QuantumScrambleImage.Models;
using System.Drawing.Imaging;
using System.Drawing;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Runtime.InteropServices;
using System.Numerics;
using Microsoft.Quantum.Simulation.Simulators;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.AspNetCore.Razor.TagHelpers;
using static System.Net.Mime.MediaTypeNames;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp;
using Image = SixLabors.ImageSharp.Image;
using Color = System.Drawing.Color;

namespace QuantumScrambleImage.Controllers
{
    public class ImagesController : Controller
    {
        private readonly DataContext _context;
        private readonly IBlobHelper _blobHelper;

        public ImagesController(DataContext context, IBlobHelper blobHelper)
        {
            _context = context;
            _blobHelper = blobHelper;
        }

        public async Task< IActionResult> Index()
        {
            return View( await _context.Images.ToListAsync());
        }
        public async Task<IActionResult> Create()
        {           

           
            AddImageViewModel model = new ()
            {
               

            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddImageViewModel model)
        {
            if(ModelState.IsValid) 
            {
                string ImageId = await _blobHelper.UploadBlobAsync(model.ImageFile, "ImagesEncrypted");
                Data.Entities.Image image = new()
                {
                    ImageId = ImageId,
                    isEncrypted = false,
                };
                _context.Images.Add(image);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
            
        }
       
      
        public async Task<IActionResult> DeleteImage(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

           Data.Entities.Image image = await _context.Images
                .FirstOrDefaultAsync(x => x.Id == Id);
            if (image == null)
            {
                return NotFound();
            }
            try
            {
                await _blobHelper.DeleteBlobAsync(image.ImageId, "ImagesEncrypted");
            }
            catch (Exception)
            { }
            _context.Images.Remove(image);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Scrambleimage(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            Data.Entities.Image image = await _context.Images
                .FirstOrDefaultAsync(x => x.Id == id);
            if (image == null) 
            {
                return NotFound();
            }
            var httpClient = new HttpClient();
            var stream = await httpClient.GetStreamAsync(image.ImageFullPath);
            Bitmap inputImage = new Bitmap(stream);

            string Quantumsate = ConvertToQuantumState(inputImage);

            Bitmap outputImage = ConvertToImage(Quantumsate, inputImage.Width, inputImage.Height);
                // Display the scrambled image          
            outputImage.Save(Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\images\\scrampleimage\\scrambledimages" + ".jpg"));
            return RedirectToAction (nameof(Index));
        }
        public  string ConvertToQuantumState(Bitmap bitmap)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;

            StringBuilder quantumState = new StringBuilder();

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Color pixelColor = bitmap.GetPixel(j, i);

                    string binaryPixel = Convert.ToString(pixelColor.R, 2).PadLeft(8, '0') +
                                         Convert.ToString(pixelColor.G, 2).PadLeft(8, '0') +
                                         Convert.ToString(pixelColor.B, 2).PadLeft(8, '0');

                    quantumState.Append(binaryPixel);
                }
            }

            return quantumState.ToString();
        }
        public  Bitmap ConvertToImage(string quantumState, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);

            int index = 0;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    string pixelData = quantumState.Substring(index, 24);
                    index += 24;

                    int r = Convert.ToInt32(pixelData.Substring(0, 8), 2);
                    int g = Convert.ToInt32(pixelData.Substring(8, 8), 2);
                    int b = Convert.ToInt32(pixelData.Substring(16, 8), 2);

                    Color pixelColor = Color.FromArgb(r, g, b);
                    result.SetPixel(j, i, pixelColor);
                }
            }

            return result;
        }

    }
}
