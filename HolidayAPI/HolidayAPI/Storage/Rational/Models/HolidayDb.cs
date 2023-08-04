using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HolidayAPI.Storage.Rational.Models;

[Table("Holidays")]
public class HolidayDb
{
    [Key]
    public Guid Id { get; set; }
    
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public HolidayTypeDb Type { get; set; }
    
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    
    public DateTime? ExpirationDate { get; set; }

    public ICollection<HolidayCountryDb> Countries { get; set; } = new List<HolidayCountryDb>();

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}