using Domain.ModelPOCO;
using System.Text;

namespace TestingOnConsole
{
    internal class BookBuilder
    {
        private Book book;
        

        public BookBuilder()
        {
            this.book = new Book();
        }
        public BookBuilder AddCipher(string Cipher)
        {
            book.Cipher = Cipher;
            return this;
        }
        public BookBuilder AddDateOfPublishing(DateTime dateOfPublishing)
        {
            book.DateOfPublishing = dateOfPublishing;
            return this;
        }
        public BookBuilder AddPublisher(string Publisher)
        {
            book.Publisher = Publisher;
            return this;
        }
        public BookBuilder AddGenre(GenreEnum Genre)
        {
            book.Genre = Genre;
            return this;
        }
        public BookBuilder AddAuthor(string Author)
        {
            book.Author = Author;
            return this;
        }

        public BookBuilder AddTitle(string Title)
        {
            book.Title = Title;
            return this;
        }
        public Book Build()
        {
            return book;
        }
    }
}
