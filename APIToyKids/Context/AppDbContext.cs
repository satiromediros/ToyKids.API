﻿using APIToyKids.Domain;
using Microsoft.EntityFrameworkCore;

namespace APIToyKids.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {            
        }

        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<Reserva>? Reservas { get; set; }
    }
}
