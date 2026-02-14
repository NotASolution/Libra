
using Domain;
using Domain.ModelPOCO;
using System.Drawing.Imaging;
using System.Net.Sockets;

namespace WindowsFormsUI.Service
{
    internal class DataGridRowsToDomainObjectConverter
    {
        private Dictionary<TableEnum, Func<DataGridViewRow, IDomainPOCO>> tableToConverter = new Dictionary<TableEnum, Func<DataGridViewRow, IDomainPOCO>>();

        public DataGridRowsToDomainObjectConverter()
        {
            tableToConverter.Add(TableEnum.ReadingRooms, ConvertToReadingRoomObject);
            tableToConverter.Add(TableEnum.Books, ConvertToBookObject);
            tableToConverter.Add(TableEnum.Members, ConvertToMemberObject);
        }
        public IDomainPOCO ConvertToDomainObject(DataGridViewRow domainObjectRowForm, TableEnum table)
        {
            return tableToConverter[table](domainObjectRowForm);
        }

        private IDomainPOCO ConvertToBookObject(DataGridViewRow bookTableRowForm)
        {
            var convertedBook = new Book()
            {
                Cipher = bookTableRowForm.Cells["CipherColumn"].Value.ToString(),
                Title = bookTableRowForm.Cells["TitleColumn"].Value.ToString(),
                Author = bookTableRowForm.Cells["Author"].Value.ToString(),
                Genre = (GenreEnum)bookTableRowForm.Cells["GenreColumn"].Value,
                Publisher = bookTableRowForm.Cells["PublisherColumn"].Value.ToString(),
                DateOfPublishing = Convert.ToDateTime(bookTableRowForm.Cells["DateOfPublishingColumn"].Value),
                Amount = Convert.ToInt32(bookTableRowForm.Cells["AmountColumn"].Value)

            };
            return convertedBook;
        }
        private IDomainPOCO ConvertToMemberObject(DataGridViewRow memberTableRowForm)
        {
            byte[]? BottledImage = null;

            if (memberTableRowForm.Cells["PhotoColumn"].Value != null)
            {
                using (MemoryStream ms = new MemoryStream((byte[])memberTableRowForm.Cells["PhotoColumn"].Value))
                {
                    var g = memberTableRowForm.Cells["PhotoColumn"].Value;
                    Image img = Image.FromStream(ms);
                    img.Save(ms, ImageFormat.Png);
                    BottledImage = ms.ToArray();
                }
            }
                var convertedMember = new Member()
                {
                    MemberId = memberTableRowForm.Cells["MemberIdColumn"].Value.ToString(),
                    PassportNumber = memberTableRowForm.Cells["PassportNumberColumn"].Value.ToString(),
                    Birthdate = Convert.ToDateTime(memberTableRowForm.Cells["BirthdateColumn"].Value),
                    Address = memberTableRowForm.Cells["AddressColumn"].Value.ToString(),
                    TelephoneNumber = memberTableRowForm.Cells["TelephoneNumberColumn"].Value.ToString(),
                    Photo = BottledImage,
                    ReadingRoomNumber = Convert.ToInt32(memberTableRowForm.Cells["ReadingRoomNumberColumn"].Value),
                    Education = memberTableRowForm.Cells["EducationColumn"].Value.ToString(),
                    FullName = memberTableRowForm.Cells["FullNameColumn"].Value.ToString()

                };
            
            return convertedMember;
        }
        private IDomainPOCO ConvertToReadingRoomObject(DataGridViewRow readingRoomTableRow)
        {
            var convertedReadingRoom = new ReadingRoom()
            {
                RoomNumber = Convert.ToInt32(readingRoomTableRow.Cells["RoomNumberColumn"].Value),
                Name = readingRoomTableRow.Cells["NameColumn"].Value.ToString(),
                Capacity = Convert.ToInt32(readingRoomTableRow.Cells["CapacityColumn"].Value)
            };
            return convertedReadingRoom;
        }

        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png); // or Jpeg, Bmp, etc.
                return ms.ToArray();
            }
        }

        private void LoadImageIntoPictureBox(PictureBox pictureBox)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureBox.Image = Image.FromFile(ofd.FileName);
                }
            }
        }
    }
}
