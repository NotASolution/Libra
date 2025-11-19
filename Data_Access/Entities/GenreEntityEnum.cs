using NpgsqlTypes;

namespace BareEFC_Data_Access.Entities
{
    public enum GenreEntityEnum
    {
        [PgName("Научпоп")]
        NonFiction,
        [PgName ("История")]
        History,
        [PgName("Учебник")]
        Textbook,
        [PgName("Художественная литература")]
        Fiction,
        [PgName("Для детей")]
        ForKids
    }
}