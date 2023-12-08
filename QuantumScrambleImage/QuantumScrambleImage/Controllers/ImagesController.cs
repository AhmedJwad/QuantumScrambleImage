using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuantumScrambleImage.Data;
using QuantumScrambleImage.Helpers;

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
    }
}
