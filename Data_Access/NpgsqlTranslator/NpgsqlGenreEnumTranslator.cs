using BareEFC_Data_Access.Entities;
using Domain.ModelPOCO;
using Npgsql;

namespace BareEFC_Data_Access.NpgsqlTranslator
{
    internal class NpgsqlGenreEnumTranslator : INpgsqlNameTranslator
    {
        private Dictionary<string,string> clrToPg = new Dictionary<string, string>()
        {
            {"NonFiction","Научпоп"},
            {"History","История"},
            {"Textbook","Учебное пособие"},
            {"Fiction", "Художественная литература"},
            {"ForKids","Для детей"}
        };
        public string TranslateMemberName(string clrName)
        {
           return clrToPg[clrName];
        }

        public string TranslateTypeName(string clrName)
        {
            return nameof(GenreEntityEnum);
        }
    }
}
