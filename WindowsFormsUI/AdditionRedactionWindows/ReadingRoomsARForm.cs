
using Domain.ModelPOCO;

namespace WindowsFormsUI.NewFolder
{
    public partial class ReadingRoomsARForm : Form
    {
        private bool IsAddition { get; set; } = false;
        private ReadingRoom RoomObject { get; set; }
        private IAdditionRedactionHost Host { get; set; }


        public ReadingRoomsARForm()
        {
            InitializeComponent();
        }
        public ReadingRoomsARForm(IAdditionRedactionHost host, ReadingRoom roomObject)
        {
            RoomObject = new ReadingRoom() { Name = roomObject.Name, Capacity = roomObject.Capacity, RoomNumber = roomObject.RoomNumber};
            Host = host;
            InitializeComponent();
            RoomNameTextBox.Text = roomObject.Name;
            RoomNumberTextBox.Text = roomObject.RoomNumber.ToString();
            RoomCapacityTextBox.Text = roomObject.Capacity.ToString();
        }

        public ReadingRoomsARForm(IAdditionRedactionHost host)
        {
            Host = host;
            IsAddition = true;
            InitializeComponent();
        }

        private void Finish_Click(object sender, EventArgs e)
        {
            RoomObject = new ReadingRoom();

            RoomObject.Capacity = Convert.ToInt32(RoomCapacityTextBox.Text);
            RoomObject.Name = RoomNameTextBox.Text;
            RoomObject.RoomNumber = Convert.ToInt32(RoomNumberTextBox.Text);

            Host.AcceptDomainObject(RoomObject, IsAddition);
            
        }
    }
}
