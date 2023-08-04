using HolidayAPI.Storage.Rational.Models;
using Microsoft.EntityFrameworkCore;

namespace HolidayAPI.Storage.Rational;

public class HolidayContext : DbContext
{
    public DbSet<HolidayDb> Holidays { get; set; }

    private string DbPath { get; }

    public HolidayContext()
    {
        const Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "holidays.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}