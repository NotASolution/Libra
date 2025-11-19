
namespace Domain.ModelPOCO
{
    public class Employee : IDomainPOCO
    {
        private string _passportNumber;
        private string _fullName;
        private string _taxpayerId;
        private string _socialSecurityNumber;
        private EmployeeSexEnum _employeeSex;
        private byte[] _photo;

        public string PassportNumber {  get { return _passportNumber; } set { _passportNumber = value; }}
        public string FullName { get { return _fullName; } set { _fullName = value; }}
        public string TaxpayerId { get { return _taxpayerId; } set {_taxpayerId = value; }}
        public string SocialSecurityNumber { get { return _socialSecurityNumber; } set {_socialSecurityNumber = value; }}
        public EmployeeSexEnum EmployeeSex { get {return _employeeSex;} set {_employeeSex = value; }}
        public byte[] Photo { get { return _photo; } set { _photo = value; }}
    }
}
