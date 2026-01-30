using ChalanaChithram.CastService.Api.Entities;

namespace ChalanaChithram.CastService.Api.Seed;

public static class CastSeedData
{
    // Movie IDs should match MovieService movie IDs
    public const int Movie1Id = 1;
    public const int Movie2Id = 2;

    public static List<Person> GetPeople()
    {
        return new List<Person>
        {
            new Person
            {
                Id = 1,
                Name = "Mahesh Babu",
                ProfileImageUrl = null,
                InstagramUrl = "https://www.instagram.com/urstrulymahesh/",
                TwitterUrl = null,
                FacebookUrl = null,
                YoutubeUrl = null
            },
            new Person
            {
                Id = 2,
                Name = "S. S. Rajamouli",
                ProfileImageUrl = null,
                InstagramUrl = "https://www.instagram.com/ssrajamouli/",
                TwitterUrl = "https://x.com/ssrajamouli",
                FacebookUrl = null,
                YoutubeUrl = null
            },
            new Person
            {
                Id = 3,
                Name = "Anirudh Ravichander",
                ProfileImageUrl = null,
                InstagramUrl = "https://www.instagram.com/anirudhofficial/",
                TwitterUrl = null,
                FacebookUrl = null,
                YoutubeUrl = "https://www.youtube.com/@anirudhofficial"
            },
            new Person
            {
                Id = 4,
                Name = "Samantha Ruth Prabhu",
                ProfileImageUrl = null,
                InstagramUrl = "https://www.instagram.com/samantharuthprabhuoffl/",
                TwitterUrl = null,
                FacebookUrl = null,
                YoutubeUrl = null
            },
            new Person
            {
                Id = 5,
                Name = "Prabhas",
                ProfileImageUrl = null,
                InstagramUrl = null,
                TwitterUrl = null,
                FacebookUrl = null,
                YoutubeUrl = null
            }
        };
    }

    public static List<MovieCredit> GetMovieCredits()
    {
        return new List<MovieCredit>
        {
            // Movie 1
            new MovieCredit
            {
                Id = 1,
                MovieId = Movie1Id,
                PersonId = 2,
                Role = "Director",
                CharacterName = null,
                Order = 1
            },
            new MovieCredit
            {
                Id = 2,
                MovieId = Movie1Id,
                PersonId = 1,
                Role = "Actor",
                CharacterName = "Hero",
                Order = 2
            },
            new MovieCredit
            {
                Id = 3,
                MovieId = Movie1Id,
                PersonId = 4,
                Role = "Actor",
                CharacterName = "Heroine",
                Order = 3
            },

            // Movie 2
            new MovieCredit
            {
                Id = 4,
                MovieId = Movie2Id,
                PersonId = 2,
                Role = "Director",
                CharacterName = null,
                Order = 1
            },
            new MovieCredit
            {
                Id = 5,
                MovieId = Movie2Id,
                PersonId = 5,
                Role = "Actor",
                CharacterName = "Lead Warrior",
                Order = 2
            }
        };
    }
}
