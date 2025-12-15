using Domain;
using Npgsql;


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

        public NpgsqlCommand SelectAll(string username)
        {
            var command = Source.CreateCommand();

            if (SelectedTable == TableEnum.Employees && username == "library_employee")
                command.CommandText = $"SELECT * FROM \"SoleSchema\".\"Employees_Masked\";";
            else if (SelectedTable == TableEnum.Members && username == "library_employee")
                command.CommandText = $"SELECT * FROM \"SoleSchema\".\"Members_Masked\";";//command.Parameters.AddWithValue("MaskingMeasures", "\"SoleSchema\".\"Members_Masked\"");
            else command.CommandText = $"SELECT * FROM \"SoleSchema\".\"{Mapping.tableToStringName[SelectedTable]}\";";///command.Parameters.AddWithValue("MaskingMeasures", $"\"SoleSchema\".\"{Mapping.tableToStringName[SelectedTable]}\"");

            return command;
        }

        public NpgsqlCommand GetSpecificCommand(int type)
        {
            string selectText = "";

            switch(type)
            {
                case 1:
                    selectText = $"SELECT * FROM \"SoleSchema\".\"Books\"";
                    break;
                case 2:
                    break;
                case 3: break;
            }
            var command = Source.CreateCommand(selectText);
            return command;
        }

        
    }
}
