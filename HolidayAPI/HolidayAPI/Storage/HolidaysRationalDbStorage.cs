using HolidayAPI.Storage.Rational;
using HolidayAPI.Storage.Rational.Models;
using Microsoft.EntityFrameworkCore;

namespace HolidayAPI.Storage;

public class RationalDbHolidayStorage : IHolidayRepository
{
    private readonly ILogger<RationalDbHolidayStorage> _logger;

    public RationalDbHolidayStorage(ILogger<RationalDbHolidayStorage> logger)
    {
        _logger = logger;
    }

    public async Task<IList<HolidayDb>> Get()
    {
        await using var db = new HolidayContext();
        
        var routes = await db.Holidays.ToListAsync();
        return routes;
    }
    
    public async Task<IList<HolidayDb>> Get(string? country, string? region, int? year, HolidayTypeDb? holidayType, int offset, int limit)
    {
        await using var db = new HolidayContext();
        
        var routes = await db.Holidays.Where(x => QueryBuilder(x, country, region, year, holidayType))
            .Skip(offset)
            .Take(limit)
            .ToListAsync();
        
        return routes;
    }

    public async Task<HolidayDb?> Get(Guid id)
    {
        await using var db = new HolidayContext();
        
        var route = await db.Holidays.FirstOrDefaultAsync(x => x.Id == id);
        return route;
    }

    private static bool QueryBuilder(HolidayDb holidayDb, string? country, string? region, int? year, HolidayTypeDb? holidayType)
    {
        if (country != null && holidayDb.Countries.All(x => x.Country.Name != country))
        {
            return false;
        }
        
        // if (region != null && holidayDb.Countries.All(x => x.Country.Regions.All(y => y.Name != region)))
        // {
        //     return false;
        // }
        
        if (year != null && holidayDb.Start.Year != year)
        {
            return false;
        }
        
        if (holidayType != null && holidayDb.Type != holidayType)
        {
            return false;
        }

        return true;
    }
}