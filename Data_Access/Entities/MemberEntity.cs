using Domain.ModelPOCO;

namespace BareEFC_Data_Access.Entities
{
    public class MemberEntity : IEntity
    {
        public string MemberId { get; set; }
        public string PassportNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }
        public string Education { get; set; }
        public int ReadingRoomNumber { get; set; }
        public byte[] Photo { get; set; }
        public string FullName { get; set; }

        public ReadingRoomEntity ReadingRoom { get; set; }
        public ICollection<BookLeaseEntity> Leases{ get; set; }
        public Type PriamryKeyType => throw new NotImplementedException();

        public object PrimaryKey => throw new NotImplementedException();

    }
}
