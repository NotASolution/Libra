using BareEFC_Data_Access.Entities;

namespace BareEFC_Data_Access.Repositories
{
    internal interface IEntityRepository
    {
        public void Add(IEntity entityToAdd);

        public void Redact(IEntity entityToUpdate, IEntity updatedEntity);
        public IEntity Remove(IEntity entityToRemove);

        public List<IEntity> Retrieve();

    }
}
