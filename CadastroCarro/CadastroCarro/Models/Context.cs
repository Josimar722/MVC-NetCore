
using Microsoft.EntityFrameworkCore;


namespace CadastroCarro.Models
{
    public class Context : DbContext
    {

        public DbSet<Carro> Carros { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
    }
}
