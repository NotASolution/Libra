using ADO_Data_Access.CommandBuilder;
using ADO_Data_Access.Enumerations;
using Domain.ModelPOCO;
using Domain;
using Npgsql;

namespace ADO_Data_Access.Repositories
{
    internal class RepositoryADO
    {
        private NpgsqlDataSource DataSource { get; set; }

       
        public RepositoryADO()
        {
            DataSource = DataSourceManager.GetDataSourceManager().GetDataSource(); 
        }
        public List<IDomainPOCO> Retrieve(TableEnum table)
        {
            List<IDomainPOCO> domainObjects = new List<IDomainPOCO>();

            using (NpgsqlConnection connection = DataSource.CreateConnection())
            {
                var command = DataSource.CreateCommand($"SELECT * FROM \"SoleSchema\".\"{Mapping.tableToStringName[table]}\"");
                try
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        domainObjects = DataReaderToListConverter.ConvertToList(reader, table);
                    }
                }
                catch (PostgresException ex) when (ex.SqlState == "42501")
                {
                    Console.WriteLine("Access denied: insufficient privileges.");
                }

            }
                return domainObjects;
        }



        public void Create(IDomainPOCO domainPocoToAdd)
        {
            try
            {
                using (NpgsqlConnection connection = DataSource.CreateConnection())
                {
                    var command = new InsertCommandBuilder().SetDataSource(DataSource).SetTable(Mapping.typeToTable[domainPocoToAdd.GetType()]).BuildInsertionCommand([domainPocoToAdd]);
                    command.ExecuteNonQuery();
                }
            }
            catch (PostgresException ex) when (ex.SqlState == "42501")
            {
                Console.WriteLine("Access denied: insufficient privileges.");
            }
        }

        public void Redact(IDomainPOCO domainPocoToRedact, IDomainPOCO updatedDomainPoco)
        {
            try
            {
                using (NpgsqlConnection connection = DataSource.CreateConnection())
                {
                    var command = new UpdateCommandBuilder().SetDataSource(DataSource).SetTargetDomainObject(domainPocoToRedact).SetUpdatedDomainObject(updatedDomainPoco).Build();
                    command.ExecuteNonQuery();
                }
            }
            catch (PostgresException ex) when (ex.SqlState == "42501")
            {
                Console.WriteLine("Access denied: insufficient privileges.");
            }

        }
        public void Remove(IDomainPOCO domainObjectToRemove)
        {
            using (NpgsqlConnection connection = DataSource.CreateConnection())
            {
                var deletionCommand = new DeleteCommandBuilder().SetDataSource(DataSource).SetTable(Mapping.typeToTable[domainObjectToRemove.GetType()]).SetTargeetDomainObject(domainObjectToRemove).Build();
                deletionCommand.ExecuteNonQuery();
            }
        }
        
    }
}
