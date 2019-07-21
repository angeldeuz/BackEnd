using BackEndSistema.Entidades.Cotizacion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEndSistema.Datos.Mapping.Cotizacion
{
    public class DetalleCotizacionMap : IEntityTypeConfiguration<Detalles_Cotizacion>
    {
        public void Configure(EntityTypeBuilder<Detalles_Cotizacion> builder)
        {
            builder.ToTable("Detalles_Cotizacion")
                .HasKey(d => d.idDetalle);
        }
    }
}
