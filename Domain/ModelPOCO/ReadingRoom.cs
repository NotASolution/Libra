namespace Domain.ModelPOCO
{
    public class ReadingRoom : IDomainPOCO
    {
        private int _roomNumber;
        private int _capacity;
        private string _name;

        public int RoomNumber { get { return _roomNumber; } set { _roomNumber = value; } }
        public int Capacity { get { return _capacity; } set { _capacity = value; } } 
        public string Name { get { return _name; } set { _name = value; } }
    }
}
