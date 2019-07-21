using BackEndSistema.Entidades.Cotizacion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEndSistema.Datos.Mapping.Cotizacion
{
    public class ProductoMap : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Productos")
                .HasKey(p => p.idProducto);
        }
    }
}
