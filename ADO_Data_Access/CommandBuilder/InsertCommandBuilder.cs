using ADO_Data_Access.Enumerations;
using Domain.ModelPOCO;
using Npgsql;
using System.Runtime.CompilerServices;
using System.Text;

namespace ADO_Data_Access.CommandBuilder
{
    public class InsertCommandBuilder
    {
        private delegate NpgsqlCommand BuildCommand(List<IDomainPOCO> domainObjects);
        private TableEnum SelectedTable { get; set; }
        private NpgsqlDataSource Source { get; set; }


        private Dictionary<TableEnum, BuildCommand> objectsProcessing = new Dictionary<TableEnum, BuildCommand>();
        private Dictionary<TableEnum, string> tableColumns = new Dictionary<TableEnum, string>()
        {
            { TableEnum.Books, "Books (sypher, title, author, book_genre, publisher, date_of_publishing, amount) VALUES"},
            { TableEnum.BookTokens, "Book_Tokens (token_id, sypher, room_no, taken) VALUES"},
            { TableEnum.BookLeases, "Book_Lease (token_id, lessee_id, date_of_initiation, date_of_closure, date_of_closure_fact, sum_of_fine, responsible_employee_id) VALUES"},
            { TableEnum.Members, "Members (member_id_no, passport_no, birth_date, address, telephone_no, education, reading_room_number, photo, fullname) VALUES"},
            { TableEnum.ReadingRooms, "Reading_Rooms (room_no, room_name, capacity) VALUES"},
            { TableEnum.Employees, "Employees (passport_no, fullname, taxpayer_id, social_security_no, employee_sex, photo) VALUES"}
        };

        private Dictionary<TableEnum, Type> tableTypeConsistence = new Dictionary<TableEnum, Type>()
        {
            { TableEnum.Books, typeof(Book)},
            { TableEnum.BookTokens, typeof(BookToken)},
            { TableEnum.BookLeases, typeof(BookLease)},
            { TableEnum.Members, typeof(Member)},
            { TableEnum.ReadingRooms, typeof(ReadingRoom)},
            { TableEnum.Employees, typeof(Employee)}
        };


        public InsertCommandBuilder()
        {
            objectsProcessing.Add(TableEnum.ReadingRooms, BuildReadingRoomsInsertionCommand);
            objectsProcessing.Add(TableEnum.Books, BuildBooksInsertionCommand);
        }

        public InsertCommandBuilder SetDataSource(NpgsqlDataSource source)
        {
            Source = source;
            return this;
        }
        
        public InsertCommandBuilder SetTable(TableEnum table)
        {
            SelectedTable = table;
            return this;
        }

        public NpgsqlCommand BuildInsertionCommand(List<IDomainPOCO> domainObjects)
        {
            CheckTypeConsistency(domainObjects);
            return objectsProcessing[SelectedTable](domainObjects);
        }

        
        private NpgsqlCommand BuildReadingRoomsInsertionCommand(List<IDomainPOCO> domainObjects)
        {
            List<ReadingRoom> rooms = domainObjects.Cast<ReadingRoom>().ToList();
            StringBuilder stringBuilder = new StringBuilder($"INSERT INTO {tableColumns[SelectedTable]} ");

            var command = Source.CreateCommand();

            int roomNumber = 1;
            int roomName = 2;
            int roomCapacity = 3;

            foreach(var room in rooms)
            {
                stringBuilder.Append($"(${roomNumber}, ${roomName}, ${roomCapacity})");
                if (rooms.Last() == room) stringBuilder.Append("; "); else stringBuilder.Append(",\n");

                command.Parameters.Add(new NpgsqlParameter() { Value = room.RoomNumber });
                command.Parameters.Add(new NpgsqlParameter() { Value = room.Name });
                command.Parameters.Add(new NpgsqlParameter() { Value = room.Capacity });

                roomNumber++;
                roomName++;
                roomCapacity++;
            }

            command.CommandText = stringBuilder.ToString();

            return command;
        }

        private NpgsqlCommand BuildBooksInsertionCommand(List<IDomainPOCO> domainObject)
        {
            List<Book> books = domainObject.Cast<Book>().ToList();
            StringBuilder stringBuilder = new StringBuilder($"INSERT INTO {tableColumns[SelectedTable]} ");

            var command = Source.CreateCommand();

            int bookCipher = 1;
            int bookTitle = 2;
            int bookAuthor = 3;
            int bookGenre = 4;
            int bookPublisher = 5;
            int bookDateOfPublishing = 6;
            int bookAmount = 7;

            foreach(var book in books)
            {
                stringBuilder.Append($"(${bookCipher}, ${bookTitle}, ${bookAuthor}, ${bookGenre}, ${bookPublisher}, ${bookDateOfPublishing}, ${bookAmount})");
                if (books.Last() == book) stringBuilder.Append("; "); else stringBuilder.Append(",\n");

                command.Parameters.Add(new NpgsqlParameter() { Value = book.Cipher});
                command.Parameters.Add(new NpgsqlParameter() { Value = book.Title});
                command.Parameters.Add(new NpgsqlParameter() { Value = book.Author});
                command.Parameters.Add(new NpgsqlParameter() { Value = book.Genre});
                command.Parameters.Add(new NpgsqlParameter() { Value = book.Publisher});
                command.Parameters.Add(new NpgsqlParameter() { Value = book.DateOfPublishing});
                command.Parameters.Add(new NpgsqlParameter() { Value = book.Amount});

                bookCipher++;
                bookTitle++;
                bookAuthor++;
                bookGenre++;
                bookPublisher++;
                bookDateOfPublishing++;
                bookAmount++;   
            }

            command.CommandText = stringBuilder.ToString();

            return command;
        }

        private NpgsqlCommand BuildBookTokensCommand(List<IDomainPOCO> domainObject)
        {
            List<BookToken> tokens = domainObject.Cast<BookToken>().ToList();
            StringBuilder stringBuilder = new StringBuilder($"INSERT INTO {tableColumns[SelectedTable]} ");

            var command = Source.CreateCommand();

            int tokenId = 1;
            int tokenCipher = 2;
            int tokenRoomNumber = 3;
            int tokenIsTakenStatus = 4;

            foreach(var token in tokens)
            {

            }

            return command;
        }


        private bool CheckTypeConsistency(List<IDomainPOCO> domainObjects)
        {
            return domainObjects.Any(domainObject => domainObject.GetType() != tableTypeConsistence[SelectedTable]);
        }
    }
}