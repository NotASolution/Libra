using Domain;
using Domain.ModelPOCO;

namespace ADO_Data_Access.Repositories
{
    public class RepositoryAdapter : IRepository
    {
        private RepositoryADO repository = new RepositoryADO();

        public void Add(IDomainPOCO domainPOCO)
        {
            repository.Create(domainPOCO);
        }

        public IDomainPOCO Delete(IDomainPOCO existingTableRecord)
        {
            repository.Remove(existingTableRecord);
            return existingTableRecord;
        }

        public void Redact(IDomainPOCO pocoToRedact, IDomainPOCO updatedPOCO)
        {
            repository.Redact(pocoToRedact, updatedPOCO);
        }


        public List<IDomainPOCO> Retrieve(TableEnum table)
        {
            return repository.Retrieve(table);
        }
    }
}
