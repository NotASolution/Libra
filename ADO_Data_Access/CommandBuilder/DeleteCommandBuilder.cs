using ADO_Data_Access.Enumerations;

namespace ADO_Data_Access.CommandBuilder
{
    internal class DeleteCommandBuilder
    {
        private TableEnum SelectedTable;

        public DeleteCommandBuilder SetTable(TableEnum table)
        {
            SelectedTable = table;
            return this;
        }

        
    }
}
