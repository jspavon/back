using generic.app.Infrastructure.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace generic.app.Infrastructure.Context.Configurations.Base
{
    public class BaseEntityConfig<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(e => e.CreationDate)
                .HasColumnName("CreationDate")
                .HasColumnType("datetime");

            builder.Property(e => e.CreationUser)
                .HasColumnName("CreationUser")
                .HasMaxLength(300)
                .IsUnicode(false);

            builder.Property(e => e.ModificationDate)
                .HasColumnName("ModificationDate")
                .HasColumnType("datetime");

            builder.Property(e => e.ModificationUser)
                .HasColumnName("ModificationUser")
                .HasMaxLength(300)
                .IsUnicode(false);

            builder.Property(e => e.Deleted)
                .HasColumnName("Deleted")
                .IsUnicode(false);
        }
    }
}
