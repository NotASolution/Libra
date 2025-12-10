using ADO_Data_Access.Enumerations;
using Domain.ModelPOCO;
using Domain;
using Npgsql;
using System.Text;


namespace ADO_Data_Access.CommandBuilder
{
    public class InsertCommandBuilder
    {
        private delegate NpgsqlCommand BuildCommand(List<IDomainPOCO> domainObjects);
        private string Schema = "\"SoleSchema\"";
        private TableEnum SelectedTable { get; set; }
        private NpgsqlDataSource Source { get; set; }


        private Dictionary<TableEnum, BuildCommand> objectsProcessing = new Dictionary<TableEnum, BuildCommand>();
        private Dictionary<TableEnum, string> tableColumns = new Dictionary<TableEnum, string>()
        {
            { TableEnum.Books, $"\"SoleSchema\".\"Books\" (sypher, title, author, book_genre, publisher, date_of_publishing, amount) VALUES"},
            { TableEnum.BookTokens, $"\"SoleSchema\".\"Book_Tokens\" (token_id, sypher, room_no, taken) VALUES"},
            { TableEnum.BookLeases, $"\"SoleSchema\".\"Book_Lease\" (token_id, lessee_id, date_of_initiation, date_of_closure, date_of_closure_fact, sum_of_fine, responsible_employee_id) VALUES"},
            { TableEnum.Members, $"\"SoleSchema\".\"Members\" (member_id_no, passport_no, birth_date, address, telephone_no, education, reading_room_number, photo, fullname) VALUES"},
            { TableEnum.ReadingRooms, $"\"SoleSchema\".\"Reading_Room\" (room_no, room_name, capacity) VALUES"},
            { TableEnum.Employees, $"\"SoleSchema\".\"Employees\" (passport_no, fullname, taxpayer_id, social_security_no, employee_sex, photo) VALUES"}
        };


        public InsertCommandBuilder()
        {
            objectsProcessing.Add(TableEnum.ReadingRooms, BuildReadingRoomsInsertionCommand);
            objectsProcessing.Add(TableEnum.Books, BuildBooksInsertionCommand);
            objectsProcessing.Add(TableEnum.BookTokens, BuildBookTokensInsertionCommand);
            objectsProcessing.Add(TableEnum.BookLeases, BuildBookLeasesInsertionCommand);
            objectsProcessing.Add(TableEnum.Members, BuildMemberInsertionCommand);
            objectsProcessing.Add(TableEnum.Employees, BuildEmployeeInsertionCommand);
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

        private NpgsqlCommand BuildBooksInsertionCommand(List<IDomainPOCO> domainObjects)
        {
            List<Book> books = domainObjects.Cast<Book>().ToList();
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

        private NpgsqlCommand BuildBookLeasesInsertionCommand(List<IDomainPOCO> domainObjects) 
        {
            List<BookLease> leases = domainObjects.Cast<BookLease>().ToList();
            StringBuilder stringBuilder = new StringBuilder($"INSERT INTO {tableColumns[SelectedTable]} ");

            var command = Source.CreateCommand();

            int blTokenId = 1;
            int blLesseeId = 2;
            int blDateOfInitiation = 3;
            int blDateOfClosure = 4;
            int blFactualDateOfClosure = 5;
            int blSumOfFine = 6;
            int blResponsibleEmployeeId = 7;

            foreach(var lease in leases)
            {
                stringBuilder.Append($"(${blTokenId}, ${blLesseeId}, ${blDateOfInitiation}, ${blFactualDateOfClosure}, ${blFactualDateOfClosure}, ${blSumOfFine}, ${blResponsibleEmployeeId})");
                if (leases.Last() == lease) stringBuilder.Append("; "); else stringBuilder.Append(",\n");


                command.Parameters.Add(new NpgsqlParameter() { Value = lease.TokenId});
                command.Parameters.Add(new NpgsqlParameter() { Value = lease.LesseeId});
                command.Parameters.Add(new NpgsqlParameter() { Value = lease.DateOfInitiation});
                command.Parameters.Add(new NpgsqlParameter() { Value = lease.DateOfClosure});
                command.Parameters.Add(new NpgsqlParameter() { Value = lease.FactualDateOfClosure});
                command.Parameters.Add(new NpgsqlParameter() { Value = lease.SumOfFine});
                command.Parameters.Add(new NpgsqlParameter() { Value = lease.ResponsibleEmployee});

                blTokenId++;
                blLesseeId++;
                blDateOfInitiation++;
                blDateOfClosure++;
                blFactualDateOfClosure++;
                blSumOfFine++;
                blResponsibleEmployeeId++;
            }

            return command;
        }
        private NpgsqlCommand BuildBookTokensInsertionCommand(List<IDomainPOCO> domainObject)
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
                stringBuilder.Append($"(${tokenId}, ${tokenCipher}, ${tokenRoomNumber}, ${tokenIsTakenStatus})");
                if (tokens.Last() == token) stringBuilder.Append("; "); else stringBuilder.Append(",\n");

                command.Parameters.Add(new NpgsqlParameter() { Value = token.TokenId});
                command.Parameters.Add(new NpgsqlParameter() { Value = token.TokenCipher});
                command.Parameters.Add(new NpgsqlParameter() { Value = token.RoomNumber});
                command.Parameters.Add(new NpgsqlParameter() { Value = token.IsTaken});

                tokenId++;
                tokenCipher++;
                tokenRoomNumber++;
                tokenIsTakenStatus++;
            }

            return command;
        }

