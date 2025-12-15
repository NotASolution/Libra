
using Domain;
using Domain.ModelPOCO;
using Npgsql;
using System.Text;

namespace ADO_Data_Access.CommandBuilder
{
    internal class UpdateCommandBuilder
    {
        private NpgsqlDataSource Source;

        private Dictionary<TableEnum, Func<NpgsqlCommand>> tableToBuilder = new Dictionary<TableEnum, Func<NpgsqlCommand>>();
        private IDomainPOCO TargetDomainObject { get; set; }

        private IDomainPOCO UpdatedDomainObject { get; set; }

        public UpdateCommandBuilder()
        {
            tableToBuilder.Add(TableEnum.Books, BuildBooksUpdateCommand);
            tableToBuilder.Add(TableEnum.BookTokens, BuildBookTokensUpdateCommand);
            tableToBuilder.Add(TableEnum.BookLeases, BuildBookLeasesUpdateCommand);
            tableToBuilder.Add(TableEnum.Members, BuildMembersUpdateCommand);
            tableToBuilder.Add(TableEnum.ReadingRooms, BuildReadingRoomsUpdateCommand);
            tableToBuilder.Add(TableEnum.Employees, BuildEmployeesUpdateCommand);
        }
        public UpdateCommandBuilder SetDataSource(NpgsqlDataSource dataSource)
        {
            Source = dataSource;
            return this;
        }

        public UpdateCommandBuilder SetTargetDomainObject(IDomainPOCO targetDomainObject)
        {
            TargetDomainObject = targetDomainObject;
            return this;
        }

        public UpdateCommandBuilder SetUpdatedDomainObject(IDomainPOCO updatedDomainObject)
        {
            UpdatedDomainObject = updatedDomainObject;
            return this;
        }
        public NpgsqlCommand BuildBooksUpdateCommand()
        {
            var commandString = new StringBuilder($"UPDATE \"SoleSchema\".\"{Mapping.tableToStringName[Mapping.typeToTable[TargetDomainObject.GetType()]]}\" SET\n" +
                                                  "sypher = @cipher,\n" +
                                                  "title = @title,\n" +
                                                  "author = @author,\n" +
                                                  "book_genre = @genre,\n" +
                                                  "publisher = @publisher,\n" +
                                                  "date_of_publishing = @dateOfPublishing,\n" +
                                                  "amount = @amount\n" +
                                                  "WHERE sypher = @targetCipher");
            var command = Source.CreateCommand(commandString.ToString());

            command.Parameters.AddWithValue("cipher", (UpdatedDomainObject as Book).Cipher);
            command.Parameters.AddWithValue("title", (UpdatedDomainObject as Book).Title);
            command.Parameters.AddWithValue("author", (UpdatedDomainObject as Book).Author);
            command.Parameters.AddWithValue("genre", (UpdatedDomainObject as Book).Genre);
            command.Parameters.AddWithValue("publisher", (UpdatedDomainObject as Book).Publisher);
            command.Parameters.AddWithValue("dateOfPublishing", (UpdatedDomainObject as Book).DateOfPublishing);
            command.Parameters.AddWithValue("amount", (UpdatedDomainObject as Book).Amount);
            command.Parameters.AddWithValue("targetCipher", (TargetDomainObject as Book).Cipher);

            return command;
        }

        public NpgsqlCommand BuildBookTokensUpdateCommand()
        {
            var commandString = new StringBuilder($"UPDATE \"SoleSchema\".\"{Mapping.tableToStringName[Mapping.typeToTable[TargetDomainObject.GetType()]]}\" SET\n" +
                                                  "token_id = @tokenId,\n" +
                                                  "sypher = @tokenCipher,\n" +
                                                  "room_no = @tokenRoomNumber,\n" +
                                                  "taken = @isTakenStatus,\n" +
                                                  "WHERE token_id = @targetTokenId");

            var command = Source.CreateCommand(commandString.ToString());

            command.Parameters.AddWithValue("tokenId", (UpdatedDomainObject as BookToken).TokenId);
            command.Parameters.AddWithValue("tokenCipher", (UpdatedDomainObject as BookToken).TokenCipher);
            command.Parameters.AddWithValue("tokenRoomNumber", (UpdatedDomainObject as BookToken).RoomNumber);
            command.Parameters.AddWithValue("isTakenStatus", (UpdatedDomainObject as BookToken).IsTaken);

            return command;
        }
        public NpgsqlCommand BuildBookLeasesUpdateCommand()
        {
            var commandString = new StringBuilder($"UPDATE \"SoleSchema\".\"{Mapping.tableToStringName[Mapping.typeToTable[TargetDomainObject.GetType()]]}\" SET\n" +
                                                  "token_id = @tokenId,\n" +
                                                  "lessee_id = @lesseeId,\n" +
                                                  "date_of_initiation = @dateOfInitiation,\n" +
                                                  "date_of_closure = @dateOfClosure,\n" +
                                                  "date_of_closure_fact = @factualDateOfClosure,\n" +
                                                  "sum_of_fine = @sumOfFine,\n" +
                                                  "responsible_employee_id = @responsibleEmployeeId\n" +
                                                  "WHERE token_id = @targetTokenId");

            var command = Source.CreateCommand(commandString.ToString());

            command.Parameters.AddWithValue("tokenId", (UpdatedDomainObject as BookLease).TokenId);
            command.Parameters.AddWithValue("lesseeId", (UpdatedDomainObject as BookLease).LesseeId);
            command.Parameters.AddWithValue("dateOfInitiation", (UpdatedDomainObject as BookLease).DateOfInitiation);
            command.Parameters.AddWithValue("DateOfClosure", (UpdatedDomainObject as BookLease).DateOfClosure);
            command.Parameters.AddWithValue("factualDateOfClosure", (UpdatedDomainObject as BookLease).FactualDateOfClosure);
            command.Parameters.AddWithValue("sumOfFine", (UpdatedDomainObject as BookLease).SumOfFine);
            command.Parameters.AddWithValue("responsibleEmployeeId", (UpdatedDomainObject as BookLease).ResponsibleEmployee);
            command.Parameters.AddWithValue("targetTokenId", (TargetDomainObject as BookLease).TokenId);

            return command;
        }

