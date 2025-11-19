using BareEFC_Data_Access.Entities;
using Data_Access;
using Microsoft.EntityFrameworkCore;

namespace BareEFC_Data_Access.Repositories
{
    internal class BookTokenRepository : IEntityRepository
    {
        public void Add(IEntity entityToAdd)
        {
            BookTokenEntity bookTokenEntity;

            using (LibraryContext context = new LibraryContext())
            {
                bookTokenEntity = context.BookTokens.Find(entityToAdd.PrimaryKey) != null ? throw new Exception("Can't add this book token as token with this id already exists")
                                                                                          : entityToAdd as BookTokenEntity;

                context.BookTokens.Add(bookTokenEntity);

                context.Books.Where(book => book.Cipher == bookTokenEntity.TokenCipher).SingleOrDefault().Amount++;

                context.SaveChanges();
            }
        }

        public void Redact(IEntity entityToUpdate, IEntity updatedEntity)
        {
            BookTokenEntity bookTokenToUpdate;
            BookTokenEntity bookTokenUpdated = updatedEntity as BookTokenEntity;

            using (LibraryContext context = new LibraryContext())
            {
                bookTokenToUpdate = context.BookTokens.Find(entityToUpdate.PrimaryKey) ?? throw new Exception("Can't update given book token as token with such id does not exist");


            }
        }

        public IEntity Remove(IEntity entityToRemove)
        {
            BookTokenEntity bookTokenEntity;

            using (LibraryContext context = new LibraryContext())
            {
                bookTokenEntity = context.BookTokens.Where(bt => bt.TokenId == (int)entityToRemove.PrimaryKey).Include(bt => bt.Book).SingleOrDefault();
                bookTokenEntity.Book.Amount -= 1;
                context.Remove(bookTokenEntity);
                context.SaveChanges();
            }
                return entityToRemove;
        }

        public List<IEntity> Retrieve()
        {
            List<IEntity> entities;

            using (LibraryContext context = new LibraryContext())
            {
                entities = context.BookTokens.AsNoTracking().Cast<IEntity>().ToList();
            }
            return entities;
        }
    }
}
