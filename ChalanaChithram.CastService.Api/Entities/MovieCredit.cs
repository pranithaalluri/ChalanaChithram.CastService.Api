namespace ChalanaChithram.CastService.Api.Entities;

public class MovieCredit
{
    public int Id { get; set; }

    public int MovieId { get; set; }

    public int PersonId { get; set; }

    public string Role { get; set; } = string.Empty;

    public string? CharacterName { get; set; }

    public int Order { get; set; }

    public Person? Person { get; set; }
}
