using ADO_Data_Access.Repositories;
using Domain;
using Domain.ModelPOCO;
using System.ComponentModel;
using WindowsFormsUI.AdditionRedactionWindows;
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

        private Dictionary<TableEnum, Func<IAdditionRedactionHost, Form>> tableToAddition = new Dictionary<TableEnum, Func<IAdditionRedactionHost, Form>>();

        private Dictionary<TableEnum, Func<IAdditionRedactionHost, IDomainPOCO, Form>> tableToRedaction = new Dictionary<TableEnum, Func<IAdditionRedactionHost, IDomainPOCO, Form>>();

        public LibraryTableControl()
        {
            tableToAddition.Add(TableEnum.ReadingRooms, (RedactionHost) => new ReadingRoomsARForm(RedactionHost));
            tableToRedaction.Add(TableEnum.ReadingRooms, (RedactionHost, DomainObject) => new ReadingRoomsARForm(RedactionHost, (ReadingRoom)DomainObject));
            tableToAddition.Add(TableEnum.Members, (RedactionHost) => new MembersARForm(RedactionHost));
            tableToRedaction.Add(TableEnum.Members, (RedactionHost, DomainObject) => new MembersARForm(RedactionHost, (Member)DomainObject));
            Repository = new RepositoryAdapter();
            InitializeComponent();
            DataTableView.AutoGenerateColumns = false;
            DataTableView.DataSource = DataTableSource;
            DataTableView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

        }

        public void AcceptDomainObject(IDomainPOCO domainObject, bool isAddition)
        {
            if (isAddition) Repository.Add(domainObject);
            else Repository.Redact(TargetDomainObject, domainObject);
        }

        private void AddMenuButton_Click(object sender, EventArgs e)
        {
            if (TargetDomainObject == null) return;
            var ReadingRoomsAdditionForm = tableToAddition[SelectedTable](this);
            ReadingRoomsAdditionForm.ShowDialog();
        }

        private void BooksTableSelectButton_Click(object sender, EventArgs e)
        {
            DataTableView.Columns.Clear();
            SelectedTable = TableEnum.Books;

            ColumnFactory.GetColumns(SelectedTable).ForEach(column => DataTableView.Columns.Add(column));
            DataTableView.DataSource = Repository.Retrieve(SelectedTable).Cast<Book>().ToList();
        }

        private void BookTokensSelectButton_Click(object sender, EventArgs e)
        {
            DataTableView.Columns.Clear();
            SelectedTable = TableEnum.BookTokens;

            ColumnFactory.GetColumns(SelectedTable).ForEach(column => DataTableView.Columns.Add(column));

            DataTableView.DataSource = Repository.Retrieve(SelectedTable).Cast<BookToken>().ToList();
        }

        private void BookLeasesSelectButton_Click(object sender, EventArgs e)
        {
            DataTableView.Columns.Clear();
            SelectedTable = TableEnum.BookLeases;

            ColumnFactory.GetColumns(SelectedTable).ForEach(column => DataTableView.Columns.Add(column));

            DataTableView.DataSource = Repository.Retrieve(SelectedTable).Cast<BookLease>().ToList();
        }

        private void MemberTableSelectButton_Click(object sender, EventArgs e)
        {
            DataTableView.Columns.Clear();
            SelectedTable = TableEnum.Members;

            ColumnFactory.GetColumns(SelectedTable).ForEach(column => DataTableView.Columns.Add(column));

            DataTableView.DataSource = Repository.Retrieve(SelectedTable).Cast<Member>().ToList();
        }

        private void ReadingRoomsTableSelectButton_Click(object sender, EventArgs e)
        {
            DataTableView.Columns.Clear();

            SelectedTable = TableEnum.ReadingRooms;

            ColumnFactory.GetColumns(SelectedTable).ForEach(column => DataTableView.Columns.Add(column));

            DataTableView.DataSource = Repository.Retrieve(SelectedTable).Cast<ReadingRoom>().ToList();
        }

        private void EmployeesTableSelectTable_Click(object sender, EventArgs e)
        {
            DataTableView.Columns.Clear();

            SelectedTable = TableEnum.Employees;
            ColumnFactory.GetColumns(SelectedTable).ForEach(column => DataTableView.Columns.Add(column));

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
            if (TargetDomainObject == null) return;
            var ReadingRoomsAdditionForm = tableToRedaction[SelectedTable](this, TargetDomainObject);
            ReadingRoomsAdditionForm.ShowDialog();
        }


    }
}
