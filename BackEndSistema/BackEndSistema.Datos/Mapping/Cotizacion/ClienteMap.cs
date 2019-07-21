using BackEndSistema.Entidades.Cotizacion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEndSistema.Datos.Mapping.Cotizacion
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente")
                .HasKey(c => c.idCliente);
        }
    }
}
