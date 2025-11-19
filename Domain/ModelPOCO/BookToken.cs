
namespace Domain.ModelPOCO
{
    public class BookToken : IDomainPOCO
    {
        private int _tokenId;
        private string _tokenCipher;
        private int _roomNumber;
        private bool _isTaken;

        public int TokenId { get { return _tokenId; } set { _tokenId = value; } }
        public string TokenCipher { get { return _tokenCipher; } set { _tokenCipher = value; } }
        public int RoomNumber { get { return _roomNumber; } set { _roomNumber = value; } }
        public bool IsTaken { get { return _isTaken; } set { _isTaken = value; } }
    }
}
