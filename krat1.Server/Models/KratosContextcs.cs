using Microsoft.EntityFrameworkCore;
using krat1.Server.Models.Kratos;
using System.Collections.Generic;
using System.Reflection.Emit;
using Krat1.Server.Models.Kratos;

namespace Practica.Server.Models
{
    public class KratosContext : DbContext
    {
        public KratosContext(DbContextOptions<KratosContext> options) : base(options)
        {
        }
        public DbSet<ActividadEconomicas> ActividadEconomicas { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<Impuestos> Impuestos { get; set; }
        public DbSet<Inventarios> Inventarios { get; set; }
        public DbSet<Modulos> Modulos { get; set; }
        public DbSet<Permisos> Permisos { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<PuntoVentas> PuntoVentas { get; set; }
        public DbSet<RegimenesTributarios> RegimenesTributarios { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<TiposSociedades> TiposSociedades { get; set; }
        public DbSet<TokenEmpresaUsuarios> TokenEmpresaUsuarios { get; set; }
        public DbSet<TratamientosEmpresas> TratamientosEmpresas { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
            modelBuilder.Entity<Empresas>()
                .HasOne(e => e.empresaSociedad_fk)
                .WithMany()
                .HasForeignKey(e => e.tiposociedadId)
                .OnDelete(DeleteBehavior.Restrict);

      
            modelBuilder.Entity<Empresas>()
                .HasOne(e => e.empresaActividad_fk)
                .WithMany()
                .HasForeignKey(e => e.actividadId)
                .OnDelete(DeleteBehavior.Restrict);

            
            modelBuilder.Entity<Empresas>()
                .HasOne(e => e.empresaRegimen_fk)
                .WithMany()
                .HasForeignKey(e => e.regimenId)
                .OnDelete(DeleteBehavior.Restrict);

           
            modelBuilder.Entity<Roles>()
                .HasOne(r => r.rolempresaId)
                .WithMany()
                .HasForeignKey(r => r.empresaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Productos>()
                .HasOne(p => p.tratamiento_fk)
                .WithMany()
                .HasForeignKey(p => p.Impuesto)
                .OnDelete(DeleteBehavior.Restrict);

        
            modelBuilder.Entity<Productos>()
                .HasOne(p => p.categoria_fk)
                .WithMany()
                .HasForeignKey(p => p.categoria)
                .OnDelete(DeleteBehavior.Restrict);

       
            modelBuilder.Entity<Inventarios>()
                .HasOne(i => i.producto_fk)
                .WithMany()
                .HasForeignKey(i => i.productoId)
                .OnDelete(DeleteBehavior.Restrict);

    
            modelBuilder.Entity<Inventarios>()
                .HasOne(i => i.puntoVenta_fk)
                .WithMany()
                .HasForeignKey(i => i.puntoVentaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Permisos>()
                .HasOne(p => p.permisosrolesId)
                .WithMany()
                .HasForeignKey(p => p.rolesId)
                .OnDelete(DeleteBehavior.Restrict);

     
            modelBuilder.Entity<Permisos>()
                .HasOne(p => p.permisosmodulosId)
                .WithMany()
                .HasForeignKey(p => p.modulosId)
                .OnDelete(DeleteBehavior.Restrict);

           
            modelBuilder.Entity<PuntoVentas>()
                .HasOne(pv => pv.usuario_fk)
                .WithMany()
                .HasForeignKey(pv => pv.ResponsableId)
                .OnDelete(DeleteBehavior.Restrict);

         
            modelBuilder.Entity<TokenEmpresaUsuarios>()
                .HasOne(teu => teu.tokenEmpresa_fk)
                .WithMany()
                .HasForeignKey(teu => teu.token)
                .OnDelete(DeleteBehavior.Restrict);

        
            modelBuilder.Entity<TokenEmpresaUsuarios>()
                .HasOne(teu => teu.tokenUsuarios_fk)
                .WithMany()
                .HasForeignKey(teu => teu.tokenUsuario)
                .OnDelete(DeleteBehavior.Restrict);

        
            modelBuilder.Entity<Usuarios>()
                .HasOne(u => u.usuariosrolesId)
                .WithMany()
                .HasForeignKey(u => u.rolesId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Usuarios>()
                .HasOne(u => u.tokenUsuario_fk)
                .WithMany()
                .HasForeignKey(u => u.tokenUsuario)
                .OnDelete(DeleteBehavior.Restrict);

          
            modelBuilder.Entity<TratamientosEmpresas>()
                .HasOne(te => te.empresa_fk)
                .WithMany()
                .HasForeignKey(te => te.empresaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TratamientosEmpresas>()
                .HasOne(te => te.impuestos_fk)
                .WithMany()
                .HasForeignKey(te => te.tipoImpuesto)
                .OnDelete(DeleteBehavior.Restrict);

         
            modelBuilder.Entity<Categorias>()
                .HasOne(c => c.categoriaPadre_fk)
                .WithMany()
                .HasForeignKey(c => c.categoriaPadre)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
