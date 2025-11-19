using BareEFC_Data_Access.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BareEFC_Data_Access.ModelPOCOConfigurations
{
    internal class MemberConfiguration : IEntityTypeConfiguration<MemberEntity>
    {
        public void Configure(EntityTypeBuilder<MemberEntity> entity)
        {
            entity.ToTable("Members", "SoleSchema");
            entity.HasKey(member => member.MemberId);
            entity.Property(member => member.MemberId).HasColumnName("member_id_no").HasColumnType("varchar(8)");
            entity.Property(member => member.ReadingRoomNumber).HasColumnName("reading_room_number").HasColumnType("int4");
            entity.Property(member => member.PassportNumber).IsRequired().HasColumnName("passport_no").HasColumnType("varchar");
            entity.Property(member => member.Birthdate).IsRequired().HasColumnName("birth_date").HasColumnType("date");
            entity.Property(member => member.Address).IsRequired().HasColumnName("address").HasColumnType("text");
            entity.Property(member => member.TelephoneNumber).IsRequired().HasColumnName("telephone_no").HasColumnType("varchar");
            entity.Property(member => member.Education).IsRequired().HasColumnName("education").HasColumnType("varchar");
            entity.HasOne(member => member.ReadingRoom).WithMany(room => room.Members).HasForeignKey(member => member.ReadingRoomNumber).HasConstraintName("room_number_fk");
            entity.Property(member => member.Photo).HasColumnName("photo").HasColumnType("bytea");
            entity.Property(member => member.FullName).HasColumnName("fullname").HasColumnType("varchar(50)");

            entity.HasIndex(member => member.PassportNumber).IsUnique();
            entity.HasIndex(member => member.TelephoneNumber).IsUnique();
        }
    }
}
