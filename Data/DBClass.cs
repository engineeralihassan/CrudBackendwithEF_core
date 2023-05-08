using FullStackCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace FullStackCrud.Data
{

    public class DBClass : DbContext
    {
        public DBClass(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Student> students { get; set; }
    }

}