        public NpgsqlCommand BuildMembersUpdateCommand()
        {
            var commandString = new StringBuilder($"UPDATE \"SoleSchema\".\"{Mapping.tableToStringName[Mapping.typeToTable[TargetDomainObject.GetType()]]}\" SET\n" +
                                                  "member_id_no = @memberId,\n" +
                                                  "passport_no = @passportNumber,\n" +
                                                  "birth_date = @birthDate,\n" +
                                                  "address = @address,\n" +
                                                  "telephone_no = @telephoneNumber,\n" +
                                                  "education = @education,\n" +
                                                  "reading_room_number = @readingRoomNumber\n" +
                                                  "photo = @photo,\n" +
                                                  "fullname = @fullname\n" +
                                                  "WHERE member_id_no = @targetMemberId");

            var command = Source.CreateCommand(commandString.ToString());

            command.Parameters.AddWithValue("memberId", (UpdatedDomainObject as Member).MemberId);
            command.Parameters.AddWithValue("passportNumber", (UpdatedDomainObject as Member).PassportNumber);
            command.Parameters.AddWithValue("birthDate", (UpdatedDomainObject as Member).Birthdate);
            command.Parameters.AddWithValue("address", (UpdatedDomainObject as Member).Address);
            command.Parameters.AddWithValue("telephoneNumber", (UpdatedDomainObject as Member).TelephoneNumber);
            command.Parameters.AddWithValue("education", (UpdatedDomainObject as Member).Education);
            command.Parameters.AddWithValue("readingRoomNumber", (UpdatedDomainObject as Member).ReadingRoomNumber);
            command.Parameters.AddWithValue("photo", (UpdatedDomainObject as Member).Photo);
            command.Parameters.AddWithValue("fullname", (UpdatedDomainObject as Member).FullName);
            command.Parameters.AddWithValue("targetMemberId", (TargetDomainObject as Member).MemberId);

            return command;
        }
        public NpgsqlCommand BuildReadingRoomsUpdateCommand()
        {

            var commandString = new StringBuilder($"UPDATE \"SoleSchema\".\"{Mapping.tableToStringName[Mapping.typeToTable[TargetDomainObject.GetType()]]}\" SET\n" +
                                                  "room_no = @roomNumber,\n" +
                                                  "room_name = @roomName,\n" +
                                                  "capacity = @capacity\n" +
                                                  "WHERE room_no = @targetRoomNumber");

            var command = Source.CreateCommand(commandString.ToString());

            command.Parameters.AddWithValue("roomNumber", (UpdatedDomainObject as ReadingRoom).RoomNumber);
            command.Parameters.AddWithValue("roomName", (UpdatedDomainObject as ReadingRoom).Name);
            command.Parameters.AddWithValue("capacity", (UpdatedDomainObject as ReadingRoom).Capacity);
            command.Parameters.AddWithValue("targetRoomNumber", (TargetDomainObject as ReadingRoom).RoomNumber);

            return command;
        }

        public NpgsqlCommand BuildEmployeesUpdateCommand()
        {
            var commandString = new StringBuilder($"UPDATE \"SoleSchema\".\"{Mapping.tableToStringName[Mapping.typeToTable[TargetDomainObject.GetType()]]}\" SET\n" +
                                                  "passport_no = @passportNumber,\n" +
                                                  "fullname = @fullname,\n" +
                                                  "taxpayer_id = @taxpayerId,\n" +
                                                  "social_security_no = @socSecNumber,\n" +
                                                  "employee_sex = @sex,\n" +
                                                  "photo = @photo\n" +
                                                  "WHERE passport = @targetPassportNumber");

            var command = Source.CreateCommand(commandString.ToString());

            command.Parameters.AddWithValue("passportNumber", (UpdatedDomainObject as Employee).PassportNumber);
            command.Parameters.AddWithValue("fullname", (UpdatedDomainObject as Employee).FullName);
            command.Parameters.AddWithValue("taxpayerId", (UpdatedDomainObject as Employee).TaxpayerId);
            command.Parameters.AddWithValue("socSecNumber", (UpdatedDomainObject as Employee).SocialSecurityNumber);
            command.Parameters.AddWithValue("sex", (UpdatedDomainObject as Employee).EmployeeSex);
            command.Parameters.AddWithValue("photo", (UpdatedDomainObject as Employee).Photo);
            command.Parameters.AddWithValue("targetPassportNumber", (TargetDomainObject as Employee).PassportNumber);

            return command;
        }


        public NpgsqlCommand Build()
        {
            return tableToBuilder[Mapping.typeToTable[TargetDomainObject.GetType()]]();
        }
    }
}
