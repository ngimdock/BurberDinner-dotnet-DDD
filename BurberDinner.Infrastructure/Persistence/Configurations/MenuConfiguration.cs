using BurberDinner.Domain.HostAggregate.ValueObjects;
using BurberDinner.Domain.Menu;
using BurberDinner.Domain.MenuAggregate.Entities;
using BurberDinner.Domain.MenuAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BurberDinner.Infrastructure.Persistence.Configurations;


public class MenuConfigurations : IEntityTypeConfiguration<Menu>
{
  public void Configure(EntityTypeBuilder<Menu> builder)
  {
    ConfigureMenusTable(builder);
    ConfigureMenuSectionsTable(builder);
    ConfigureMenuDinnerIdsTable(builder);
    ConfigureMenuReviewIdsTable(builder);
    
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

  private void ConfigureMenuSectionsTable(EntityTypeBuilder<Menu> builder)
  {
    builder.OwnsMany(m => m.Sections, sectionBuilder => {

      sectionBuilder.ToTable("MenuSections");

      sectionBuilder.HasKey("Id", "MenuId");

      sectionBuilder.WithOwner().HasForeignKey("MenuId");


      sectionBuilder.Property(mS => mS.Id)
        .ValueGeneratedNever()
        .HasColumnName("MenuSectionId")
        .HasConversion(
          id => id.Value,
          value => MenuSectionId.Create(value)
        );

      sectionBuilder.Property(mS => mS.Name)
        .HasMaxLength(100);

      sectionBuilder.Property(mS => mS.Description)
        .HasMaxLength(100);

      sectionBuilder.OwnsMany(mS => mS.Items, itemBuilder => {
        itemBuilder.ToTable("MenuItems");

        itemBuilder.WithOwner().HasForeignKey("MenuSectionId", "MenuItemId");

        itemBuilder.HasKey(nameof(MenuItem.Id), "MenuSectionId", "MenuItemId");

        itemBuilder.Property(mI => mI.Id)
          .ValueGeneratedNever()
          .HasColumnName("MenuItemId")
          .HasConversion(
            id => id.Value,
            value => MenuItemId.Create(value)
          );
        
        itemBuilder.Property(mI => mI.Name)
          .HasMaxLength(100);
        
        itemBuilder.Property(mI => mI.Description)
          .HasMaxLength(100);
      });

      sectionBuilder.Navigation(s => s.Items).Metadata.SetField("_items");
      sectionBuilder.Navigation(s => s.Items).UsePropertyAccessMode(PropertyAccessMode.Field);
    });

    builder.Metadata.FindNavigation(nameof(Menu.Sections))!
      .SetPropertyAccessMode(PropertyAccessMode.Field);
  }

  private void ConfigureMenuDinnerIdsTable(EntityTypeBuilder<Menu> builder)
  {
    builder.OwnsMany(m => m.DinnerIds, dinnerIdBuilder => {
      dinnerIdBuilder.ToTable("MenuDinnerIds");

      dinnerIdBuilder.WithOwner().HasForeignKey("MenuId");

      dinnerIdBuilder.HasKey("Id");

      dinnerIdBuilder.Property(d => d.Value)
        .ValueGeneratedNever()
        .HasColumnName("DinnerId");
    });

    builder.Metadata.FindNavigation(nameof(Menu.DinnerIds))!
      .SetPropertyAccessMode(PropertyAccessMode.Field);
  }

  private void ConfigureMenuReviewIdsTable(EntityTypeBuilder<Menu> builder)
  {
     builder.OwnsMany(m => m.MenuReviewIds, menuReviewBuilder => {
      menuReviewBuilder.ToTable("MenuReviewIds");

      menuReviewBuilder.WithOwner().HasForeignKey("MenuId");

      menuReviewBuilder.HasKey("Id");

      menuReviewBuilder.Property(d => d.Value)
        .ValueGeneratedNever()
        .HasColumnName("MenuReviewId");
    });

    builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))!
      .SetPropertyAccessMode(PropertyAccessMode.Field);
  }
}