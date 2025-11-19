using Domain.ModelPOCO;

namespace BareEFC_Data_Access.Entities
{
    public class EmployeeEntity : IEntity
    {
        public string PassportNumber { get; set; }
        public string FullName { get; set; }
        public string TaxpayerId { get; set; }
        public string SocialSecurityNumber { get; set; }
        public EmployeeSexEnum EmployeeSex { get; set; }
        public byte[] Photo { get; set; }

        public ICollection<BookLeaseEntity> LeasesOnEmployee;
        public Type PriamryKeyType { get { return PassportNumber.GetType(); } }

        public object PrimaryKey => throw new NotImplementedException();

    }
}
