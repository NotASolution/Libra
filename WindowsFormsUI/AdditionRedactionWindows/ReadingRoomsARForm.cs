
using Domain.ModelPOCO;

namespace WindowsFormsUI.NewFolder
{
    public partial class ReadingRoomsARForm : Form
    {
        private bool IsRedaction { get; set; } = false;
        private ReadingRoom RoomObject { get; set; }
        private IAdditionRedactionHost Host { get; set; }


        public ReadingRoomsARForm()
        {
            InitializeComponent();
        }
        public ReadingRoomsARForm(IAdditionRedactionHost host, ReadingRoom roomObject)
        {
            RoomObject = roomObject;
            Host = host;
            IsRedaction = true;
            InitializeComponent();
        }

        public ReadingRoomsARForm(IAdditionRedactionHost host)
        {
            RoomObject = new ReadingRoom();
            Host = host;
            InitializeComponent();
        }

        private void Finish_Click(object sender, EventArgs e)
        {
            if (RoomObject == null) RoomObject = new ReadingRoom();

            RoomObject.Capacity = Convert.ToInt32(RoomNumberTextBox.Text);
            RoomObject.Name = RoomNameTextBox.Text;
            RoomObject.RoomNumber = Convert.ToInt32(RoomCapacityTextBox.Text);

            Host.AcceptDomainObject(RoomObject);
        }
    }
}
