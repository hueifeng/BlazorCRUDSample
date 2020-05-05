using BlazorServerCRUDSample.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerCRUDSample.Shared.Data
{
    public class AppContext : DbContext
    {
        public virtual DbSet<Student> Students { get; set; }
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
        }



    }
}
