using BurberDinner.Domain.Common.Models;
using BurberDinner.Domain.Menu;
using BurberDinner.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace BurberDinner.Infrastructure.Persistence;


public class BuberDinnerDbContext: DbContext {
  
  private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;
  public BuberDinnerDbContext(DbContextOptions<BuberDinnerDbContext> options, PublishDomainEventsInterceptor publishDomainEventsInterceptor)
    : base(options) 
  {
    _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
  }
  public DbSet<Menu> Menus { get; set; } = null!;

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder
      .Ignore<List<IDomainEvent>>()
      .ApplyConfigurationsFromAssembly(typeof(BuberDinnerDbContext).Assembly);

    base.OnModelCreating(modelBuilder);
  }
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
    base.OnConfiguring(optionsBuilder);
  }
}
