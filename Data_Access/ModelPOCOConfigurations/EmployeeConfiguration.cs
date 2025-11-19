using BareEFC_Data_Access.Entities;
using Domain.ModelPOCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BareEFC_Data_Access.ModelPOCOConfigurations
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<EmployeeEntity>
    {
        public void Configure(EntityTypeBuilder<EmployeeEntity> entity)
        {

            Dictionary<EmployeeSexEnum, string> sexToString = new Dictionary<EmployeeSexEnum, string>()
            {
               {EmployeeSexEnum.Male, "Мужчина"},
               {EmployeeSexEnum.Female, "Женщина"}
            };

            Dictionary<string, EmployeeSexEnum> stringToSex = sexToString.ToDictionary(pair => pair.Value, pair => pair.Key);

            var sexConverter = new ValueConverter<EmployeeSexEnum, string>(
               v => sexToString[v],
               v => stringToSex[v]
           );

            entity.ToTable("Employees", "SoleSchema");
            entity.HasKey(emp => emp.PassportNumber);
            entity.Property(emp => emp.PassportNumber).HasColumnName("passport_no").HasColumnType("varchar(9)");
            entity.Property(emp => emp.EmployeeSex).HasConversion(sexConverter).HasColumnName("employee_sex");
            entity.Property(emp => emp.PassportNumber).HasColumnType("varchar(9)");
            entity.Property(emp => emp.FullName).IsRequired().HasColumnName("fullname").HasColumnType("varchar(50)");
            entity.Property(emp => emp.TaxpayerId).IsRequired().HasColumnName("taxpayer_id").HasColumnType("varchar(12)");
            entity.Property(emp => emp.SocialSecurityNumber).IsRequired().HasColumnName("social_security_no").HasColumnType("varchar(15)");
            entity.Property(emp => emp.Photo).HasColumnName("photo").HasColumnType("bytea");

            entity.HasIndex(emp => emp.PassportNumber).IsUnique();
            entity.HasIndex(emp => emp.TaxpayerId).IsUnique();
        }
    }
    }

