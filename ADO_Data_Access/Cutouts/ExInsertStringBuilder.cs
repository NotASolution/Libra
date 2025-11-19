using ADO_Data_Access.Enumerations;
using Domain.ModelPOCO;
using System.Text;

public class InsertStringBuilder
{
    private delegate string GetValueString(List<IDomainPOCO> domainPocos);

    private string valuesString;

    private TableEnum TargetTable;

    private Dictionary<TableEnum, string> tableDictionary = new Dictionary<TableEnum, string>()
        {
            { TableEnum.Books, "Books (sypher, title, author, book_genre, publisher, date_of_publishing, amount)\n"},
            { TableEnum.BookLeases, "Book_Tokens (token_id, sypher, room_no, taken)\n"},
            { TableEnum.BookTokens, "Book_Lease (token_id, lessee_id, date_of_initiation, date_of_closure, date_of_closure_fact, sum_of_fine, responsible_employee)\n"},
            { TableEnum.Members, "Members (member_id_no, passport_no, birth_date, address, telephone_no, education, reading_room_number, photo, fullname)\n"},
            { TableEnum.ReadingRooms, "Reading_Rooms (room_no, room_name, capacity)\n"},
            { TableEnum.Employees, "Employees (passport_no, fullname, taxpayer_id, social_security_no, employee_sex, photo)\n"}
        };

    private Dictionary<TableEnum, Type> tableToType = new Dictionary<TableEnum, Type>()
        {
            { TableEnum.Books, typeof(Book)},
            { TableEnum.BookTokens, typeof(BookToken)},
            { TableEnum.BookLeases, typeof(BookLease)},
            { TableEnum.Members, typeof(Member)},
            { TableEnum.ReadingRooms, typeof(ReadingRoom)},
            { TableEnum.Employees, typeof(Employee)}
        };

    private Dictionary<Type, GetValueString> typeToValuesString = new Dictionary<Type, GetValueString>();

    public InsertStringBuilder()
    {
        typeToValuesString.Add(typeof(Book), GetBookValuesString);
        typeToValuesString.Add(typeof(BookToken), GetBookTokenValuesString);
        typeToValuesString.Add(typeof(BookLease), GetBookLeaseValuesString);
        typeToValuesString.Add(typeof(Member), GetMemberValuesString);
        typeToValuesString.Add(typeof(ReadingRoom), GetReadingRoomValuesString);
        typeToValuesString.Add(typeof(Employee), GetEmployeeValuesString);
    }

    public InsertStringBuilder SetTargetTable(TableEnum targetTable)
    {
        TargetTable = targetTable;
        return this;
    }

    public InsertStringBuilder AssertValues(List<IDomainPOCO> domainPocosToAdd)
    {
        if (TargetTable == null) throw new Exception("Target table is not asserted");
        if (!TableValuesTypeMatch(domainPocosToAdd)) throw new Exception("Target table does not support some or all values from given list");

        valuesString = typeToValuesString[tableToType[TargetTable]](domainPocosToAdd);

        return this;
    }

    private string GetBookValuesString(List<IDomainPOCO> bookValuesToAdd)
    {
        var books = bookValuesToAdd.Cast<Book>().ToList();

        StringBuilder valuesAssembler = new StringBuilder();

        for (int i = 0; i < books.Capacity; i++)
        {
            valuesAssembler.Append($"\t({books[i].Cipher}, {books[i].Title}, {books[i].Author}, ${i + 1}, {books[i].Publisher}, {books[i].DateOfPublishing}, {books[i].Amount})");
            if (i + 1 != books.Count) valuesAssembler.Append(",");
            valuesAssembler.Append("\n");
        }
        return valuesAssembler.ToString();
    }

    private string GetBookTokenValuesString(List<IDomainPOCO> bookTokenValuesToAdd)
    {
        List<BookToken> bookTokens = (List<BookToken>)bookTokenValuesToAdd.Cast<BookToken>();
        StringBuilder valuesAssembler = new StringBuilder();

        foreach (var bookToken in bookTokens)
        {
            valuesAssembler.Append($"\t({bookToken.TokenId}, {bookToken.TokenCipher}, {bookToken.RoomNumber})");
            if (bookTokenValuesToAdd.Last() != bookToken) valuesAssembler.Append(",");
            valuesAssembler.Append("\n");
        }

        return valuesAssembler.ToString();
    }
    private string GetBookLeaseValuesString(List<IDomainPOCO> bookLeaseValuesToAdd)
    {
        List<BookLease> bookLeases = (List<BookLease>)bookLeaseValuesToAdd.Cast<BookLease>();
        StringBuilder valuesAssembler = new StringBuilder();

        foreach (var bookLease in bookLeases)
        {
            valuesAssembler.Append($"\t({bookLease.TokenId}, {bookLease.LesseeId}, {bookLease.DateOfInitiation}, {bookLease.DateOfClosure}, {bookLease.FactualDateOfClosure}" +
                                   $"{bookLease.SumOfFine}, {bookLease.ResponsibleEmployee})");
            if (bookLeaseValuesToAdd.Last() != bookLease) valuesAssembler.Append(",");
            valuesAssembler.Append("\n");
        }
        return valuesAssembler.ToString();
    }
    private string GetReadingRoomValuesString(List<IDomainPOCO> readingRoomValuesToAdd)
    {
        List<ReadingRoom> readingRooms = (List<ReadingRoom>)readingRoomValuesToAdd.Cast<ReadingRoom>();
        StringBuilder valuesAssembler = new StringBuilder();

        foreach (var readingRoom in readingRooms)
        {
            valuesAssembler.Append($"\t({readingRoom.RoomNumber}, {readingRoom.Name}, {readingRoom.Capacity})");
            if (readingRoomValuesToAdd.Last() != readingRoom) valuesAssembler.Append(",");
            valuesAssembler.Append("\n");
        }

        return valuesAssembler.ToString();
    }
    private string GetMemberValuesString(List<IDomainPOCO> memberValuesToAdd)
    {
        List<Member> members = (List<Member>)memberValuesToAdd.Cast<Member>();
        StringBuilder valuesAssembler = new StringBuilder();

        foreach (var member in members)
        {
            valuesAssembler.Append($"\t({member.MemberId}, {member.PassportNumber}, {member.Birthdate}, {member.Address}, {member.TelephoneNumber}, {member.Education}" +
                                   $"{member.ReadingRoomNumber}, {member.Photo}, {member.FullName})");
            if (memberValuesToAdd.Last() != member) valuesAssembler.Append(",");
            valuesAssembler.Append("\n");
        }

        return valuesAssembler.ToString();
    }
    private string GetEmployeeValuesString(List<IDomainPOCO> employeeValuesToAdd)
    {
        List<Employee> employees = (List<Employee>)employeeValuesToAdd.Cast<Employee>();
        StringBuilder valuesAssembler = new StringBuilder();

        for (int i = 0; i < employees.Count; i++)
        {
            valuesAssembler.Append($"({employees[i].PassportNumber}, {employees[i].FullName}, {employees[i].TaxpayerId}, {employees[i].SocialSecurityNumber}, ${i + 1}, {employees[i].Photo}),");
            if (i + 1 < employees.Count) valuesAssembler.Append(",");
            valuesAssembler.Append("\n");

        }
        return valuesAssembler.ToString();
    }
    private bool TableValuesTypeMatch(List<IDomainPOCO> domainPocos)
    {
        return domainPocos.Where(poco => poco.GetType() != tableToType[TargetTable]).FirstOrDefault() == null;
    }
    public string Build()
    {
        return $"INSERT INTO {tableDictionary[TargetTable]} VALUES{valuesString};";
    }


}