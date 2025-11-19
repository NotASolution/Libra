namespace Domain.ModelPOCO
{
    public class BookLease : IDomainPOCO
    {
        private int _tokenId;
        private string _lesseeId;
        private DateTime _dateOfInitiation;
        private DateTime _dateOfClosure;
        private DateTime _factualDateOfClosure;
        private int _sumOfFine;
        private string _responsibleEmployee;



        public int TokenId { get { return _tokenId; } set { _tokenId = value; } }
        public string LesseeId {  get { return _lesseeId; } set { _lesseeId = value; }}
        public DateTime DateOfInitiation { get { return _dateOfInitiation; } set { _dateOfInitiation = value; } }
        public DateTime DateOfClosure { get { return _dateOfClosure; } set { _dateOfClosure = value; }}
        public DateTime FactualDateOfClosure { get { return _factualDateOfClosure; } set { _factualDateOfClosure = value; } }
        public int SumOfFine { get { return _sumOfFine; } set { _sumOfFine = value; } }
        public string ResponsibleEmployee { get { return _responsibleEmployee; } set { _responsibleEmployee = value; }}

    }
}
