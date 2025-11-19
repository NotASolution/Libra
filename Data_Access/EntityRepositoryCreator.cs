using BareEFC_Data_Access.Entities;
using BareEFC_Data_Access.Repositories;

namespace BareEFC_Data_Access
{
    internal static class EntityRepositoryCreator
    {
        private static Dictionary<Type, Func<IEntityRepository>> typeToRepository = new Dictionary<Type, Func<IEntityRepository>>()
        {
            { typeof(BookEntity), () => new BookRepository()},
            { typeof(BookTokenEntity), () => new BookTokenRepository()},
            { typeof(BookLeaseEntity), () => new BookLeaseRepository()},
            { typeof(MemberEntity), () => new MemberRepository()},
            { typeof(ReadingRoomEntity), () => new ReadingRoomRepository()},
            { typeof(EmployeeEntity), () => new EmployeeRepository()}
        };
        public static IEntityRepository CreateRepository(Type type)
        {
            return typeToRepository[type]();
        }
    }
}
