using BareEFC_Data_Access.Entities;
using Domain.ModelPOCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BareEFC_Data_Access.ModelPOCO
{
    internal class BookConfigurations : IEntityTypeConfiguration<BookEntity>
    {
        public void Configure(EntityTypeBuilder<BookEntity> entity)
        {
            /*
            var genreToString = new Dictionary<GenreEnum, string>
            {
                 { GenreEnum.History, "История" },
                 { GenreEnum.NonFiction, "Научпоп" },
                 { GenreEnum.Fiction, "Художественная литература" },
                 { GenreEnum.Textbook, "Учебное пособие"},
                 { GenreEnum.ForKids, "Для детей" }
            };

            var stringToGenre = genreToString.ToDictionary(kvp => kvp.Value, kvp => kvp.Key);

            var genreConverter = new ValueConverter<GenreEnum, string>(
                v => genreToString[v],  // Convert Genre → String
                v => stringToGenre[v]   // Convert String → Genre
            );

            */

            entity.ToTable("Books", "SoleSchema");
            entity.HasKey(book => book.Cipher);
            //entity.Property(book => book.Genre).HasConversion(genreConverter);
            entity.Property(book => book.Genre).IsRequired().HasColumnName("book_genre");
            entity.Property(book => book.Cipher).IsRequired().HasColumnName("sypher").HasColumnType("varchar(10)");
            entity.Property(book => book.Author).IsRequired().HasColumnName("author").HasColumnType("text");
            entity.Property(book => book.Publisher).IsRequired().HasColumnName("publisher").HasColumnType("text");
            entity.Property(book => book.DateOfPublishing).IsRequired().HasColumnName("date_of_publishing").HasColumnType("date");
            entity.Property(book => book.Amount).IsRequired().HasColumnName("amount").HasColumnType("int4");
            entity.Property(book => book.Title).IsRequired().HasColumnName("title").HasColumnType("text");
        }
    }
}
