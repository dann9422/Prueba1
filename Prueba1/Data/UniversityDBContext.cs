using Microsoft.EntityFrameworkCore;
using Prueba1.Models.DataModels;

namespace Prueba1.Data
{
    public class UniversityDBContext : DbContext
    {
        public UniversityDBContext (DbContextOptions<UniversityDBContext> options): base(options)
        {

        }

        // TODO ADD DBSET (TABLAS DE LA BASE DE DATOS Y METODOS )

        public DbSet<User>? Users { get; set; }
        public DbSet<Course>? Courses { get; set; }

    }
}
