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
using System.Drawing.Drawing2D;

namespace QuantumScrambleImage.Controllers
{
    public class ImagesController : Controller
    {
        private readonly DataContext _context;
        private readonly IBlobHelper _blobHelper;
        private readonly IConverter _converter;
        private readonly Ientropy _entropy;

        public ImagesController(DataContext context, IBlobHelper blobHelper, IConverter converter,
            Ientropy entropy)
        {
            _context = context;
            _blobHelper = blobHelper;
            _converter = converter;
            _entropy = entropy;
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
            string Ahmed= _converter.ConvertToQuantumState2(inputImage);           
            // Convert the string to a StringBuilder
            StringBuilder quantumState = new StringBuilder(Ahmed);
            StringBuilder processedQuantumState1 = _converter.ScrambleQuantumCircuit1(quantumState);
            Bitmap outputImage = ConvertToImage(processedQuantumState1.ToString(), inputImage.Width, inputImage.Height);
            _converter.scrambleimage(outputImage);
            outputImage.Save(Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\images\\scrampleimage\\scrambledimages1" + ".jpg"));
            StringBuilder processedQuantumState2 = _converter.ScrambleQuantumCircuit2(quantumState);
            Bitmap outputImage2 = ConvertToImage(processedQuantumState2.ToString(), inputImage.Width, inputImage.Height);
            _converter.scrambleimage(outputImage2);
            outputImage2.Save(Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\images\\scrampleimage\\scrambledimages2" + ".jpg"));
            StringBuilder processedQuantumState3 = _converter.ScrambleQuantumCircuit3(quantumState);
            Bitmap outputImage3 = ConvertToImage(processedQuantumState3.ToString(), inputImage.Width, inputImage.Height);
            _converter.scrambleimage(outputImage3);
            outputImage3.Save(Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\images\\scrampleimage\\scrambledimages3" + ".jpg"));
            StringBuilder processedQuantumState4 = _converter.ScrambleQuantumCircuit4(quantumState);
            Bitmap outputImage4 = ConvertToImage(processedQuantumState4.ToString(), inputImage.Width, inputImage.Height);
            _converter.scrambleimage(outputImage4);
            outputImage4.Save(Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\images\\scrampleimage\\scrambledimages4" + ".jpg"));
            StringBuilder processedQuantumState5 = _converter.ScrambleQuantumCircuit5(quantumState);
            Bitmap outputImage5 = ConvertToImage(processedQuantumState5.ToString(), inputImage.Width, inputImage.Height);
            _converter.scrambleimage(outputImage5);
            outputImage5.Save(Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\images\\scrampleimage\\scrambledimages5" + ".jpg"));
            StringBuilder processedQuantumState6 = _converter.ScrambleQuantumCircuit6(quantumState);
            Bitmap outputImage6 = ConvertToImage(processedQuantumState6.ToString(), inputImage.Width, inputImage.Height);
            _converter.scrambleimage(outputImage6);
            outputImage6.Save(Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\images\\scrampleimage\\scrambledimages6" + ".jpg"));
            StringBuilder processedQuantumState7 = _converter.ScrambleQuantumCircuit7(quantumState);
            Bitmap outputImage7 = ConvertToImage(processedQuantumState7.ToString(), inputImage.Width, inputImage.Height);
            _converter.scrambleimage(outputImage7);
            outputImage7.Save(Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\images\\scrampleimage\\scrambledimages7" + ".jpg"));
            StringBuilder processedQuantumState8 = _converter.ScrambleQuantumCircuit8(quantumState);
            Bitmap outputImage8 = ConvertToImage(processedQuantumState8.ToString(), inputImage.Width, inputImage.Height);
            _converter.scrambleimage(outputImage8);
            outputImage8.Save(Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\images\\scrampleimage\\scrambledimages8" + ".jpg"));
            StringBuilder processedQuantumState9 = _converter.ScrambleQuantumCircuit9(quantumState);
            Bitmap outputImage9 = ConvertToImage(processedQuantumState9.ToString(), inputImage.Width, inputImage.Height);
            _converter.scrambleimage(outputImage9);
            outputImage9.Save(Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\images\\scrampleimage\\scrambledimages9" + ".jpg"));
            StringBuilder processedQuantumState10 = _converter.ScrambleQuantumCircuit10(quantumState);
            Bitmap outputImage10 = ConvertToImage(processedQuantumState10.ToString(), inputImage.Width, inputImage.Height);
            _converter.scrambleimage(outputImage10);
            outputImage10.Save(Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\images\\scrampleimage\\scrambledimages10" + ".jpg"));





            // Display the scrambled image            

            //StringBuilder DescrambleprocessedQuantumState1 = _converter.ReverseScrambleQuantumCircuit1(quantumState);
            //StringBuilder DescrambleprocessedQuantumState2 = _converter.ReverseScrambleQuantumCircuit2(DescrambleprocessedQuantumState1);
            //StringBuilder DescrambleprocessedQuantumState3 = _converter.InverseScrambleQuantumCircuit3(DescrambleprocessedQuantumState2);
            //StringBuilder DescrambleprocessedQuantumState4 = _converter.InverseScrambleQuantumCircuit4(DescrambleprocessedQuantumState3);
            //StringBuilder DescrambleprocessedQuantumState5 = _converter.InverseScrambleQuantumCircuit5(DescrambleprocessedQuantumState4);
            //StringBuilder DescrambleprocessedQuantumState6 = _converter.InverseScrambleQuantumCircuit6(DescrambleprocessedQuantumState5);
            //StringBuilder DescrambleprocessedQuantumState7 = _converter.InverseScrambleQuantumCircuit7(DescrambleprocessedQuantumState6);
            //StringBuilder DescrambleprocessedQuantumState8 = _converter.InverseScrambleQuantumCircuit8(DescrambleprocessedQuantumState7);
            //StringBuilder DescrambleprocessedQuantumState9 = _converter.InverseScrambleQuantumCircuit9(DescrambleprocessedQuantumState8);
            //StringBuilder DescrambleprocessedQuantumState10 = _converter.InverseScrambleQuantumCircuit10(DescrambleprocessedQuantumState9);

            //// _converter.scrambleimage(outputImage);
            //// Display the scrambled image
            //Bitmap outputImage1 = ConvertToImage(DescrambleprocessedQuantumState10.ToString(), inputImage.Width, inputImage.Height);
            //outputImage1.Save(Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\images\\scrampleimage\\scrambledimages1" + ".jpg"));

            return RedirectToAction (nameof(Index));
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
        
        public async Task<IActionResult>Measurement(int? id)
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
            ImageViewModel model = new()
            {
                Id = image.Id,
                ImageId=image.ImageId,

            };
            //scramble Entropy
            model.ScrambleId = ($"images\\scrampleimage\\scrambledimages1" + ".jpg");
            var httpClient = new HttpClient();
            var stream = await httpClient.GetStreamAsync(model.ScrambleFullPath);
            Bitmap scrambledImage = new Bitmap(stream);

            // Convert the bitmap image to a 2D array of pixel values
            int[,] pixelValues =_entropy.GetPixelValues(scrambledImage);

            // Calculate global entropy
           model.ScrambleEntropy =_entropy.CalculateGlobalEntropy(pixelValues);

            //End scramble entropy
            //original entropy
            var httpClient1 = new HttpClient();
            var stream1 = await httpClient.GetStreamAsync(model.ImageFullPath);
            Bitmap originalImage = new Bitmap(stream1);

            // Convert the bitmap image to a 2D array of pixel values
            int[,] pixelValues1 = _entropy.GetPixelValues(originalImage);

            // Calculate global entropy
            model.OriginalEntropy = _entropy.CalculateGlobalEntropy(pixelValues1);
            
            //calculate histgrame

           model.Scramblehistogram = _entropy.CalculateHistogram(scrambledImage);

            // Display histogram values
            for (int i = 0; i < model.Scramblehistogram.Length; i++)
            {
                Console.WriteLine($"Intensity Level {i}: {model.Scramblehistogram[i]}");
            }

            // Prepare chart data
            ViewData["HistogramData"] = model.Scramblehistogram;

            model.originalhistogram = _entropy.CalculateHistogram(originalImage);

            // Display histogram values
            for (int i = 0; i < model.originalhistogram.Length; i++)
            {
                Console.WriteLine($"Intensity Level {i}: {model.originalhistogram[i]}");
            }

            // Prepare chart data
            ViewData["HistogramData1"] = model.originalhistogram;
            //end original entropy

            model.ScrambleId2 = ($"images\\scrampleimage\\scrambledimages2" + ".jpg");
            var httpClient2 = new HttpClient();
            var stream2 = await httpClient2.GetStreamAsync(model.ScrambleFullPath2);
            Bitmap scrambledImage2 = new Bitmap(stream2);
            // Convert the bitmap image to a 2D array of pixel values
            int[,] pixelValues2 = _entropy.GetPixelValues(scrambledImage2);
            // Calculate global entropy
            model.ScrambleEntropy2 = _entropy.CalculateGlobalEntropy(pixelValues2);
            model.Scramblehistogram2 = _entropy.CalculateHistogram(scrambledImage2);
            // Display histogram values
            for (int i = 0; i < model.Scramblehistogram2.Length; i++)
            {
                Console.WriteLine($"Intensity Level {i}: {model.Scramblehistogram2[i]}");
            }

            // Prepare chart data
            ViewData["HistogramData2"] = model.Scramblehistogram2;
            model.ScrambleId3 = ($"images\\scrampleimage\\scrambledimages3" + ".jpg");
            var httpClient3 = new HttpClient();
            var stream3 = await httpClient3.GetStreamAsync(model.ScrambleFullPath3);
            Bitmap scrambledImage3 = new Bitmap(stream3);
            // Convert the bitmap image to a 2D array of pixel values
            int[,] pixelValues3 = _entropy.GetPixelValues(scrambledImage3);
            // Calculate global entropy
            model.ScrambleEntropy3 = _entropy.CalculateGlobalEntropy(pixelValues3);
            model.Scramblehistogram3 = _entropy.CalculateHistogram(scrambledImage3);
            // Display histogram values
            for (int i = 0; i < model.Scramblehistogram3.Length; i++)
            {
                Console.WriteLine($"Intensity Level {i}: {model.Scramblehistogram3[i]}");
            }

            // Prepare chart data
            ViewData["HistogramData3"] = model.Scramblehistogram3;
            model.ScrambleId4 = ($"images\\scrampleimage\\scrambledimages4" + ".jpg");
            var httpClient4 = new HttpClient();
            var stream4 = await httpClient4.GetStreamAsync(model.ScrambleFullPath4);
            Bitmap scrambledImage4 = new Bitmap(stream4);
            // Convert the bitmap image to a 2D array of pixel values
            int[,] pixelValues4 = _entropy.GetPixelValues(scrambledImage4);
            // Calculate global entropy
            model.ScrambleEntropy4 = _entropy.CalculateGlobalEntropy(pixelValues4);
            model.Scramblehistogram4 = _entropy.CalculateHistogram(scrambledImage4);
            // Display histogram values
            for (int i = 0; i < model.Scramblehistogram4.Length; i++)
            {
                Console.WriteLine($"Intensity Level {i}: {model.Scramblehistogram4[i]}");
            }

            // Prepare chart data
            ViewData["HistogramData4"] = model.Scramblehistogram4;
            model.ScrambleId5 = ($"images\\scrampleimage\\scrambledimages5" + ".jpg");
            var httpClient5 = new HttpClient();
            var stream5 = await httpClient5.GetStreamAsync(model.ScrambleFullPath5);
            Bitmap scrambledImage5 = new Bitmap(stream5);
            // Convert the bitmap image to a 2D array of pixel values
            int[,] pixelValues5 = _entropy.GetPixelValues(scrambledImage5);
            // Calculate global entropy
            model.ScrambleEntropy5 = _entropy.CalculateGlobalEntropy(pixelValues5);
            model.Scramblehistogram5 = _entropy.CalculateHistogram(scrambledImage5);
            // Display histogram values
            for (int i = 0; i < model.Scramblehistogram5.Length; i++)
            {
                Console.WriteLine($"Intensity Level {i}: {model.Scramblehistogram5[i]}");
            }

            // Prepare chart data
            ViewData["HistogramData5"] = model.Scramblehistogram5;

            model.ScrambleId6 = ($"images\\scrampleimage\\scrambledimages6" + ".jpg");
            var httpClient6 = new HttpClient();
            var stream6 = await httpClient5.GetStreamAsync(model.ScrambleFullPath6);
            Bitmap scrambledImage6 = new Bitmap(stream6);
            // Convert the bitmap image to a 2D array of pixel values
            int[,] pixelValues6 = _entropy.GetPixelValues(scrambledImage6);
            // Calculate global entropy
            model.ScrambleEntropy6 = _entropy.CalculateGlobalEntropy(pixelValues6);
            model.Scramblehistogram6 = _entropy.CalculateHistogram(scrambledImage6);
            // Display histogram values
            for (int i = 0; i < model.Scramblehistogram6.Length; i++)
            {
                Console.WriteLine($"Intensity Level {i}: {model.Scramblehistogram6[i]}");
            }
            // Prepare chart data
            ViewData["HistogramData6"] = model.Scramblehistogram6;

            model.ScrambleId7 = ($"images\\scrampleimage\\scrambledimages7" + ".jpg");
            var httpClient7 = new HttpClient();
            var stream7 = await httpClient7.GetStreamAsync(model.ScrambleFullPath7);
            Bitmap scrambledImage7 = new Bitmap(stream7);
            // Convert the bitmap image to a 2D array of pixel values
            int[,] pixelValues7 = _entropy.GetPixelValues(scrambledImage7);
            // Calculate global entropy
            model.ScrambleEntropy7 = _entropy.CalculateGlobalEntropy(pixelValues7);
            model.Scramblehistogram7 = _entropy.CalculateHistogram(scrambledImage7);
            // Display histogram values
            for (int i = 0; i < model.Scramblehistogram7.Length; i++)
            {
                Console.WriteLine($"Intensity Level {i}: {model.Scramblehistogram7[i]}");
            }
            // Prepare chart data
            ViewData["HistogramData7"] = model.Scramblehistogram7;

            model.ScrambleId8 = ($"images\\scrampleimage\\scrambledimages8" + ".jpg");
            var httpClient8 = new HttpClient();
            var stream8 = await httpClient7.GetStreamAsync(model.ScrambleFullPath8);
            Bitmap scrambledImage8 = new Bitmap(stream8);
            // Convert the bitmap image to a 2D array of pixel values
            int[,] pixelValues8 = _entropy.GetPixelValues(scrambledImage8);
            // Calculate global entropy
            model.ScrambleEntropy8 = _entropy.CalculateGlobalEntropy(pixelValues8);
            model.Scramblehistogram8 = _entropy.CalculateHistogram(scrambledImage8);
            // Display histogram values
            for (int i = 0; i < model.Scramblehistogram8.Length; i++)
            {
                Console.WriteLine($"Intensity Level {i}: {model.Scramblehistogram8[i]}");
            }
            // Prepare chart data
            ViewData["HistogramData8"] = model.Scramblehistogram8;

            model.ScrambleId9 = ($"images\\scrampleimage\\scrambledimages9" + ".jpg");
            var httpClient9 = new HttpClient();
            var stream9 = await httpClient7.GetStreamAsync(model.ScrambleFullPath9);
            Bitmap scrambledImage9 = new Bitmap(stream9);
            // Convert the bitmap image to a 2D array of pixel values
            int[,] pixelValues9 = _entropy.GetPixelValues(scrambledImage9);
            // Calculate global entropy
            model.ScrambleEntropy9 = _entropy.CalculateGlobalEntropy(pixelValues9);
            model.Scramblehistogram9 = _entropy.CalculateHistogram(scrambledImage9);
            // Display histogram values
            for (int i = 0; i < model.Scramblehistogram9.Length; i++)
            {
                Console.WriteLine($"Intensity Level {i}: {model.Scramblehistogram9[i]}");
            }
            // Prepare chart data
            ViewData["HistogramData9"] = model.Scramblehistogram9;

            model.ScrambleId10 = ($"images\\scrampleimage\\scrambledimages10" + ".jpg");
            var httpClient10 = new HttpClient();
            var stream10 = await httpClient7.GetStreamAsync(model.ScrambleFullPath10);
            Bitmap scrambledImage10 = new Bitmap(stream10);
            // Convert the bitmap image to a 2D array of pixel values
            int[,] pixelValues10 = _entropy.GetPixelValues(scrambledImage10);
            // Calculate global entropy
            model.ScrambleEntropy10 = _entropy.CalculateGlobalEntropy(pixelValues10);
            model.Scramblehistogram10 = _entropy.CalculateHistogram(scrambledImage10);
            // Display histogram values
            for (int i = 0; i < model.Scramblehistogram10.Length; i++)
            {
                Console.WriteLine($"Intensity Level {i}: {model.Scramblehistogram10[i]}");
            }
            // Prepare chart data
            ViewData["HistogramData10"] = model.Scramblehistogram10;

            return View(model);
        }

       

    }
}
