namespace HolidayAPI.Models;

public class Holiday
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public DateTime? ExpirationDate { get; set; } = default!;
    public IEnumerable<string> Countries { get; set; } = Enumerable.Empty<string>();
    public IEnumerable<string> Region { get; set; } = Enumerable.Empty<string>();
    public HolidayType Type { get; set; }
}