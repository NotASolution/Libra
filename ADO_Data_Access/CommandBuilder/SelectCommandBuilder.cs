
using ADO_Data_Access.Enumerations;
using Domain;
using Npgsql;
using System.Text;


namespace ADO_Data_Access.CommandBuilder
{
    internal class SelectCommandBuilder
    {
        private NpgsqlDataSource Source { get; set; } 
        private TableEnum SelectedTable { get; set; }

        public SelectCommandBuilder SetDataSource(NpgsqlDataSource source)
        {
            Source = source;
            return this;
        }
       
        public SelectCommandBuilder SetTable(TableEnum table)
        {
            SelectedTable = table;
            return this;
        }

        private NpgsqlCommand Build()
        {
            return Source.CreateCommand();
        }
        
        
    }
}
