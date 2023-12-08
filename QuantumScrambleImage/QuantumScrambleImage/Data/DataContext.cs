using Microsoft.EntityFrameworkCore;
using QuantumScrambleImage.Data.Entities;

namespace QuantumScrambleImage.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }

        public DbSet<Image>Images { get; set; }

    }
}
