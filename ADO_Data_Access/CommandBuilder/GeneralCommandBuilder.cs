
using ADO_Data_Access.Enumerations;
using Npgsql;
using System.Text;


namespace ADO_Data_Access.CommandBuilder
{
    internal class GeneralCommandBuilder
    {
        private CommandsEnum Command { get; set; }
        private StringBuilder CommandString { get; set; }
        private NpgsqlDataSource DataSource { get; set; }

        private Dictionary<CommandsEnum, string> commandTypeToString = new Dictionary<CommandsEnum, string>()
        {
            { CommandsEnum.INSERT, "INSERT INTO "},
            { CommandsEnum.DELETE, "DELETE FROM "}
        };


        public GeneralCommandBuilder SetDataSource(NpgsqlDataSource source)
        {
            DataSource = source;
            return this;
        }

        public GeneralCommandBuilder AssertCommandType(CommandsEnum commandType)
        {
            CommandString.Append(commandTypeToString[commandType]);
            Command = commandType;
            return this;
        }

        
        private NpgsqlCommand Build()
        {
            return DataSource.CreateCommand();
        }

    }
}
