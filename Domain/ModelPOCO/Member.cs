using System.Drawing;
namespace Domain.ModelPOCO
{
    public class Member : IDomainPOCO
    {
        private string _memberId;
        private string _passportNumber;
        private DateTime _birthDate;
        private string _address;
        private string _telephoneNumber;
        private string _education;
        private int _readingRoomNumber;
        private byte[]? _photo;
        private string _fullName;

        public string MemberId { get { return _memberId; } set { _memberId = value; } }
        public string PassportNumber { get { return _passportNumber; } set { _passportNumber = value; }}
        public DateTime Birthdate {  get { return _birthDate; } set {_birthDate = value; } }
        public string Address { get { return _address; } set { _address = value; } }
        public string TelephoneNumber {  get { return _telephoneNumber; } set { _telephoneNumber = value; }}
        public string Education {  get { return _education; } set { _education = value; }}
        public int ReadingRoomNumber { get {return _readingRoomNumber;} set { _readingRoomNumber = value; } }
        public byte[]? Photo { get { return _photo; } set {_photo = value; }}
        public string FullName { get { return _fullName; } set { _fullName = value; }}
    }
}
