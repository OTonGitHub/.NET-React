namespace Domain;

#nullable disable
// in the course, asked to disable in .csproj, it's a new feature.

public class Activity
{
    [System.ComponentModel.DataAnnotations.Key] // not really required, as using convention "Id"
    public Guid Id { get; set; } // By Convention for PK (EF)
    public string Title { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string City { get; set; }
    public string Venue { get; set; }
}
