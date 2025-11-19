using Domain.ModelPOCO;

namespace BareEFC_Data_Access.Entities
{
    public class BookTokenEntity : IEntity
    {
        public int TokenId { get; set; }
        public string TokenCipher { get; set; }
        public int RoomNumber { get; set; }
        public bool IsTaken { get; set; }
        public BookEntity Book { get; set; }
        public ReadingRoomEntity ReadingRoom { get; set; }
        public Type PriamryKeyType { get { return TokenId.GetType(); } }

        public object PrimaryKey { get { return TokenId; } }

        public void AcceptParentPOCO(object ParentPOCO)
        {
            if (ParentPOCO.GetType() != typeof(BookToken)) throw new Exception("Invalid parent POCO input");

            BookToken parent = ParentPOCO as BookToken;

            this.TokenId = parent.TokenId;
            this.TokenCipher= parent.TokenCipher;   
            this.RoomNumber = parent.RoomNumber;
            this.IsTaken = parent.IsTaken;
            
        }

        public IDomainPOCO ConvertToDomainPoco()
        {
            throw new NotImplementedException();
        }
    }
}
