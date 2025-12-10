using ADO_Data_Access.Repositories;
using Domain;
using Domain.ModelPOCO;
using System.ComponentModel;
using WindowsFormsUI.NewFolder;
using WindowsFormsUI.Service;

namespace WindowsFormsUI.UserElements
{
    public partial class LibraryTableControl : UserControl, IAdditionRedactionHost
    {
        private TableEnum selectedTable;
        private IDomainPOCO TargetDomainObject { get; set; }

        private BindingList<IDomainPOCO> DataTableSource { get; set; } = new BindingList<IDomainPOCO>();
        private IRepository Repository
        {
            get; set;
        }

        private TableEnum SelectedTable
        {
            get => selectedTable;
            set
            {
                selectedTable = value;
                Repository.Retrieve((TableEnum)selectedTable);

            }
        }

        private Dictionary<TableEnum, Func<IAdditionRedactionHost, Form>> tableToAR = new Dictionary<TableEnum, Func<IAdditionRedactionHost, Form>>();

        public LibraryTableControl()
        {
            tableToAR.Add(TableEnum.ReadingRooms, (RedactionHost) => new ReadingRoomsARForm(RedactionHost));
            Repository = new RepositoryAdapter();
            InitializeComponent();
            DataTableView.AutoGenerateColumns = false;
            DataTableView.DataSource = DataTableSource;

        }

        public void AcceptDomainObject(IDomainPOCO domainObject)
        {
            Repository.Add(domainObject);
        }

        private void AddMenuButton_Click(object sender, EventArgs e)
        {
            var ReadingRoomsAdditionForm = tableToAR[SelectedTable](this);
            ReadingRoomsAdditionForm.ShowDialog();
        }

