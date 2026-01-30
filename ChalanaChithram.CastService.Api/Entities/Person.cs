namespace ChalanaChithram.CastService.Api.Entities;

public class Person
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? ProfileImageUrl { get; set; }
    public string? InstagramUrl { get; set; }
    public string? TwitterUrl { get; set; }
    public string? FacebookUrl { get; set; }
    public string? YoutubeUrl { get; set; }

    public List<MovieCredit> MovieCredits { get; set; } = new List<MovieCredit>();
}
