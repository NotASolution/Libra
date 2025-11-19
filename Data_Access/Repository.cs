using BareEFC_Data_Access.Repositories;
using Domain;
using Domain.ModelPOCO;

namespace BareEFC_Data_Access
{
    public class Repository : IRepository
    {
        IEntityRepository entityRepository;
        DomainObjectFactory domainFactory;
        EntityFactory entityFactory;

        public void Add(IDomainPOCO domainPOCO)
        {
            entityRepository = EntityRepositoryCreator.CreateRepository(EntityFactory.GetEntityType(domainPOCO.GetType()));
            entityFactory = new EntityFactory();
            var book = entityFactory.CreateEntity(domainPOCO);
            entityRepository.Add(book);
        }

        public IDomainPOCO Delete(IDomainPOCO existingTableRecord)
        {
            entityRepository = EntityRepositoryCreator.CreateRepository(existingTableRecord.GetType());

            return existingTableRecord;
        }

        public void Redact(IDomainPOCO pocoToRedact, IDomainPOCO updatedPOCO)
        {
            entityRepository = EntityRepositoryCreator.CreateRepository(pocoToRedact.GetType());
            entityFactory = new EntityFactory();
            entityRepository.Redact(entityFactory.CreateEntity(pocoToRedact), entityFactory.CreateEntity(updatedPOCO));
        }

        public List<IDomainPOCO> Retrieve(Type type)
        {
            entityRepository = EntityRepositoryCreator.CreateRepository(EntityFactory.GetEntityType(type));
            domainFactory = new DomainObjectFactory();
            List<IDomainPOCO> domainPOCOs = entityRepository.Retrieve().Select(ent => domainFactory.CreateDomainPOCO(ent)).ToList();

            return domainPOCOs;
        }

    }
}
