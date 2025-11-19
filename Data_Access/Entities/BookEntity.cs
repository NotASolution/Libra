using Domain.ModelPOCO;

namespace BareEFC_Data_Access.Entities
{
    public class BookEntity : IEntity
    {
        
        public string Cipher{ get; set; }
        
        public string Author { get; set; }
        public string Title { get; set; }
        public GenreEntityEnum Genre { get; set; }
        public string Publisher { get; set; }
        public DateTime DateOfPublishing { get; set; }
        public int Amount { get; set; }


    
        public ICollection<BookTokenEntity> BookTokens { get; set; }
        public Type PriamryKeyType { get { return Cipher.GetType(); } }

        public object PrimaryKey { get { return Cipher; } }


    }
}
