using BareEFC_Data_Access.Entities;
using Domain.ModelPOCO;
using Npgsql;

namespace BareEFC_Data_Access.NpgsqlTranslator
{
    internal class NpgsqlEmployeeSexEnumTranslator : INpgsqlNameTranslator
    {
        private Dictionary<string, string> clrToPg = new Dictionary<string, string>()
        {
            {"Male","Мужчина"},
            {"Female","Женщина"}
        };
        public string TranslateMemberName(string clrName)
        {
            return clrToPg[clrName];
        }

        public string TranslateTypeName(string clrName)
        {
            return nameof(EmployeeSexEntityEnum);
        }
    }
}
