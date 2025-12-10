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
            SelectedTable = TableEnum.Books;
            DataTableView.DataSource = Repository.Retrieve(SelectedTable).Cast<Book>().ToList();
        }

        private void BookTokensSelectButton_Click(object sender, EventArgs e)
        {
            SelectedTable = TableEnum.BookTokens;
            DataTableView.DataSource = Repository.Retrieve(SelectedTable).Cast<BookToken>().ToList();
        }

        private void BookLeasesSelectButton_Click(object sender, EventArgs e)
        {
            SelectedTable = TableEnum.BookLeases;
            DataTableView.DataSource = Repository.Retrieve(SelectedTable).Cast<BookLease>().ToList();
        }

        private void MemberTableSelectButton_Click(object sender, EventArgs e)
        {
            SelectedTable = TableEnum.Members;
            DataTableView.DataSource = Repository.Retrieve(SelectedTable).Cast<Member>().ToList();
        }

        private void ReadingRoomsTableSelectButton_Click(object sender, EventArgs e)
        {
            SelectedTable = TableEnum.ReadingRooms;
            DataTableView.DataSource = Repository.Retrieve(SelectedTable).Cast<ReadingRoom>().ToList();
        }

        private void EmployeesTableSelectTable_Click(object sender, EventArgs e)
        {
            SelectedTable = TableEnum.Employees;
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
            if(DataTableView.SelectedRows.Count > 0)
                TargetDomainObject = new DataGridRowsToDomainObjectConverter().ConvertToDomainObject(DataTableView.SelectedRows[0], selectedTable);
        }
    }
}
