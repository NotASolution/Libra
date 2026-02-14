
using Domain;
using Domain.ModelPOCO;
using Npgsql;



namespace ADO_Data_Access
{
    internal static class DataReaderToListConverter
    {
        private delegate List<IDomainPOCO> ListConvertion(NpgsqlDataReader reader);

        private static  Dictionary<TableEnum, ListConvertion> tableToConverter = new Dictionary<TableEnum, ListConvertion>();

        internal static  List<IDomainPOCO> ConvertToList(NpgsqlDataReader reader, TableEnum table)
        {

            return tableToConverter[table](reader);
        }

        static DataReaderToListConverter()
        {
            tableToConverter.Add(TableEnum.Books, ConvertToBooksList);
            tableToConverter.Add(TableEnum.BookTokens, ConvertToBookTokensList);
            tableToConverter.Add(TableEnum.BookLeases, ConvertToBookLeasesList);
            tableToConverter.Add(TableEnum.Members, ConvertToMembersList);
            tableToConverter.Add(TableEnum.ReadingRooms, ConvertToReadingRoomsList);
            tableToConverter.Add(TableEnum.Employees, ConvertToEmployeesList);
        }

        private static List<IDomainPOCO> ConvertToBooksList(NpgsqlDataReader reader)
        {
            List<IDomainPOCO> books = new List<IDomainPOCO>();

            while(reader.Read())
            {
                books.Add(new Book()
                {
                    Cipher = reader["sypher"].ToString(),
                    Title = reader["title"].ToString(),
                    Author = reader["author"].ToString(),
                    Genre = reader.GetFieldValue<GenreEnum>(reader.GetOrdinal("book_genre")),
                    Publisher = reader["publisher"].ToString(),
                    DateOfPublishing = Convert.ToDateTime(reader["date_of_publishing"]),
                    Amount = Convert.ToInt32(reader["amount"])

                });
            }

            return books;
        }

        private static List<IDomainPOCO> ConvertToBookTokensList(NpgsqlDataReader reader)
        {
            List<IDomainPOCO> bookTokens = new List<IDomainPOCO>();
            
            while (reader.Read())
            {
                bookTokens.Add(new BookToken()
                {
                    TokenId = Convert.ToInt32(reader["token_id"]),
                    TokenCipher = reader["sypher"].ToString(),
                    RoomNumber = reader.GetFieldValue<int>(reader.GetOrdinal("room_no")),
                    IsTaken = reader.GetFieldValue<bool>(reader.GetOrdinal("taken"))
                });
            }

            return bookTokens; 
        }

        private static List<IDomainPOCO> ConvertToBookLeasesList(NpgsqlDataReader reader)
        {
            List<IDomainPOCO> bookLeases = new List<IDomainPOCO>();

            while (reader.Read())
            {
                bookLeases.Add(new BookLease()
                {
                    TokenId = reader.GetFieldValue<int>(reader.GetOrdinal("token_id")),
                    LesseeId = reader.GetFieldValue<string>(reader.GetOrdinal("lessee_id")),
                    DateOfInitiation = reader.GetFieldValue<DateTime>(reader.GetOrdinal("date_of_initiation")),
                    DateOfClosure = reader.GetFieldValue<DateTime>(reader.GetOrdinal("date_of_closure")),
                    FactualDateOfClosure = reader.GetFieldValue<DateTime>(reader.GetOrdinal("date_of_closure_fact")),
                    SumOfFine = reader.GetFieldValue<int>(reader.GetOrdinal("sum_of_fine")),
                    ResponsibleEmployee = reader.GetFieldValue<string>(reader.GetOrdinal("responsible_employee_id"))

                });
            }

            return bookLeases;
        }
        private static List<IDomainPOCO> ConvertToMembersList(NpgsqlDataReader reader)
        {
            List<IDomainPOCO> members = new List<IDomainPOCO>();

            while (reader.Read())
            {
                members.Add(new Member() 
                {
                    MemberId = reader["member_id_no"].ToString(),
                    PassportNumber = reader["passport_no"].ToString(),
                    Birthdate = reader.GetFieldValue<DateTime>(reader.GetOrdinal("birth_date")),
                    Address = reader["address"].ToString(),
                    TelephoneNumber = reader["telephone_no"].ToString(),
                    Education = reader["education"].ToString(),
                    ReadingRoomNumber = Convert.ToInt32(reader["reading_room_number"]),
                    Photo = !reader.IsDBNull(reader.GetOrdinal("photo"))
                    ? reader.GetFieldValue<byte[]>(reader.GetOrdinal("photo"))
                    : null,
                    FullName = reader["fullname"].ToString()

                });
            }

            return members;
        }

        private static List<IDomainPOCO> ConvertToReadingRoomsList(NpgsqlDataReader reader)
        {
            List<IDomainPOCO> readingRooms = new List<IDomainPOCO>();

            while (reader.Read())
            {
                readingRooms.Add(new ReadingRoom()
                {
                    RoomNumber = Convert.ToInt32(reader["room_no"]),
                    Capacity = Convert.ToInt32(reader["capacity"]),
                    Name = reader["room_name"].ToString()
                });
            }

            return readingRooms;
        }

        private static List<IDomainPOCO> ConvertToEmployeesList(NpgsqlDataReader reader)
        {
            List<IDomainPOCO> employees = new List<IDomainPOCO>();

            while (reader.Read())
            {
                employees.Add(new Employee()
                {
                    PassportNumber = reader["passport_no"].ToString(),
                    FullName = reader["fullname"].ToString(),
                    TaxpayerId = reader["taxpayer_id"].ToString(),
                    SocialSecurityNumber = reader["social_security_no"].ToString(),
                    EmployeeSex = reader.GetFieldValue<EmployeeSexEnum>(reader.GetOrdinal("employee_sex")),
                    Photo = !reader.IsDBNull(reader.GetOrdinal("photo"))
                    ? reader.GetFieldValue<byte[]>(reader.GetOrdinal("photo"))
                    :null
                });
            }

            return employees;
        }
        
    }
}
