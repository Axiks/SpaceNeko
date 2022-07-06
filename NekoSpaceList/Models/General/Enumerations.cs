namespace NekoSpaceList.Models.General
{
    public enum Languages
    {
        UK, PL, EN, JA
    }

    public enum AnimeType
    {
        EveryType,
        TV,
        OVA,
        Movie,
        Special,
        ONA,
        Music
    }

    public enum AiringStatus
    {
        FinishedAiring,
        CurrentlyAiring,
        NotYetAired
    }

    public enum AgeRating
    {
        g,
        pg,
        pg13,
        r17,
        r,
        rx
    }

    public enum Source
    {
        Other,
        Original,
        Manga,
        ForKomaManga,
        WebManga,
        DigitalManga,
        Novel,
        LightNovel,
        VisualNovel,
        Game,
        CardGame,
        Book,
        PictureBook,
        Radio,
        Music
    }

    public enum Sezon
    {
        Winter,
        Spring,
        Summer,
        Autumn
    }

    public enum ItemFrom
    {
        System,
        User,
        ExternalSource
    }

    public enum MangaType
    {
        EveryType,
        Manga,
        Novel,
        OneShot,
        Doujinshi,
        Manhwa,
        Manhua
    }

    public enum MangaStatus
    {
        EveryStatus,
        Reding,
        Completed,
        Upcoming
    }
}
