using HolidayAPI.Models;

namespace HolidayAPI.Services;

public interface IHolidayService
{
    public Task<IList<Holiday>> GetHolidays(string? country, string? region, int? year, HolidayType? holidayType, int? offset, int? limit);
}