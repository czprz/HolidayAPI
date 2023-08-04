using HolidayAPI.Storage.Rational.Models;

namespace HolidayAPI.Storage;

public interface IHolidayRepository
{
    Task<IList<HolidayDb>> Get();
    Task<HolidayDb?> Get(Guid id);
}