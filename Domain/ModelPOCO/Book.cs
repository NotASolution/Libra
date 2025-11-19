
namespace Domain.ModelPOCO
{
    public class Book : IDomainPOCO
    {
        private string _cipher;
        private string _author;
        private string _title;
        private GenreEnum _genre;
        private string _publisher;
        private DateTime _dateOfPublishing;
        private int _amount;


        public string Cipher 
        {
            get
            {
                return _cipher; 
            }
            set
            {
                if (value.Length != 10) throw new Exception("Book cipher should be 10 characters long");
                _cipher = value;
            }
        }
        public string Author { get { return _author; } set { _author = value; } }
        public string Title { get { return _title; } set { _title = value; } }
        public GenreEnum Genre {  get { return _genre; } set { _genre = value; } }
        public string Publisher { get { return _publisher; } set { _publisher = value; } }
        public DateTime DateOfPublishing { get { return _dateOfPublishing; } set { _dateOfPublishing = value; } }
        public int Amount { get { return _amount; } set { _amount = value; } }


    }
}
