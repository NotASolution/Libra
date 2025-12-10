using ADO_Data_Access.Enumerations;
using Domain;
using Domain.ModelPOCO;
using Npgsql;
using System.Runtime.CompilerServices;
using System.Text;

namespace ADO_Data_Access.CommandBuilder
{
    internal class DeleteCommandBuilder
    {
        private delegate NpgsqlCommand BuildCommand();
        private TableEnum SelectedTable { get; set; }

        private IDomainPOCO SelectedDomainObject { get; set; }
        
        private NpgsqlDataSource DataSource { get; set; }

        private Dictionary<TableEnum, BuildCommand> tableToBuilder = new Dictionary<TableEnum, BuildCommand>();

        public DeleteCommandBuilder() 
        {
            tableToBuilder.Add(TableEnum.Books, BuildBooksDeletionCommand);
            tableToBuilder.Add(TableEnum.BookTokens, BuildBookTokensDeletionCommand);
            tableToBuilder.Add(TableEnum.BookLeases, BuildBookLeasesDeletionCommand);
            tableToBuilder.Add(TableEnum.Members, BuildMembersDeletionCommand);
            tableToBuilder.Add(TableEnum.ReadingRooms, BuildReadingRoomsDeletionCommand);
            tableToBuilder.Add(TableEnum.Employees, BuildEmployeesDeletionCommand);
        }

        public DeleteCommandBuilder SetTable(TableEnum table)
        {
            SelectedTable = table;
            return this;
        }
        public DeleteCommandBuilder SetDataSource(NpgsqlDataSource source)
        {
            DataSource = source;
            return this;
        }
        public DeleteCommandBuilder SetTargeetDomainObject(IDomainPOCO targetDomainObject)
        {
            SelectedDomainObject = targetDomainObject;
            return this;
        }
        private NpgsqlCommand BuildBooksDeletionCommand()
        {

            var commandString = new StringBuilder($"DELETE FROM \"SoleSchema\".\"{Mapping.tableToStringName[SelectedTable]}\" " +
                                                  $"WHERE {Mapping.tableToPrimaryKeyColumnName[SelectedTable]} = @BookCipher;");
            var command = DataSource.CreateCommand(commandString.ToString());
            command.Parameters.AddWithValue("BookCipher", ((Book)SelectedDomainObject).Cipher);


            return command;
        }

        private NpgsqlCommand BuildBookTokensDeletionCommand()
        {

            var commandString = new StringBuilder($"DELETE FROM \"SoleSchema\".\"{Mapping.tableToStringName[SelectedTable]}\" " +
                                                  $"WHERE {Mapping.tableToPrimaryKeyColumnName[SelectedTable]} = @TokenCipher;");
            var command = DataSource.CreateCommand(commandString.ToString());
            command.Parameters.AddWithValue("TokenCipher", ((BookToken)SelectedDomainObject).TokenId);

            return command;
        }

        private NpgsqlCommand BuildBookLeasesDeletionCommand()
        {
            var commandString = new StringBuilder($"DELETE FROM \"SoleSchema\".\"{Mapping.tableToStringName[SelectedTable]}\" " +
                                                              $"WHERE {Mapping.tableToPrimaryKeyColumnName[SelectedTable]} = @LeaseTokenId;");
            var command = DataSource.CreateCommand(commandString.ToString());
            command.Parameters.AddWithValue("LeaseTokenId", ((BookLease)SelectedDomainObject).TokenId);

            return command;
        }

        private NpgsqlCommand  BuildMembersDeletionCommand()
        {
            var commandString = new StringBuilder($"DELETE FROM \"SoleSchema\".\"{Mapping.tableToStringName[SelectedTable]}\" " +
                                                  $"WHERE {Mapping.tableToPrimaryKeyColumnName[SelectedTable]} = @MemberIdNumber");
            var command = DataSource.CreateCommand(commandString.ToString());
            command.Parameters.AddWithValue("MemberIdNumber", ((Member)SelectedDomainObject).MemberId);
            return command;
        }

        private NpgsqlCommand BuildReadingRoomsDeletionCommand()
        {
            var commandString = new StringBuilder($"DELETE FROM \"SoleSchema\".\"{Mapping.tableToStringName[SelectedTable]}\" " +
                                                  $"WHERE {Mapping.tableToPrimaryKeyColumnName[SelectedTable]} = @RoomNumber");
            var command = DataSource.CreateCommand(commandString.ToString());
            command.Parameters.AddWithValue("RoomNumber", ((ReadingRoom)SelectedDomainObject).RoomNumber);

            return command;
        }

        private NpgsqlCommand BuildEmployeesDeletionCommand()
        {
            var commandString = new StringBuilder($"DELETE FROM \"SoleSchema\".\"{Mapping.tableToStringName[SelectedTable]}\" " +
                                                  $"WHERE {Mapping.tableToPrimaryKeyColumnName[SelectedTable]} = @EmployeePassportNumber");
            var command = DataSource.CreateCommand(commandString.ToString());
            command.Parameters.AddWithValue("EmployeePassportNumber", ((Employee)SelectedDomainObject).PassportNumber);
            return command;
        }

        public NpgsqlCommand Build()
        {
            return tableToBuilder[SelectedTable]();
        }
    }
}
