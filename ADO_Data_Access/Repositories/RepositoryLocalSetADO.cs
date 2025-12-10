using Domain;
using Domain.ModelPOCO;
using System.Data;

namespace ADO_Data_Access.Repositories
{
    internal class RepositoryLocalSetADO
    {
        private static  RepositoryLocalSetADO _instance;
        private DataSet DataTable { get; set; }

        public RepositoryLocalSetADO()
        {
            DataTable = new DataSet();
        }

        public static RepositoryLocalSetADO GetInstance()
        {
            if (_instance == null)  _instance = new RepositoryLocalSetADO(); 
            return _instance;
        }

        public List<IDomainPOCO> Retrieve (TableEnum table)
        {
            DataTable.Clear();
            List<IDomainPOCO> domainObjects = new List<IDomainPOCO>();


            return domainObjects;
        }
        public void Redact(IDomainPOCO pocoToRedact, IDomainPOCO updatedPOCO)
        {
            throw new NotImplementedException();
        }

        public void Remove(IDomainPOCO domainObjectToRemove)
        {

        }
    }
}
