
using Domain.ModelPOCO;

namespace Domain
{
    public static class Mapping
    {
        public static Dictionary<TableEnum, Type> tableToType = new Dictionary<TableEnum, Type>()
        {
            { TableEnum.Books, typeof(Book)},
            { TableEnum.BookTokens, typeof(BookToken)},
            { TableEnum.BookLeases, typeof(BookLease)},
            { TableEnum.Members, typeof(Member)},
            { TableEnum.ReadingRooms, typeof(ReadingRoom)},
            { TableEnum.Employees, typeof(Employee)}
        };

        public static Dictionary<Type, TableEnum> typeToTable = new Dictionary<Type, TableEnum>()
        {
            {typeof(Book), TableEnum.Books},
            {typeof(BookToken), TableEnum.BookTokens},
            {typeof(BookLease), TableEnum.BookLeases},
            {typeof(Member), TableEnum.Members},
            {typeof(ReadingRoom), TableEnum.ReadingRooms},
            {typeof(Employee), TableEnum.Employees},
        };

        public static Dictionary<TableEnum, string> tableToStringName = new Dictionary<TableEnum, string>()
        {
            { TableEnum.Books, "Books"},
            { TableEnum.BookTokens, "Book_Tokens"},
            { TableEnum.BookLeases, "Book_Lease"},
            { TableEnum.Members, "Members"},
            { TableEnum.ReadingRooms, "Reading_Room"},
            { TableEnum.Employees, "Employees"}
        };

        public static Dictionary<TableEnum, string> tableToPrimaryKeyColumnName = new Dictionary<TableEnum, string>()
        {
            { TableEnum.Books, "sypher"},
            { TableEnum.BookTokens, "token_id"},
            { TableEnum.BookLeases, "token_id"},
            { TableEnum.Members, "member_id_no"},
            { TableEnum.ReadingRooms, "room_no"},
            { TableEnum.Employees, "passport_no"}
        };

    }
}
