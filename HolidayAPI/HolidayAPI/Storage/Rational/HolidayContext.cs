using Gateway.Routing.Storage.Rational;
using HolidayAPI.Storage.Rational.Models;
using Microsoft.EntityFrameworkCore;

namespace HolidayAPI.Storage.Rational;

public class HolidayContext : DbContext
{
    public DbSet<HolidayDb> Holidays { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite(StorageConnectionString.Get());
}