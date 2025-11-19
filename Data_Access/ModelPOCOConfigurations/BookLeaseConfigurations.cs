using BareEFC_Data_Access.Entities;
using Domain.ModelPOCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BareEFC_Data_Access.ModelPOCOConfigurations
{
    internal class BookLeaseConfigurations : IEntityTypeConfiguration<BookLeaseEntity>
    {
        public void Configure(EntityTypeBuilder<BookLeaseEntity> entity)
        {
            entity.ToTable("Book_Lease", "SoleSchema");
            entity.HasKey(lease => lease.TokenId);
            entity.HasOne(lease => lease.LesseeMember).WithMany(lessee => lessee.Leases).HasForeignKey(lease => lease.LesseeId).HasConstraintName("lessee_id_fk");
            entity.HasOne(lease => lease.BookTokenInLease).WithOne().HasForeignKey<BookLeaseEntity>(lease => lease.TokenId).HasConstraintName("book_id_fk");
            entity.Property(lease => lease.DateOfInitiation).HasColumnName("date_of_initiation").HasColumnType("timestamp"); 
            entity.Property(lease => lease.DateOfClosure).HasColumnName("date_of_closure").HasColumnType("timestamp");
            entity.Property(lease => lease.FactualDateOfClosure).HasColumnName("date_of_closure_fact").HasColumnType("timestamp");
            entity.HasOne(lease => lease.Employee).WithMany(emp => emp.LeasesOnEmployee).HasForeignKey(lease => lease.ResponsibleEmployee).HasConstraintName("responsible_employee_id_fk");

        }
    }
}
