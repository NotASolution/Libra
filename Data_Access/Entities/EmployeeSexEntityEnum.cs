using NpgsqlTypes;

namespace BareEFC_Data_Access.Entities 
{
    public enum EmployeeSexEntityEnum
    {
        [PgName("Мужчина")]
        Male,
        [PgName("Женщина")]
        Female
    }
}