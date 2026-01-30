namespace ChalanaChithram.CastService.Api.DTOs;

public class PersonDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? ProfileImageUrl { get; set; }

    public string? InstagramUrl { get; set; }
    public string? TwitterUrl { get; set; }
    public string? FacebookUrl { get; set; }
    public string? YoutubeUrl { get; set; }
}