        private NpgsqlCommand BuildMemberInsertionCommand(List<IDomainPOCO> domainObject)
        {
            List<Member> members = domainObject.Cast<Member>().ToList();
            StringBuilder stringBuilder = new StringBuilder($"INSERT INTO {tableColumns[SelectedTable]} ");

            var command = Source.CreateCommand();

            int memberIdNumber = 1;
            int memberPassportNumber = 2;
            int memberBirthDate = 3;
            int memberAddress = 4;
            int memberTelNumber = 5;
            int memberEducation = 6;
            int memberRoomNumber = 7;
            int memberPhoto = 8;
            int memberFullname = 9;

            foreach(var member in members)
            {
                stringBuilder.Append($"(${memberIdNumber}, ${memberPassportNumber}, ${memberBirthDate}, ${memberAddress}, ${memberTelNumber}," +
                                     $"${memberEducation}, ${memberRoomNumber}, ${memberPhoto}, ${memberFullname})");
                if (members.Last() == member) stringBuilder.Append("; "); else stringBuilder.Append(",\n");

                command.Parameters.Add(new NpgsqlParameter() { Value = member.MemberId});
                command.Parameters.Add(new NpgsqlParameter() { Value = member.PassportNumber});
                command.Parameters.Add(new NpgsqlParameter() { Value = member.Birthdate});
                command.Parameters.Add(new NpgsqlParameter() { Value = member.Address});
                command.Parameters.Add(new NpgsqlParameter() { Value = member.TelephoneNumber});
                command.Parameters.Add(new NpgsqlParameter() { Value = member.Education});
                command.Parameters.Add(new NpgsqlParameter() { Value = member.ReadingRoomNumber});
                command.Parameters.Add(new NpgsqlParameter() { Value = member.Photo});
                command.Parameters.Add(new NpgsqlParameter() { Value = member.FullName});

                memberIdNumber++; memberPassportNumber++; memberBirthDate++; memberAddress++;
                memberTelNumber++; memberEducation++; memberRoomNumber++; memberPhoto++; memberFullname++;

            }

            return command;
        }

        private NpgsqlCommand BuildEmployeeInsertionCommand(List<IDomainPOCO> domainObject)
        {
            List<Employee> employees = domainObject.Cast<Employee>().ToList();
            StringBuilder stringBuilder = new StringBuilder($"INSERT INTO {tableColumns[SelectedTable]}");

            var command = Source.CreateCommand();

            int employeePassportNumber = 1;
            int employeeFullName = 2;
            int employeeTaxpayerId = 3;
            int employeeSocialSecNo = 4;
            int employeeEmployeeSex = 5;
            int employeePhoto = 6; 

            foreach(var employee in employees)
            {
                stringBuilder.Append($"(${employeePassportNumber}, ${employeeFullName}, ${employeeTaxpayerId}, ${employeeSocialSecNo}, ${employeeEmployeeSex}, ${employeePhoto})");
                if (employees.Last() == employee) stringBuilder.Append("; "); else stringBuilder.Append(",\n");

                command.Parameters.Add(new NpgsqlParameter() { Value = employee.PassportNumber});
                command.Parameters.Add(new NpgsqlParameter() { Value = employee.FullName});
                command.Parameters.Add(new NpgsqlParameter() { Value = employee.TaxpayerId});
                command.Parameters.Add(new NpgsqlParameter() { Value = employee.SocialSecurityNumber});
                command.Parameters.Add(new NpgsqlParameter() { Value = employee.EmployeeSex});
                command.Parameters.Add(new NpgsqlParameter() { Value = employee.Photo});

                employeePassportNumber++;
                employeeFullName++;
                employeeTaxpayerId++;
                employeeSocialSecNo++;
                employeeEmployeeSex++;
                employeePhoto++;
            }
            return command;
        }

        private bool CheckTypeConsistency(List<IDomainPOCO> domainObjects)
        {
            return domainObjects.Any(domainObject => domainObject.GetType() != Mapping.tableToType[SelectedTable]);
        }
    }
}