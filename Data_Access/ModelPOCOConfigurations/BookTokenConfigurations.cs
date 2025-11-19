using BareEFC_Data_Access.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BareEFC_Data_Access.ModelPOCO
{
    internal class BookTokenConfigurations : IEntityTypeConfiguration<BookTokenEntity>
    {
        public void Configure(EntityTypeBuilder<BookTokenEntity> entity)
        {
            entity.ToTable("Book_Tokens", "SoleSchema");
            entity.HasKey(token => token.TokenId);
            entity.Property(token => token.TokenId).HasColumnName("token_id").HasColumnType("int4");
            entity.Property(token => token.TokenCipher).HasColumnName("sypher").HasColumnType("varchar");
            entity.HasOne(token => token.Book).WithMany(book => book.BookTokens).HasForeignKey(token => token.TokenCipher).HasConstraintName("book_sypher_fk");
            entity.HasOne(token => token.ReadingRoom).WithMany(room => room.BookTokens).HasForeignKey(token => token.RoomNumber).HasConstraintName("room_number_fk");
            entity.Property(token => token.IsTaken).HasColumnName("taken").HasColumnType("bool").IsRequired();
            entity.Property(token => token.RoomNumber).HasColumnName("room_no").HasColumnType("int4");
        }
    }
}
