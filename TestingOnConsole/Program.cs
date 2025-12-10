using ADO_Data_Access.CommandBuilder;
using Domain;
using Domain.ModelPOCO;
using ADO_Data_Access.Enumerations;
using Npgsql;
using ADO_Data_Access;
using BareEFC_Data_Access;
namespace TestingOnConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRepository repository = new Repository();
            AddBook(repository);
        }
        private static void AddBook(IRepository repo)
        {
            BookBuilder kek= new BookBuilder().AddCipher("IWANTBETR!").AddAuthor("James Rum").AddTitle("How to party in a pirate manner")
                                       .AddPublisher("Unoficial Crew").AddGenre(GenreEnum.Textbook).AddDateOfPublishing(DateTime.Now);

            Book lol = kek.AddCipher("Scandalous").Build();

            repo.Add(lol);
        }
        
        private static void PrintInsertionString(List<IDomainPOCO> domainPocos)
        {
            InsertStringBuilder commandBuilder = new InsertStringBuilder();
            Console.WriteLine(commandBuilder.SetTargetTable(TableEnum.Books).AssertValues(domainPocos).Build());
        }

        private static void GetInsertionNpgsqlCommand(List<IDomainPOCO> domainObjects)
        {
            var dataSourceBuilder = new NpgsqlDataSourceBuilder("Host=localhost;Username=test;Password=test");
            var dataSource = dataSourceBuilder.Build();
           
            InsertCommandBuilder commandBuilder = new InsertCommandBuilder();
            var command = commandBuilder.SetDataSource(dataSource).SetTable(TableEnum.ReadingRooms).BuildInsertionCommand(domainObjects);
            
            dataSource.Dispose();
        }


        private static void AddBookWithInsertionString(List<IDomainPOCO> domainPocos)
        {
            var dataSource = DataSourceManager.GetDataSourceManager().GetDataSource();

            InsertCommandBuilder commandBuilder = new InsertCommandBuilder();
            var command = commandBuilder.SetDataSource(dataSource).SetTable(TableEnum.Books).BuildInsertionCommand(domainPocos);

            command.ExecuteNonQuery();
        }
    }


}