        private void BooksTableSelectButton_Click(object sender, EventArgs e)
        {
            DataTableView.Columns.Clear();

            SelectedTable = TableEnum.Books;
            DataTableView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Шифр",
                DataPropertyName = "Cipher",
                Name = "CipherColumn"
            });
            DataTableView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Название",
                DataPropertyName = "Title",
                Name = "TitleColumn"
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
            });
            DataTableView.DataSource = Repository.Retrieve(SelectedTable).Cast<Book>().ToList();
        }

        private void BookTokensSelectButton_Click(object sender, EventArgs e)
        {
            DataTableView.Columns.Clear();
            SelectedTable = TableEnum.BookTokens;

            DataTableView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Id Книги",
                DataPropertyName = "TokenId",
                Name = "MemberIdColumn"
            });
            DataTableView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Шифр книги",
                DataPropertyName = "TokenCipher",
                Name = "TokenCipherColumn"
            });
            DataTableView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Читальный зал",
                DataPropertyName = "RoomNumber",
                Name = "RoomNumberColumn"
            });
            DataTableView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Предполагаемая дата возврата",
                DataPropertyName = "DateOfClosure",
                Name = "DateOfClosureColumn"
            });

            DataTableView.DataSource = Repository.Retrieve(SelectedTable).Cast<BookToken>().ToList();
        }

        private void BookLeasesSelectButton_Click(object sender, EventArgs e)
        {
            SelectedTable = TableEnum.BookLeases;


            DataTableView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Id Книги",
                DataPropertyName = "TokenId",
                Name = "MemberIdColumn"
            });
            DataTableView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Id Заёмщика",
                DataPropertyName = "LesseeId",
                Name = "PassportNumberColumn"
            });
            DataTableView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Дата займа",
                DataPropertyName = "DateOfInitiation",
                Name = "DateOfInitiation"
            });
            DataTableView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Предполагаемая дата возврата",
                DataPropertyName = "DateOfClosure",
                Name = "DateOfClosureColumn"
            });
            DataTableView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Фактическая дата возврата",
                DataPropertyName = "FactualDateOfClosure",
                Name = "FactClosureNumberColumn"
            });
            DataTableView.Columns.Add(new DataGridViewImageColumn()
            {
                HeaderText = "Сумма долга",
                DataPropertyName = "SumOfFine",
                Name = "SumOfFineColumn"
            });
            DataTableView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Ответственный сотрудник",
                DataPropertyName = "ResponsibleEmployee",
                Name = "ResponsibleEmployeeColumn"
            });

            DataTableView.DataSource = Repository.Retrieve(SelectedTable).Cast<BookLease>().ToList();
        }

        private void MemberTableSelectButton_Click(object sender, EventArgs e)
        {
            DataTableView.Columns.Clear();
            SelectedTable = TableEnum.Members;

            DataTableView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Id",
                DataPropertyName = "MemberId",
                Name = "MemberIdColumn"
            });
            DataTableView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Номер Паспорта",
                DataPropertyName = "PassportNumber",
                Name = "PassportNumberColumn"
            });
            DataTableView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Дата рождения",
                DataPropertyName = "Birthdate",
                Name = "BirthdateColumn"
            });
            DataTableView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Адрес",
                DataPropertyName = "Address",
                Name = "AddressColumn"
            });
            DataTableView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Номер Телефона",
                DataPropertyName = "TelephoneNumber",
                Name = "TelephoneNumberColumn"
            });
            DataTableView.Columns.Add(new DataGridViewImageColumn()
            {
                HeaderText = "Фото",
                DataPropertyName = "Photo",
                Name = "PhotoColumn"
            });
            DataTableView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Номер комнаты",
                DataPropertyName = "RoomNumber",
                Name = "RoomNumberColumn"
            });
            DataTableView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Образование",
                DataPropertyName = "Education",
                Name = "CapacityColumn"
            });
            DataTableView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Название",
                DataPropertyName = "FullName",
                Name = "FullNameColumn"
            });

            DataTableView.DataSource = Repository.Retrieve(SelectedTable).Cast<Member>().ToList();
        }

        private void ReadingRoomsTableSelectButton_Click(object sender, EventArgs e)
        {
            DataTableView.Columns.Clear();

            SelectedTable = TableEnum.ReadingRooms;

            DataTableView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Номер",
                DataPropertyName = "RoomNumber",
                Name = "RoomNumberColumn"
            });
            DataTableView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Вместительность",
                DataPropertyName = "Capacity",
                Name = "CapacityColumn"
            });
            DataTableView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Название",
                DataPropertyName = "Name",
                Name = "NameColumn"
            });

            DataTableView.DataSource = Repository.Retrieve(SelectedTable).Cast<ReadingRoom>().ToList();
        }

        private void EmployeesTableSelectTable_Click(object sender, EventArgs e)
        {
            DataTableView.Columns.Clear();

            SelectedTable = TableEnum.Employees;
            DataTableView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Номер паспорта",
                DataPropertyName = "PassportNumber",
                Name = "PassportNumberColumn"
            });
            DataTableView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Полное имя",
                DataPropertyName = "FullName",
                Name = "FullnameColumn"
            });
            DataTableView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "ИНН",
                DataPropertyName = "TaxpayerId",
                Name = "TaxpayerIdColumn"
            });
            DataTableView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "СНИЛС",
                DataPropertyName = "SocialSecurityNumber",
                Name = "SocSecColumn"
            });
            DataTableView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Пол",
                DataPropertyName = "EmployeeSex",
                Name = "SexColumn"
            });
            DataTableView.Columns.Add(new DataGridViewImageColumn()
            {
                HeaderText = "Фото",
                DataPropertyName = "Photo",
                Name = "PhotoColumn"
            });

            DataTableView.DataSource = Repository.Retrieve(SelectedTable).Cast<Employee>().ToList();
        }


        private void DeleteMenuButton_Click(object sender, EventArgs e)
        {
            if (DataTableView.CurrentRow != null)
            {
                var selectedDomainObject = (IDomainPOCO)DataTableView.CurrentRow.DataBoundItem;
                DataTableSource.Remove(selectedDomainObject);
            }
            Repository.Delete(TargetDomainObject);
        }

        private void DataTableView_SelectionChanged(object sender, EventArgs e)
        {
            if (DataTableView.SelectedRows.Count > 0)
                TargetDomainObject = new DataGridRowsToDomainObjectConverter().ConvertToDomainObject(DataTableView.SelectedRows[0], selectedTable);
        }

        private void RedactMenuButton_Click(object sender, EventArgs e)
        {

        }
    }
}
