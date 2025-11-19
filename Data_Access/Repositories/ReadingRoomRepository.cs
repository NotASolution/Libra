
using BareEFC_Data_Access.Entities;
using Data_Access;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace BareEFC_Data_Access.Repositories
{
    internal class ReadingRoomRepository : IEntityRepository
    {
        public void Add(IEntity entityToAdd)
        {
            ReadingRoomEntity roomEntity = entityToAdd as ReadingRoomEntity;

            using (LibraryContext context = new LibraryContext())
            {
                if (context.ReadingRooms.Find(entityToAdd.PrimaryKey) != null) throw new Exception("Room with such name already exists");
                context.ReadingRooms.Add(roomEntity);
                context.SaveChanges();
            }            
        }

        public void Redact(IEntity entityToUpdate, IEntity updatedEntity)
        {
            throw new NotImplementedException();
        }

        public IEntity Remove(IEntity entityToRemove)
        {
            throw new NotImplementedException();
        }

        public List<IEntity> Retrieve()
        {
            List<IEntity> retrievedRooms;

            using (LibraryContext context = new LibraryContext())
            {
                retrievedRooms = context.ReadingRooms.AsNoTracking().Cast<IEntity>().ToList();
            }

            return retrievedRooms;
        }

        public void Update(IEntity entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
