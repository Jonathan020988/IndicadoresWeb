namespace IndicadoresWeb.Data;


using Microsoft.EntityFrameworkCore;
using System;
using IndicadoresWeb.Models; // Asegúrate de cambiar "IndicadoresWeb" por el namespace de tu proyecto

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

    // Agregar DbSets para cada tabla sin claves foráneas
    public DbSet<Frecuencia> Frecuencias { get; set; }
    public DbSet<Fuente> Fuentes { get; set; }
    public DbSet<Represenvisual> RepresenVisuales { get; set; }
    public DbSet<Rol> Roles { get; set; }
    public DbSet<Seccion> Secciones { get; set; }
    public DbSet<Subseccion> Subsecciones { get; set; }
    public DbSet<TipoActor> TiposActor { get; set; }
    public DbSet<TipoIndicador> TiposIndicador { get; set; }
    public DbSet<UnidadMedicion> UnidadesMedicion { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Sentido> Sentidos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
