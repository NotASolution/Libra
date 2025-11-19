
using BareEFC_Data_Access.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BareEFC_Data_Access.ModelPOCOConfigurations
{
    internal class ReadingRoomConfigurations : IEntityTypeConfiguration<ReadingRoomEntity>
    {
        public void Configure(EntityTypeBuilder<ReadingRoomEntity> entity)
        {
            entity.ToTable("Reading_Room", "SoleSchema");
            entity.Property(room => room.Name).IsRequired().HasColumnName("room_name").HasColumnType("varchar(100)");
            entity.HasKey(room => room.RoomNumber);
            entity.Property(room => room.RoomNumber).IsRequired().HasColumnName("room_no").HasColumnType("int4");
            entity.Property(room => room.Capacity).HasColumnName("capacity").HasColumnType("int4");

            entity.HasIndex(room => room.Name).IsUnique();

        }
    }
}
