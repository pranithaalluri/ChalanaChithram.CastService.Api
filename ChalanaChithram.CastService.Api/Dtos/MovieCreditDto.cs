namespace ChalanaChithram.CastService.Api.Dtos;

public class MovieCreditDto
{
    public int Id { get; set; }

    public int MovieId { get; set; }

    public int PersonId { get; set; }

    public string Role { get; set; } = string.Empty;

    public string? CharacterName { get; set; }

    public int Order { get; set; }

    public PersonDto? Person { get; set; }
}
