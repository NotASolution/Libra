
using Domain.ModelPOCO;

namespace WindowsFormsUI
{
    public interface IAdditionRedactionHost
    {
        void AcceptDomainObject(IDomainPOCO domainObject, bool isAddition);
    }
}
