using Asp.Versioning.Builder;
using HolidayAPI.Services;

namespace HolidayAPI.Endpoints;

public static class HolidayEndpoints
{
    public static void AddHolidayEndpoints(this WebApplication app, ApiVersionSet apiVersionSet)
    {
        app.MapGet("codes", GetHolidays)
            .WithApiVersionSet(apiVersionSet)
            .MapToApiVersion(1)
            .CacheOutput("expires5s");
    }

    private static async Task<IResult> GetHolidays(int offset, int limit, IHolidayService holidayService)
    {
        var holidays = await holidayService.GetHolidays(null, null, null, null, offset, limit);
        return !holidays.Any() ? Results.NotFound() : Results.Ok(holidays);
    }
}