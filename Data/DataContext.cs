using Microsoft.EntityFrameworkCore;
using Consultar_.Models;
using System.Linq;

namespace Consultar_.Data {
    public class DataContext : DbContext {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {  }

        public DbSet<Usuario> Usuarios {get; set;}

    }
}