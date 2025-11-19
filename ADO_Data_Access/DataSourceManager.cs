using ADO_Data_Access.NpgsqlTranslator;
using Domain.ModelPOCO;
using Npgsql;

namespace ADO_Data_Access
{
    public static class DataSourceManager
    {
        private static NpgsqlDataSource dataSource;
        private static string connectionString = "Host=localhost;Port=5432;Database=DBCourse_Spring;Username=postgres;Password=Ancient88Kedr"; 

        static DataSourceManager()
        {
            NpgsqlDataSourceBuilder dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);
            dataSourceBuilder.MapEnum<EmployeeSexEnum>("\"SoleSchema\".sex", new NpgsqlEmployeeSexEnumTranslator());
            dataSourceBuilder.MapEnum<GenreEnum>("\"SoleSchema\".genre", new NpgsqlGenreEnumTranslator());
            dataSource = dataSourceBuilder.Build();
        }
        public static NpgsqlDataSource GetDataSource()
        {
            return dataSource;
        }
    }
}
