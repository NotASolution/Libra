using BareEFC_Data_Access.Entities;
using BareEFC_Data_Access.ModelPOCO;
using BareEFC_Data_Access.ModelPOCOConfigurations;
using BareEFC_Data_Access.NpgsqlTranslator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace Data_Access
{
    public class LibraryContext: DbContext 
    {
        private static readonly NpgsqlDataSource dataSource;

        public DbSet<BookEntity> Books { get; set; }
        public DbSet<BookTokenEntity> BookTokens { get; set; }
        public DbSet<BookLeaseEntity> BookLeases { get; set; }
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<MemberEntity> Members { get; set; }
        public DbSet<ReadingRoomEntity> ReadingRooms { get; set; }

        static LibraryContext()
        {
            var builder = new NpgsqlDataSourceBuilder("Host=localhost;Port=5432;Database=DBCourse_Spring;Username=postgres;Password=Ancient88Kedr");
            builder.MapEnum<GenreEntityEnum>("SoleSchema.genre", new NpgsqlEmployeeSexEnumTranslator());
            builder.MapEnum<EmployeeSexEntityEnum>("SoleSchema.genre", new NpgsqlGenreEnumTranslator());
            dataSource = builder.Build();
        }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(dataSource)
                          .LogTo(Console.WriteLine, LogLevel.Information);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfigurations());
            modelBuilder.ApplyConfiguration(new BookLeaseConfigurations());
            modelBuilder.ApplyConfiguration(new BookTokenConfigurations());
            modelBuilder.ApplyConfiguration(new MemberConfiguration());
            modelBuilder.ApplyConfiguration(new ReadingRoomConfigurations());
            
            modelBuilder.HasPostgresEnum<EmployeeSexEntityEnum>();
            modelBuilder.HasPostgresEnum<GenreEntityEnum>();
        }

    }
}
