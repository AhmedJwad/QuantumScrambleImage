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

            string Quantumsate2 = ConvertToQuantumState2(inputImage);
            Bitmap outputImage = ConvertToImage(Quantumsate2, inputImage.Width, inputImage.Height);
            chaotic5D(outputImage);
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
        public string ConvertToQuantumState2(Bitmap bitmap)
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
                              
            // Apply quantum gates
            StringBuilder processedQuantumState = ApplyQuantumGates(quantumState);

            return processedQuantumState.ToString();
        }
        public string GetOriginalPositions(string quantumState)
        {
            StringBuilder originalState = ApplyQuantumGates(new StringBuilder(quantumState));

            return originalState.ToString();
        }

        private StringBuilder ApplyQuantumGates(StringBuilder quantumState)
        {
            StringBuilder processedQuantumState = new StringBuilder(quantumState.ToString());

            for (int k = 0; k < quantumState.Length; k += 8)
            {
                // Apply CNot gate between position[0] and position[2]
                ApplyCNotGate(processedQuantumState, k, k + 2);

                // Apply Swap gate between position[1] and position[2]
                ApplySwapGate(processedQuantumState, k + 1, k + 2);

                // Apply CNot gate between position[4] and position[2]
                ApplyCNotGate(processedQuantumState, k + 4, k + 2);

                // Apply CNot gate between position[3] and position[1]
                ApplyCNotGate(processedQuantumState, k + 3, k + 1);

                // Apply Swap gate between position[3] and position[4]
                ApplySwapGate(processedQuantumState, k + 3, k + 4);

                // Apply CNot gate between position[7] and position[6]
                ApplyCNotGate(processedQuantumState, k + 7, k + 6);

                // Apply CNot gate between position[7] and position[5]
                ApplyCNotGate(processedQuantumState, k + 7, k + 5);
            }

            return processedQuantumState;
        }
        // Helper method to apply CNot gate
        private void ApplyCNotGate(StringBuilder quantumState, int controlIndex, int targetIndex)
        {
            if (quantumState[controlIndex] == '1')
            {
                quantumState[targetIndex] = (quantumState[targetIndex] == '0') ? '1' : '0';
            }
        }

        // Helper method to apply Swap gate
        private void ApplySwapGate(StringBuilder quantumState, int index1, int index2)
        {
            char temp = quantumState[index1];
            quantumState[index1] = quantumState[index2];
            quantumState[index2] = temp;
        }

        public void chaotic5D(System.Drawing.Bitmap bmp)
        {
            double x = 0.99;
            int ih = bmp.Height;
            int iw = bmp.Width;
            System.Drawing.Color c = new System.Drawing.Color();
            for (int i = 0; i < 100; i++)
            {
                x = 4 * x * (1 - x);
            }
            for (int j = 0; j < ih; j++)
            {
                for (int i = 0; i < iw; i++)
                {
                    c = bmp.GetPixel(i, j);
                    int chaos = 0, g;
                    string k;
                    for (int w = 0; w < 8; w++)
                    {
                        x = 4 * x * (1 - x);
                        if (x >= 0.5) g = 1;
                        else g = 0;
                        chaos = ((chaos << 1) | g);
                    }
                    //c = 
                    bmp.SetPixel(i, j, System.Drawing.Color.FromArgb(c.R ^ (int)chaos,
                                                     c.G ^ (int)chaos,
                                                     c.B ^ (int)chaos));
                }
            }

        }
    }
}
