using Domain;
using Domain.ModelPOCO;
using System.Reflection;

namespace WindowsFormsUI.Service
{
    internal class ColumnFactory
    {
        private Dictionary<Type, Func<DataGridViewColumn>> typeToColumn = new Dictionary<Type, Func<DataGridViewColumn>>()
        {
            { typeof(string), () => new DataGridViewTextBoxColumn()},
            { typeof(int),  () => new DataGridViewTextBoxColumn()},
            { typeof(byte[]), () => new DataGridViewImageColumn()},
            { typeof(DateTime), () => new DataGridViewTextBoxColumn()},
            { typeof(GenreEnum), () => new DataGridViewTextBoxColumn()},
            { typeof(EmployeeSexEnum), () => new DataGridViewTextBoxColumn()}
        };

        public List<DataGridViewColumn> GetTableColumns(TableEnum table)
        {
            
            PropertyInfo[] tableObjectProperties = Mapping.tableToType[table].GetType().GetProperties();
            List <DataGridViewColumn> columns = new List<DataGridViewColumn>();

            foreach (var property in tableObjectProperties)
            {

                columns.Add(typeToColumn[property.PropertyType]());
                columns.Last().Name = $"{property.Name}Column";
                columns.Last().HeaderText = property.Name;
                columns.Last().DataPropertyName = property.Name;
            }
               
            return columns;
        }
        
        /*
        public List<DataGridViewColumn> GetBooksTableColumns()
        {

            List<DataGridViewColumn> booksColumns = new List<DataGridViewColumn>()
            {
                new DataGridViewTextBoxColumn() 
                {
                    HeaderText = "Шифр",
                    DataPropertyName = "Cipher",
                    Name = "CipherColumn"
                },
                new DataGridViewColumn()
                {
                    HeaderText = "Название",
                    DataPropertyName = "Title",
                    Name = "TitleColumn"
                } 
            };
            
            DataTableView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Шифр",
                DataPropertyName = "Cipher",
                Name = "CipherColumn"
            });
            DataTableView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                
            });
            DataTableView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Автор",
                DataPropertyName = "Author",
                Name = "AuthorColumn"
            });
            DataTableView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Жанр",
                DataPropertyName = "Genre",
                Name = "GenreColumn"
            });
            DataTableView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Издание",
                DataPropertyName = "Publisher",
                Name = "PublisherColumn"
            });
            DataTableView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Дата издания",
                DataPropertyName = "DateOfPublishing",
                Name = "PubDateColumn"
            });
            DataTableView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Количество",
                DataPropertyName = "Amount",
                Name = "AmountColumn"
            });*/


    }

}

