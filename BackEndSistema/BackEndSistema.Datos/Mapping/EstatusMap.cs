using BackEndSistema.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEndSistema.Datos.Mapping
{
    public class EstatusMap : IEntityTypeConfiguration<Estatus>
    {
        public void Configure(EntityTypeBuilder<Estatus> builder)
        {
            builder.ToTable("Estatus")
               .HasKey(e => e.idEstatus);
        }
    }
}
