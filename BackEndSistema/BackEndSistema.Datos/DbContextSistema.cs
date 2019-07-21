using BackEndSistema.Datos.Mapping;
using BackEndSistema.Datos.Mapping.Cotizacion;
using BackEndSistema.Datos.Mapping.Usuarios;
using BackEndSistema.Entidades;
using BackEndSistema.Entidades.Cotizacion;
using BackEndSistema.Entidades.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace BackEndSistema.Datos
{
    public class DbContextSistema : DbContext
    {
        public DbSet<TipoCliente> TipoClientes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Estatus> Estatus { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<CotizacionE> Cotizaciones { get; set; }
        public DbSet<Detalles_Cotizacion> DetallesCotizacion { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbContextSistema(DbContextOptions<DbContextSistema> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TipoClienteMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new EstatusMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new ProductoMap());
            modelBuilder.ApplyConfiguration(new CotizacionMap());
            modelBuilder.ApplyConfiguration(new DetalleCotizacionMap());
            modelBuilder.ApplyConfiguration(new EmpleadoMap());
        }
    }
}
