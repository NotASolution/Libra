using Domain.ModelPOCO;

namespace BareEFC_Data_Access.Entities
{
    public class BookLeaseEntity : IEntity
    {
        public int TokenId { get; set; }
        public string LesseeId { get; set; }
        public DateTime DateOfInitiation { get; set; }
        public DateTime DateOfClosure { get; set; }
        public DateTime FactualDateOfClosure { get; set; }
        public int SumOfFine { get; set; }
        public string ResponsibleEmployee { get; set; }
        public EmployeeEntity Employee { get; set; } 
        public BookTokenEntity BookTokenInLease { get; set; }
        public MemberEntity LesseeMember { get; set; }
        public Type PriamryKeyType { get { return TokenId.GetType(); } }

        public object PrimaryKey { get { return TokenId; } }

    }
}
