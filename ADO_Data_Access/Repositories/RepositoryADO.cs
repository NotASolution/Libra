using Domain.ModelPOCO;
using Npgsql;

namespace ADO_Data_Access.Repositories
{
    internal class RepositoryADO
    {
        private NpgsqlDataSource DataSource { get; set; }

        public RepositoryADO()
        {
            var dataSourceBuilder = new NpgsqlDataSourceBuilder();
            DataSource = dataSourceBuilder.Build();
        }

        public List<IDomainPOCO> Retrieve()
        {
            using (NpgsqlConnection connection = DataSource.CreateConnection())
            {

            }
                return new List<IDomainPOCO>();
        }

        public void Create(IDomainPOCO domainPocoToAdd)
        {
            using (NpgsqlConnection connection = DataSource.CreateConnection())
            {

            }
        }
        public void Redact(IDomainPOCO domainPocoToredact, IDomainPOCO updatedDomainPoco)
        {
            using (NpgsqlConnection connection = DataSource.CreateConnection())
            { 
            
            }
        }
        public void Remove(List<IDomainPOCO> domainPocosToRemove)
        {
            using (NpgsqlConnection connection = DataSource.CreateConnection())
            {

            }
        }
        
    }
}
