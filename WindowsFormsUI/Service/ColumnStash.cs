using Domain;
using Domain.ModelPOCO;
using System.Reflection;

namespace WindowsFormsUI.Service
{
    internal class ColumnStash
    {
            public static List<DataGridViewColumn> BookColumns = new List<DataGridViewColumn>()
            {
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Шифр",
                    DataPropertyName = "Cipher",
                    Name = "CipherColumn"
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Название",
                    DataPropertyName = "Title",
                    Name = "TitleColumn"
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Автор",
                    DataPropertyName = "Author",
                    Name = "AuthorColumn"
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Жанр",
                    DataPropertyName = "Genre",
                    Name = "GenreColumn"
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Издание",
                    DataPropertyName = "Publisher",
                    Name = "PublisherColumn"
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Дата издания",
                    DataPropertyName = "DateOfPublishing",
                    Name = "DateOfPublishingColumn"
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Количество",
                    DataPropertyName = "Amount",
                    Name = "AmountColumn"
                }

            }; 

            public static List<DataGridViewColumn> BookTokenColumns = new List<DataGridViewColumn>()
            {
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Id Книги",
                    DataPropertyName = "TokenId",
                    Name = "MemberIdColumn"
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Шифр книги",
                    DataPropertyName = "TokenCipher",
                    Name = "TokenCipherColumn"
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Читальный зал",
                    DataPropertyName = "RoomNumber",
                    Name = "RoomNumberColumn"
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Предполагаемая дата возврата",
                    DataPropertyName = "DateOfClosure",
                    Name = "DateOfClosureColumn"
                }
            };

            public static  List<DataGridViewColumn> BookLeaseColumns = new List<DataGridViewColumn>()
            {
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Id Книги",
                    DataPropertyName = "TokenId",
                    Name = "MemberIdColumn"
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Id Заёмщика",
                    DataPropertyName = "LesseeId",
                    Name = "PassportNumberColumn"
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Дата займа",
                    DataPropertyName = "DateOfInitiation",
                    Name = "DateOfInitiation"
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Предполагаемая дата возврата",
                    DataPropertyName = "DateOfClosure",
                    Name = "DateOfClosureColumn"
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Фактическая дата возврата",
                    DataPropertyName = "FactualDateOfClosure",
                    Name = "FactClosureNumberColumn"
                },
                new DataGridViewImageColumn()
                {
                    HeaderText = "Сумма долга",
                    DataPropertyName = "SumOfFine",
                    Name = "SumOfFineColumn"
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Ответственный сотрудник",
                    DataPropertyName = "ResponsibleEmployee",
                    Name = "ResponsibleEmployeeColumn"
                }
        };


            public static List<DataGridViewColumn> MemberColumns = new List<DataGridViewColumn>()
            {
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Id",
                    DataPropertyName = "MemberId",
                    Name = "MemberIdColumn"
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Номер Паспорта",
                    DataPropertyName = "PassportNumber",
                    Name = "PassportNumberColumn"
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Дата рождения",
                    DataPropertyName = "Birthdate",
                    Name = "BirthdateColumn"
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Адрес",
                    DataPropertyName = "Address",
                    Name = "AddressColumn"
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Номер Телефона",
                    DataPropertyName = "TelephoneNumber",
                    Name = "TelephoneNumberColumn"
                },
                new DataGridViewImageColumn()
                {
                    HeaderText = "Фото",
                    DataPropertyName = "Photo",
                    Name = "PhotoColumn"
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Номер комнаты",
                    DataPropertyName = "RoomNumber",
                    Name = "RoomNumberColumn"
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Образование",
                    DataPropertyName = "Education",
                    Name = "EducationColumn"
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Имя",
                    DataPropertyName = "FullName",
                    Name = "FullNameColumn"
                }
            };


            public static  List<DataGridViewColumn> ReadingRoomsColumns = new List<DataGridViewColumn>()
            {
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Номер",
                    DataPropertyName = "RoomNumber",
                    Name = "RoomNumberColumn"
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Вместительность",
                    DataPropertyName = "Capacity",
                    Name = "CapacityColumn"
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Название",
                    DataPropertyName = "Name",
                    Name = "NameColumn"
                }
            };


            public static List<DataGridViewColumn> EmployeeColumns = new List<DataGridViewColumn>()
            { 
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Номер паспорта",
                    DataPropertyName = "PassportNumber",
                    Name = "PassportNumberColumn"
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Полное имя",
                    DataPropertyName = "FullName",
                    Name = "FullnameColumn"
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "ИНН",
                    DataPropertyName = "TaxpayerId",
                    Name = "TaxpayerIdColumn"
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "СНИЛС",
                    DataPropertyName = "SocialSecurityNumber",
                    Name = "SocSecColumn"
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Пол",
                    DataPropertyName = "EmployeeSex",
                    Name = "SexColumn"
                },
                new DataGridViewImageColumn()
                {
                    HeaderText = "Фото",
                    DataPropertyName = "Photo",
                    Name = "PhotoColumn"
                }
            };
           
    }

}

