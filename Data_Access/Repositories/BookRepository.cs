
using BareEFC_Data_Access.Entities;
using Data_Access;
using Microsoft.EntityFrameworkCore;



namespace BareEFC_Data_Access.Repositories
{
    internal class BookRepository : IEntityRepository
    {
        public void Add(IEntity entityToAdd)
        {
            BookEntity bookEntity = entityToAdd as BookEntity;

            using (LibraryContext context = new LibraryContext())
            {
                if (context.Books.Find(bookEntity.Cipher) != null) throw new Exception("book with such cipher already exists");
                context.Books.Add(bookEntity);
                context.SaveChanges();
            }
        }

        public void Redact(IEntity entityToUpdate, IEntity updatedEntity)
        {
            BookEntity bookToUpdate;
            BookEntity bookUpdated = updatedEntity as BookEntity;

            using(LibraryContext context = new LibraryContext())
            {
                bookToUpdate = context.Books.Find(entityToUpdate.PrimaryKey) ?? throw new Exception("Can't edit given book as book with such cipher does not exist in database");
                
                bookToUpdate.Cipher = bookUpdated.Cipher;
                bookToUpdate.Title = bookUpdated.Title;
                bookToUpdate.Author = bookUpdated.Author;
                bookToUpdate.Publisher = bookUpdated.Publisher;
                bookToUpdate.Amount = bookUpdated.Amount;
                bookToUpdate.Genre = bookUpdated.Genre;

                context.SaveChanges();

            }
        }

        public IEntity Remove(IEntity entityToRemove)
        {
            BookEntity book = (BookEntity)entityToRemove;

            using (LibraryContext context = new LibraryContext())
            {
                var bookEntity = context.Books.Where(b => b.Cipher == book.Cipher).Include(b => b.BookTokens).SingleOrDefault();
                context.Books.Remove(bookEntity);

                context.SaveChanges();
            }

            return entityToRemove;
        }

        public List<IEntity> Retrieve()
        {
            List<IEntity> entities;

            using (LibraryContext context = new LibraryContext())
            {
                entities = context.Books.AsNoTracking().Cast<IEntity>().ToList();
            }

            return entities;
        }

    }
}
