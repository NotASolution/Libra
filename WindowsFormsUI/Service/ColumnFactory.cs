
using Domain;
using Domain.ModelPOCO;
using System.Reflection;
using System.Text.RegularExpressions;
namespace WindowsFormsUI.Service
{
    internal class ColumnFactory
    {
        private static Dictionary<Type, Func<string, string, string, DataGridViewColumn>> typeToColumns = new Dictionary<Type, Func<string, string, string, DataGridViewColumn>>()
        {
            { typeof(string), (headerText, dataPropertyName, name) => new DataGridViewTextBoxColumn() { HeaderText = headerText, DataPropertyName = dataPropertyName, Name = name} },
            { typeof(byte[]), (headerText, dataPropertyName, name) => new DataGridViewImageColumn() { HeaderText = headerText, DataPropertyName = dataPropertyName, Name = name, ImageLayout = DataGridViewImageCellLayout.Zoom}},
            { typeof(int), (headerText, dataPropertyName, name) => new DataGridViewTextBoxColumn(){ HeaderText = headerText, DataPropertyName = dataPropertyName, Name = name}},
            { typeof(DateTime), (headerText, dataPropertyName, name) => new DataGridViewTextBoxColumn(){ HeaderText = headerText, DataPropertyName = dataPropertyName, Name = name}},
            { typeof(GenreEnum), (headerText, dataPropertyName, name) => new DataGridViewTextBoxColumn(){ HeaderText = headerText, DataPropertyName = dataPropertyName, Name = name}},
            { typeof(EmployeeSexEnum), (headerText, dataPropertyName, name) => new DataGridViewTextBoxColumn(){ HeaderText = headerText, DataPropertyName = dataPropertyName, Name = name}},
            { typeof(bool), (headerText, dataPropertyName, name) => new DataGridViewCheckBoxColumn(){ HeaderText = headerText, DataPropertyName = dataPropertyName, Name = name}}
        };
        public static List<DataGridViewColumn> GetColumns(TableEnum table)
        {
            List<DataGridViewColumn> tableColumns = new List<DataGridViewColumn>();
            var properties = Mapping.tableToType[table].GetProperties(BindingFlags.Public | BindingFlags.Instance);

            DataGridViewColumn column;
            foreach (var property in properties)
            {
                column = typeToColumns[property.PropertyType](Regex.Replace(property.Name, "(?<!^)([A-Z])", " $1"), property.Name, $"{property.Name}Column");
                tableColumns.Add(column);
            }
            
            return tableColumns;
        }

    }
}
