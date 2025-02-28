using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ModelConfiguration : IEntityTypeConfiguration<Model>
{
    public void Configure(EntityTypeBuilder<Model> builder)
    {
        builder.ToTable("Models").HasKey(m => m.Id);

        builder.Property(m => m.Id).HasColumnName("Id").IsRequired();
        builder.Property(m => m.BrandId).HasColumnName("BrandId");
        builder.Property(m => m.FuelId).HasColumnName("FuelId");
        builder.Property(m => m.TransmissionId).HasColumnName("TransmissionId");
        builder.Property(m => m.Name).HasColumnName("Name");
        builder.Property(m => m.Year).HasColumnName("Year");
        builder.Property(m => m.DailyPrice).HasColumnName("DailyPrice");
        //builder.Property(m => m.Brand).HasColumnName("Brand");
        //builder.Property(m => m.Fuel).HasColumnName("Fuel");
        //builder.Property(m => m.Transmission).HasColumnName("Transmission");
        builder.Property(m => m.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(m => m.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(m => m.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(m => !m.DeletedDate.HasValue);
    }
}