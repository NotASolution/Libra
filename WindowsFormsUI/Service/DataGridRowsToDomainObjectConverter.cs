
using Domain;
using Domain.ModelPOCO;

namespace WindowsFormsUI.Service
{
    internal class DataGridRowsToDomainObjectConverter
    {
        private Dictionary<TableEnum, Func<DataGridViewRow, IDomainPOCO>> tableToConverter = new Dictionary<TableEnum, Func<DataGridViewRow, IDomainPOCO>>();

        public DataGridRowsToDomainObjectConverter()
        {
            tableToConverter.Add(TableEnum.ReadingRooms, ConvertToReadingRoomObject);
            tableToConverter.Add(TableEnum.Books, ConvertToBookObject);
        }
        public IDomainPOCO ConvertToDomainObject(DataGridViewRow domainObjectRowForm, TableEnum table)
        {
            return tableToConverter[table](domainObjectRowForm);
        }

        private IDomainPOCO ConvertToBookObject(DataGridViewRow bookTableRowForm)
        {
            var convertedBook = new Book()
            {
                Cipher = bookTableRowForm.Cells["Cipher"].Value.ToString(),
                Title = bookTableRowForm.Cells["Title"].Value.ToString(),
                Author = bookTableRowForm.Cells["Author"].Value.ToString(),
                Genre = (GenreEnum)bookTableRowForm.Cells["Genre"].Value,
                Publisher = bookTableRowForm.Cells["Publisher"].Value.ToString(),
                DateOfPublishing = Convert.ToDateTime(bookTableRowForm.Cells["DateOfPublishing"].Value),
                Amount = Convert.ToInt32(bookTableRowForm.Cells["Amount"].Value)

            };
            return convertedBook;
        }

        private IDomainPOCO ConvertToReadingRoomObject(DataGridViewRow readingRoomTableRow)
        {
            var convertedReadingRoom = new ReadingRoom()
            {
                RoomNumber = Convert.ToInt32(readingRoomTableRow.Cells["RoomNumber"].Value),
                Name = readingRoomTableRow.Cells["Name"].Value.ToString(),
                Capacity = Convert.ToInt32(readingRoomTableRow.Cells["Capacity"].Value)
            };
            return convertedReadingRoom;
        }
    }
}
