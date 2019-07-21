using BackEndSistema.Entidades.Cotizacion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEndSistema.Datos.Mapping.Cotizacion
{
    public class CotizacionMap : IEntityTypeConfiguration<CotizacionE>
    {
        public void Configure(EntityTypeBuilder<CotizacionE> builder)
        {
            builder.ToTable("Cotizacion")
                .HasKey(c => c.idCotizacion);
        }
    }
}
