using ADO_Data_Access.NpgsqlTranslator;
using Domain.ModelPOCO;
using Npgsql;

namespace ADO_Data_Access
{
    public class DataSourceManager
    {/*
        private static NpgsqlDataSource dataSource;
        private static NpgsqlDataSourceBuilder builder;
        private static string Username;
        private static string Password;
        private static string connectionString; 

        public static NpgsqlDataSource GetDataSource()
        {
            dataSource = builder.Build();
            return dataSource;
        }
        public static void SetNameAndPassword(string username, string password)
        {
            Username = username;
            Password = password;
            connectionString = $"Host=localhost;Port=5432;Database=DBCourse_Spring;Username={Username};Password={Password}";
            builder = new NpgsqlDataSourceBuilder(connectionString);
            builder.MapEnum<EmployeeSexEnum>("SoleSchema.sex", new NpgsqlEmployeeSexEnumTranslator());
            builder.MapEnum<GenreEnum>("SoleSchema.genre", new NpgsqlGenreEnumTranslator());
        }*/

        private NpgsqlDataSource dataSource;
        private Dictionary<string, string> usernameToPassword = new Dictionary<string, string>()
        {
            { "superuser", "password1"},
            { "library_member", "user_pass"},
            { "library_employee", "employee_pass"}
        };
        private NpgsqlDataSourceBuilder builder;
        private string Username;
        private string Password;
        private string connectionString;

        private static DataSourceManager instance;

        public static DataSourceManager GetDataSourceManager()
        {
            if (instance == null)
            { 
                instance = new DataSourceManager();
            }
            return instance;
        }

        public bool SetUsernameAndPassword(string username, string password)
        {
            if (usernameToPassword.Keys.Contains(username) && usernameToPassword[username] == password)
            {
                Username = username;
                Password = password;

                connectionString = $"Host=localhost;Port=5432;Database=DBCourse_Spring;Username={Username};Password={Password}";
                return true;
            }
            return false;
        }

        public NpgsqlDataSource GetDataSource()
        {
            if (Username == null || Password == null) throw new Exception("UnAuthorized user, please, check DataSourceManager");

            if (dataSource == null)
            {
                
                builder = new NpgsqlDataSourceBuilder(connectionString);
                builder.MapEnum<EmployeeSexEnum>("SoleSchema.sex", new NpgsqlEmployeeSexEnumTranslator());
                builder.MapEnum<GenreEnum>("SoleSchema.genre", new NpgsqlGenreEnumTranslator());
                dataSource = builder.Build();
            }
            
                return dataSource;
        }
    }
}
