using Domain;
using Domain.ModelPOCO;
using System.Reflection;

namespace WindowsFormsUI.Service
{
    internal class ColumnFactory
    {
       
        private static Dictionary<TableEnum, Func<List<DataGridViewColumn>>> tableToColumnsGenerator = new Dictionary<TableEnum, Func<List<DataGridViewColumn>>>();
  
        static ColumnFactory()
        {
            tableToColumnsGenerator.Add(TableEnum.Books, GetBooksTableColumns);
            tableToColumnsGenerator.Add(TableEnum.BookTokens, GetBookTokensTableColumns);
            tableToColumnsGenerator.Add(TableEnum.BookLeases, GetBookLeasesTableColumns);
            tableToColumnsGenerator.Add(TableEnum.Members, GetBooksTableColumns);
        }

        public static List<DataGridViewColumn> GetTableColumns(TableEnum table)
        {
            return tableToColumnsGenerator[table]();
        }


        private static List<DataGridViewColumn> GetBooksTableColumns()
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
                    Name = "PubDateColumn"
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Количество",
                    DataPropertyName = "Amount",
                    Name = "AmountColumn"
                }

            };

            return booksColumns;
        }   


        private static List<DataGridViewColumn> GetBookTokensTableColumns()
        {
            List<DataGridViewColumn> columns = new List<DataGridViewColumn>()
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
            return columns;
        }

        private static List<DataGridViewColumn> GetBookLeasesTableColumns()
        {
            List<DataGridViewColumn> columns = new List<DataGridViewColumn>()
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

            return columns;
        }

        private static List<DataGridViewColumn> GetMembersTableColumns()
        {
            List<DataGridViewColumn> columns = new List<DataGridViewColumn>()
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

            return columns;
        }

        private static List<DataGridViewColumn> GetReadingRoomsTableColumns()
        {
            List<DataGridViewColumn> columns = new List<DataGridViewColumn>()
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

            return columns;
        }

        private static List<DataGridViewColumn> GetEmployeesTableColumn()
        {
            List<DataGridViewColumn> columns = new List<DataGridViewColumn>()
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
            return columns;
        }
    }

}

