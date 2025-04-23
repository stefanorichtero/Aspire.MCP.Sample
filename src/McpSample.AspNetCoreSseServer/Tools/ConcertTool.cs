using ModelContextProtocol.Server;
using System.ComponentModel;

namespace McpSample.AspNetCoreSseServer;

[McpServerToolType]
public class ConcertTool
{
    [McpServerTool, Description("Returns a list of concerts for a genre and city.")]
    public List<Concert> GetConcerts([Description("The musical genre (e.g. pop, rock, jazz, etc.)")] string genreName,
        [Description("The city where the concerts take place (e.g. Berlin, Paris, etc.)")] string cityName)
    {
        var today = DateTime.Today.AddDays(3);
        var concerts = genreName.ToLower() switch
        {
            "pop" => new List<Concert>
            {
                new() { Title = "The Lumineers", Genre = "Pop", cityName = cityName, Date = today },
                new() { Title = "Jo Halbig - Alle Waren Da Tour 2025", Genre = "Pop", cityName = cityName, Date = today },
                new() { Title = "KARAT 50", Genre = "Pop", cityName = cityName, Date = today },
            },
            "rock" => new List<Concert>
            {
                new() { Title = "Foo Fighters Stadium Show", Genre = "Rock", cityName = cityName, Date = today },
                new() { Title = "Kings of Leon", Genre = "Rock", cityName = cityName, Date = today },
            },
            "metal" => new List<Concert>
            {
                new() { Title = "Iron Maiden Legacy Night", Genre = "Metal", cityName = cityName, Date = today },
                new() { Title = "Slipknot Chaos Tour", Genre = "Metal", cityName = cityName, Date = today },
            },
            "electronic" => new List<Concert>
            {
                new() { Title = "Paul Kalkbrenner Open Air", Genre = "Electronic", cityName = cityName, Date = today },
                new() { Title = "Charlotte de Witte Warehouse Set", Genre = "Electronic", cityName = cityName, Date = today },
            },
            "jazz" => new List<Concert>
            {
                new() { Title = "Jamie Cullum – Late Lounge", Genre = "Jazz", cityName = cityName, Date = today },
                new() { Title = "Snarky Puppy Live", Genre = "Jazz", cityName = cityName, Date = today },
            },
            _ => new List<Concert>
            {
                new() { Title = $"Unknown Genre Showcase: {genreName}", Genre = genreName, cityName = cityName, Date = today }
            }
        };

        Console.WriteLine($"Returning {concerts.Count} concert(s) for {genreName} in {cityName} on {today:d}");
        return concerts;
    }
}

// Return type
public class Concert
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public string cityName { get; set; }
    public DateTime Date { get; set; }
}