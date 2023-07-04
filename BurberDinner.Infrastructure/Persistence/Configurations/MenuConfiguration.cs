

using BurberDinner.Domain.HostAggregate.ValueObjects;
using BurberDinner.Domain.Menu;
using BurberDinner.Domain.MenuAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BurberDinner.Infrastructure.Persistence.Configurations;


public class MenuConfigurations : IEntityTypeConfiguration<Menu>
{
  public void Configure(EntityTypeBuilder<Menu> builder)
  {
    ConfigureMenusTable(builder);
  }

  private void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
  {
    builder.ToTable("Menus");

    builder.HasKey(m => m.Id);

    builder.Property(m => m.Id)
      .ValueGeneratedNever()
      .HasConversion(
        id => id.Value,
        value => MenuId.Create(value)
      );
    
    builder.Property(m => m.Name)
      .HasMaxLength(100);

    builder.Property(m => m.Description)
      .HasMaxLength(100);

    builder.OwnsOne(m => m.AverageRating);

    builder.Property(m => m.HostId)
      .HasConversion(
        id => id.Value,
        value => HostId.Create(value)
      );
  }
}