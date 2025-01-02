namespace Flights.Infrastructure.Persistence;

public class PersistenceOptions
{
    public const string SectionName = "Persistence";
    public string ConnectionString { get; set; }
}
