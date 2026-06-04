using ApiRest.Models.Entity;
using ApiRest.Utils.Enum;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace ApiRest.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuración de precisión para FichajeEntity
            modelBuilder.Entity<FichajeEntity>()
                .Property(f => f.Latitud)
                .HasPrecision(9, 6);

            modelBuilder.Entity<FichajeEntity>()
                .Property(f => f.Longitud)
                .HasPrecision(9, 6);

            // Configuración de precisión para SedeEntity
            modelBuilder.Entity<SedeEntity>()
                .Property(s => s.Latitud)
                .HasPrecision(9, 6);

            modelBuilder.Entity<SedeEntity>()
                     .Property(s => s.Longitud)
                     .HasPrecision(9, 6);

            modelBuilder.Entity<AsignacionTurnoEntity>()
                    .HasIndex(a => new { a.IdTurno, a.IdEmpleado })
                    .IsUnique();


            modelBuilder.Entity<CorreccionFichajeEntity>()
                  .HasOne(c => c.Fichaje)
                  .WithMany(f => f.Correcciones)
                  .HasForeignKey(c => c.IdFichaje)
                  .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CorreccionFichajeEntity>()
                .HasOne(c => c.Empleado)
                .WithMany(e => e.Correcciones)
                .HasForeignKey(c => c.IdEmpleado)
                .OnDelete(DeleteBehavior.Cascade);
            // guradar enum como string 
            modelBuilder.Entity<TurnoEntity>()
               .Property(t => t.Nombre)
               .HasConversion<string>()      
               .HasMaxLength(50);
            // guardar enum como string 
            modelBuilder.Entity<SolicitudAusenciaEntity>()
                .Property(s => s.EstadoSolicitudAusencia)
                .HasConversion<string>()                 
                .HasMaxLength(20);

            // guardar enum como string 
            modelBuilder.Entity<SolicitudAusenciaEntity>()
                .Property(s => s.TipoAusencia)
                .HasConversion<string>()         
                .HasMaxLength(50);
            // guardar enum como string
            modelBuilder.Entity<ReporteEntity>() 
                .Property(r => r.TipoReporte)
                .HasConversion<string>()
                .HasMaxLength(50);

            // guardar enum como string
            modelBuilder.Entity<ReglaTurnoEntity>() 
                .Property(e => e.TipoReglaTurno)
                .HasConversion<string>()
                .HasMaxLength(50);
            // guardar enum como string
            modelBuilder.Entity<NotificacionEntity>()  
               .Property(n => n.TipoNotificacion)
               .HasConversion<string>()              
               .HasMaxLength(50);
            // guardar enum como string
            modelBuilder.Entity<NotificacionEntity>()
              .Property(n => n.EstadoNotificacion)
              .HasConversion<string>()
              .HasMaxLength(50);
            // guardar enum como string
            modelBuilder.Entity<FichajeEntity>()
               .Property(f => f.FuenteFichaje)
               .HasConversion<string>()
               .HasMaxLength(50);
            // guardar enum como string
            modelBuilder.Entity<FichajeEntity>()
                .Property(f => f.TipoFichaje)
                .HasConversion<string>()
                .HasMaxLength(50);
            modelBuilder.Entity<UsuarioEntity>(entity =>
            {
                entity.HasOne(u => u.AppUser)
                      .WithMany()
                      .HasForeignKey(u => u.IdAppUser)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(u => u.Empresa)
                      .WithMany()
                      .HasForeignKey(u => u.IdEmpresa)
                      .OnDelete(DeleteBehavior.Restrict);

            });
            // guardar enum como string
            modelBuilder.Entity<EmpleadoEntity>(entity =>
            {
                entity.Property(e => e.Puesto)
                      .HasConversion<string>()
                      .HasMaxLength(50);

                entity.HasOne(e => e.Empresa)
                      .WithMany(emp => emp.Empleados)
                      .HasForeignKey(e => e.IdEmpresa)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Usuario)
                      .WithMany()
                      .HasForeignKey(e => e.IdUsuario)
                      .OnDelete(DeleteBehavior.Restrict);


            });


            // guardar enum como string
            modelBuilder.Entity<DocumentoEmpleadoEntity>()
                .Property(d => d.TipoDocumento)
                .HasConversion<string>()
                .HasMaxLength(50);
            // guardar enum como string
            modelBuilder.Entity<DisponibilidadEntity>()
                .Property(d => d.DiaSemana)
                .HasConversion<string>()
                .HasMaxLength(15);
            // guardar enum como string
            modelBuilder.Entity<CorreccionFichajeEntity>()
                .Property(c => c.EstadoCorreccionFichaje)
                .HasConversion<string>()
                .HasMaxLength(20)
                .HasDefaultValue(EstadoCorreccionFichaje.Pendiente);
            // guardar enum como string
            modelBuilder.Entity<AsignacionTurnoEntity>()
                .Property(a => a.Estado)
                .HasConversion<string>()
                .HasMaxLength(50);
            // guardar enum como string
            modelBuilder.Entity<FichajeEntity>()
                .Property(a => a.TipoFichaje)
                .HasConversion<string>()
                .HasMaxLength(50);
            
            modelBuilder.Entity<FichajeEntity>()
                .Property(a => a.FuenteFichaje)
                .HasConversion<string>()
                .HasMaxLength(50);

            modelBuilder.Entity<DepartamentoEntity>()
                .Property(d => d.Nombre)
                .HasConversion<string>()
                .HasMaxLength(50);
            modelBuilder.Entity<EmpleadoEntity>()
             .Property(d => d.DepartamentoNombre)
             .HasConversion<string>()
             .HasMaxLength(50);

            modelBuilder.Entity<EmpleadoEntity>()
             .Property(d => d.TipoContrato)
             .HasConversion<string>()
             .HasMaxLength(50);

            modelBuilder.Entity<ResponsableEmpleadoEntity>()
                .HasOne(re => re.Responsable)
                .WithMany()
                .HasForeignKey(re => re.IdResponsable)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ResponsableEmpleadoEntity>()
                .HasOne(re => re.Empleado)
                .WithMany()
                .HasForeignKey(re => re.IdEmpleado)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ResponsableEmpleadoEntity>()
                .HasOne(re => re.Empresa)
                .WithMany()
                .HasForeignKey(re => re.IdEmpresa)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ResponsableEntity>()
                .HasOne(r => r.Empleado)
                .WithMany()
                .HasForeignKey(r => r.IdEmpleado)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ResponsableEntity>()
                .HasOne(r => r.Empresa)
                .WithMany()
                .HasForeignKey(r => r.IdEmpresa)
                .OnDelete(DeleteBehavior.Restrict);




        }


        public DbSet<AsignacionTurnoEntity> AsignacionTurnos { get; set; }
        public DbSet<CorreccionFichajeEntity> CorreccionFichajes { get; set; }
        public DbSet<DisponibilidadEntity> Disponibilidades { get; set; }
        public DbSet<DocumentoEmpleadoEntity> DocumentoEmpleados { get; set; }
        public DbSet<EmpleadoEntity> Empleados { get; set; }
        public DbSet<FichajeEntity> Fichajes { get; set; }
        public DbSet<NotificacionEntity> Notificaciones { get; set; }
        public DbSet<ReglaTurnoEntity> ReglaTurnos { get; set; }
        public DbSet<ReporteEntity> Reportes { get; set; }
        public DbSet<SedeEntity> Sedes { get; set; }
        public DbSet<SolicitudAusenciaEntity> SolicitudAusencias { get; set; }
        public DbSet<TurnoEntity> Turnos { get; set; }
        public DbSet<EmpresaEntity> Empresas { get; set; }
        public DbSet<DepartamentoEntity> Departamentos { get; set; }
        public DbSet<ResponsableEmpleadoEntity> ResponsableEmpleados { get; set; }
        public DbSet<ResponsableEntity> Responsables { get; set; }
        public DbSet<UsuarioEntity> Usuarios { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

    }
}
