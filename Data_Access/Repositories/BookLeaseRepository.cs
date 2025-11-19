
using BareEFC_Data_Access.Entities;
using Data_Access;
using Microsoft.EntityFrameworkCore;

namespace BareEFC_Data_Access.Repositories
{
    internal class BookLeaseRepository : IEntityRepository
    {
        public void Add(IEntity entityToAdd)
        {
            BookLeaseEntity bookLeaseEntity;

            using (LibraryContext context = new LibraryContext())
            {
                bookLeaseEntity = context.BookLeases.Find(entityToAdd.PrimaryKey) == null ? throw new Exception("BookLease with such token already exists!")
                                                                                          : entityToAdd as BookLeaseEntity;
                context.BookLeases.Add(bookLeaseEntity);
                context.SaveChanges();
            }
        }

        public void Redact(IEntity entityToUpdate, IEntity updatedEntity)
        {
            BookLeaseEntity bookLeaseToUpdate;
            BookLeaseEntity bookLeaseUpdated = updatedEntity as BookLeaseEntity;

            using (LibraryContext context = new LibraryContext())
            {
                bookLeaseToUpdate = context.BookLeases.Find(entityToUpdate.PrimaryKey) ?? throw new Exception("Can't update given entity as it does not exist in database");

                bookLeaseToUpdate.LesseeId = bookLeaseUpdated.LesseeId;
                bookLeaseToUpdate.ResponsibleEmployee = bookLeaseUpdated.ResponsibleEmployee;
                bookLeaseToUpdate.TokenId = bookLeaseUpdated.TokenId;
                bookLeaseToUpdate.DateOfInitiation = bookLeaseUpdated.DateOfInitiation;
                bookLeaseToUpdate.DateOfClosure = bookLeaseUpdated.DateOfClosure;
                bookLeaseToUpdate.FactualDateOfClosure = bookLeaseUpdated.FactualDateOfClosure;
                bookLeaseToUpdate.SumOfFine = bookLeaseUpdated.SumOfFine;
            }
        }

        public IEntity Remove(IEntity entityToRemove)
        {
            BookLeaseEntity bookLeaseEntity;

            using (LibraryContext context = new LibraryContext())
            {
                bookLeaseEntity = context.BookLeases.Find(entityToRemove.PrimaryKey) ?? throw new Exception("Can't remove givent book lease as it does not exist in a database");
                context.Remove(bookLeaseEntity);

                context.SaveChanges();
            }

            return entityToRemove;
        }

        public List<IEntity> Retrieve()
        {
            List<IEntity> entities;

            using (LibraryContext context = new LibraryContext())
            {
                entities = (List<IEntity>)context.BookLeases.AsNoTracking().ToList().Cast<IEntity>();
            }
                return new List<IEntity>();
        }


        
    }
}
