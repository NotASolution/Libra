using Domain.ModelPOCO;

namespace BareEFC_Data_Access.Entities
{
    public class ReadingRoomEntity : IEntity
    {
        public int RoomNumber { get; set; }
        public int Capacity { get; set; }
        public string Name { get; set; }

        public ICollection<MemberEntity> Members { get; set; }
        public ICollection<BookTokenEntity> BookTokens { get; set; }
        public Type PriamryKeyType { get { return RoomNumber.GetType(); } }

        public object PrimaryKey { get { return RoomNumber; } }

    }
}
