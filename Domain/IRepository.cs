using Domain.ModelPOCO;

namespace Domain
{
    public interface IRepository
    {
        public void Add(IDomainPOCO domainPOCO);
        public void Redact(IDomainPOCO pocoToRedact, IDomainPOCO updatedPOCO);
        public List<IDomainPOCO> Retrieve(Type type);
        public IDomainPOCO Delete(IDomainPOCO existingTableRecord);
    }
}
