using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HolidayAPI.Storage.Rational.Models;

[Table("Methods")]
public class HolidayCountryDb
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public CountryDb Country { get; set; }
    public ICollection<RegionDb> Regions { get; set; }
}