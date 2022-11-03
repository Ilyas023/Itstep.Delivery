using Itstep.Delivery.RestaurantService.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Itstep.Delivery.RestaurantService.Api.Persistance;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<Company> Companies { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Dish> Dishes { get; set; }
}
