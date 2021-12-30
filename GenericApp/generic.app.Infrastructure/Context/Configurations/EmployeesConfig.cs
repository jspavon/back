using generic.app.Infrastructure.Context.Configurations.Base;
using generic.app.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generic.app.Infrastructure.Context.Configurations
{
    public class EmployeesConfig : BaseEntityConfig<Employees>
    {
        public void Configure(EntityTypeBuilder<Employees> builder)
        {
            builder.ToTable("Tbl_Employees");

            builder.HasKey(e => new { e.Id })
                   .HasName("PK_Tbl_Employees");

            builder.Property(e => e.Id)
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            builder.Property(e => e.Cedula)
                   .HasColumnName("Cedula")
                   .IsRequired();

            builder.Property(e => e.Nombres)
                   .HasColumnName("Nombres")
                   .IsRequired();

            builder.Property(e => e.Sexo)
                   .HasColumnName("Sexo")
                   .IsUnicode(false)
                   .IsRequired();

            builder.Property(e => e.FechaNacimiento)
                   .HasColumnName("FechaNacimiento")
                   .HasColumnType("datetime")
                   .IsRequired();

            builder.Property(e => e.Salario)
                   .HasColumnName("Salario")
                   .IsRequired();

            builder.Property(e => e.Vacuna)
                   .HasColumnName("Name")
                   .IsUnicode(false)
                   .IsRequired();


            base.Configure(builder);

        }

    }
}
