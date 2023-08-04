using HolidayAPI.Models;
using HolidayAPI.Storage;
using HolidayAPI.Storage.Rational.Models;

namespace HolidayAPI.Services;

public class HolidayService : IHolidayService
{
    private readonly IHolidayRepository _holidayRepository;

    public HolidayService(IHolidayRepository holidayRepository)
    {
        _holidayRepository = holidayRepository;
    }
    
    public async Task<IList<Holiday>> GetHolidays(string? country, string? region, int? year, HolidayType? holidayType, int? offset, int? limit)
    {
        var holidays = await _holidayRepository.Get();
        
        // TODO: Use country, region, year, holidayType, offset, limit

        return holidays.Select(MapHoliday).ToList();
    }
    
    private static Holiday MapHoliday(HolidayDb holidayDb)
    {
        return new Holiday
        {
            Name = holidayDb.Name,
            Description = holidayDb.Description,
            End = holidayDb.End,
            Start = holidayDb.Start,
            Type = MapType(holidayDb.Type),
            ExpirationDate = holidayDb.ExpirationDate,
            Countries = holidayDb.Countries.Select(x => x.Country.Name),
            Region = new List<string>() // TODO: Missing region
        };
    }
    
    private static HolidayType MapType(HolidayTypeDb holidayTypeDb)
    {
        return holidayTypeDb switch
        {
            HolidayTypeDb.Public => HolidayType.Public,
            HolidayTypeDb.Bank => HolidayType.Bank,
            HolidayTypeDb.School => HolidayType.School,
            HolidayTypeDb.Local => HolidayType.Local,
            HolidayTypeDb.Religious => HolidayType.Religious,
            HolidayTypeDb.National => HolidayType.National,
            _ => throw new ArgumentOutOfRangeException(nameof(holidayTypeDb), holidayTypeDb, null)
        };
    }
}