using System;
using Gestor_de_Rutinas___GYM.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestor_de_Rutinas___GYM.Data
{
    public class GymContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Rutina> Rutinas { get; set; }
        public DbSet<DiaEntrenamiento> DiasEntrenamiento { get; set; }
        public DbSet<Ejercicio> Ejercicios { get; set; }
        public DbSet<EjercicioBase> EjerciciosBase { get; set; }
        public DbSet<DetalleAvanzado> DetallesAvanzados { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\leose\OneDrive\Escritorio\Gestor de Rutinas - GYM\gymmanager.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // --- CLIENTE ---
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(c => c.IdCliente);
                entity.Property(c => c.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(c => c.Apellido).IsRequired().HasMaxLength(100);
                entity.Property(c => c.Objetivo).HasMaxLength(200);
            });

            // --- RUTINA ---
            modelBuilder.Entity<Rutina>(entity =>
            {
                entity.HasKey(r => r.IdRutina);
                entity.Property(r => r.Nombre).IsRequired().HasMaxLength(150);
                entity.Property(r => r.Descripcion).HasMaxLength(500);

                // Relación 1:N Rutina - DiaEntrenamiento
                entity.HasMany(r => r.Dias)
                      .WithOne()
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Relacion N:M Cliente - Rutina
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Rutinas)
                .WithMany() // Sin propiedad inversa, ya que Rutina no tiene lista de clientes
                .UsingEntity<Dictionary<string, object>>(
                    "ClienteRutina", // Nombre de la tabla intermedia
                    j => j.HasOne<Rutina>().WithMany().HasForeignKey("IdRutina"),
                    j => j.HasOne<Cliente>().WithMany().HasForeignKey("IdCliente"),
                    j =>
                    {
                        j.HasKey("IdCliente", "IdRutina");
                        j.ToTable("ClienteRutina");
                    }
                );

            // --- DIA ENTRENAMIENTO ---
            modelBuilder.Entity<DiaEntrenamiento>(entity =>
            {
                entity.HasKey(d => d.IdDia);
                entity.Property(d => d.DiaSemana).IsRequired().HasMaxLength(20);
                entity.Property(d => d.GrupoMuscular).HasMaxLength(100);

                entity.HasMany(d => d.Ejercicios)
                      .WithOne()
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // --- EJERCICIO ---
            modelBuilder.Entity<Ejercicio>(entity =>
            {
                entity.HasKey(e => e.IdEjercicio);
                entity.Property(e => e.Series).HasMaxLength(10);
                entity.Property(e => e.Repeticiones);
                entity.Property(e => e.Descanso);

                // Relación N:1 con EjercicioBase
                entity.HasOne<EjercicioBase>()
                      .WithMany()
                      .HasForeignKey("EjercicioBaseId");

                // Relación 1:1 con DetalleAvanzado
                modelBuilder.Entity<Ejercicio>()
                            .HasOne(e => e.DetalleAvanzado)
                            .WithOne()
                            .HasForeignKey<DetalleAvanzado>(d => d.EjercicioId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .IsRequired(false);
            });

            // --- EJERCICIO BASE ---
            modelBuilder.Entity<EjercicioBase>(entity =>
            {
                entity.HasKey(b => b.IdEjercicioBase);
                entity.Property(b => b.Nombre).IsRequired().HasMaxLength(150);
                entity.Property(b => b.GrupoMuscular).HasMaxLength(100);
                entity.Property(b => b.Descripcion).HasMaxLength(500);
            });

            // --- DETALLE AVANZADO ---
            modelBuilder.Entity<DetalleAvanzado>(entity =>
            {
                entity.HasKey(d => d.IdDetalle);
                entity.Property(d => d.PorcentajeRM).HasPrecision(5, 2);
                entity.Property(d => d.RM).HasPrecision(6, 2);
                entity.Property(d => d.Nota).HasMaxLength(200);
            });
        }
    }
}



