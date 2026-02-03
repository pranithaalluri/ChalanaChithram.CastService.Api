namespace ChalanaChithram.CastService.Api.Dtos;

public class PersonDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public byte[] ProfileImage { get; set; } = Array.Empty<byte>();

    public string? InstagramUrl { get; set; }
    public string? TwitterUrl { get; set; }
    public string? FacebookUrl { get; set; }
    public string? YoutubeUrl { get; set; }
}
