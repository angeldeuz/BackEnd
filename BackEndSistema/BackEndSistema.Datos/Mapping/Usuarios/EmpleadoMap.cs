using BackEndSistema.Entidades.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BackEndSistema.Datos.Mapping.Usuarios
{
    public class EmpleadoMap : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.ToTable("Empleados")
                .HasKey(e => e.idEmpleado);
        }
    }
}
