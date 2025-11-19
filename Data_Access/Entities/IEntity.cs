using Domain.ModelPOCO;
using System.Reflection.Metadata;

namespace BareEFC_Data_Access.Entities
{
    internal interface IEntity
    {
        public Type PriamryKeyType {  get; }
        public object PrimaryKey {  get; }
        

    }
}
