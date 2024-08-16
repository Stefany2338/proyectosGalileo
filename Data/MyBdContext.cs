using System;
using Microsoft.EntityFrameworkCore;
using Test.Models;  // Asegúrate de usar el espacio de nombres correcto para tus modelos

namespace Test.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        // DbSet representa una tabla en la base de datos.
        public DbSet<User> users { get; set; }
    }
}
