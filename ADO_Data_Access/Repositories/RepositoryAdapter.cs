using Domain;
using Domain.ModelPOCO;

namespace ADO_Data_Access.Repositories
{
    internal class RepositoryAdapter : IRepository
    {
        public void Add(IDomainPOCO domainPOCO)
        {
            throw new NotImplementedException();
        }

        public IDomainPOCO Delete(IDomainPOCO existingTableRecord)
        {
            throw new NotImplementedException();
        }

        public void Redact(IDomainPOCO pocoToRedact, IDomainPOCO updatedPOCO)
        {
            throw new NotImplementedException();
        }

        public List<IDomainPOCO> Retrieve(Type type)
        {
            throw new NotImplementedException();
        }
    }
}
