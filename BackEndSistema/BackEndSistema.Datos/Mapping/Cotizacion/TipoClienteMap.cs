using System;
using System.Collections.Generic;
using System.Text;
using BackEndSistema.Entidades.Cotizacion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEndSistema.Datos.Mapping.Cotizacion
{
    public class TipoClienteMap : IEntityTypeConfiguration<TipoCliente>
    {
        public void Configure(EntityTypeBuilder<TipoCliente> builder)
        {
            builder.ToTable("TipoCliente")
                .HasKey(t => t.idTipoCliente);
        }
    }
}
