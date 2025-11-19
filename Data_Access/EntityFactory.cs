using BareEFC_Data_Access.Entities;
using Domain.ModelPOCO;

namespace BareEFC_Data_Access
{
    internal class EntityFactory
    {
        private delegate IEntity Create(IDomainPOCO domainPOCO);
        private Dictionary<Type, Create> createDictionary = new Dictionary<Type,Create>();

        private static Dictionary<Type, Type> typeDictionary = new Dictionary<Type, Type>()
        {
            {typeof(Book), typeof(BookEntity)},
            {typeof(BookToken), typeof(BookTokenEntity)},
            {typeof(BookLease), typeof(BookLeaseEntity)},
            {typeof(Member), typeof(MemberEntity)},
            {typeof(ReadingRoom), typeof(ReadingRoomEntity)},
            {typeof(Employee), typeof(EmployeeEntity)},
        };

        public EntityFactory()
        {
            createDictionary.Add(typeof(Book), CreateBook);
            createDictionary.Add(typeof(BookToken), CreateBookToken);
            createDictionary.Add(typeof(BookLease), CreateBookLease);
            createDictionary.Add(typeof(ReadingRoom), CreateReadingRoom);
        }

        public static Type GetEntityType(Type domainPOCOType)
        {
            return typeDictionary[domainPOCOType];
        }
        public IEntity CreateEntity(IDomainPOCO domainPoco)
        {
            return createDictionary[domainPoco.GetType()](domainPoco);
        }

        private IEntity CreateBook(IDomainPOCO domainPOCO)
        {
            Book book = domainPOCO as Book;

            BookEntity bookEntity = new BookEntity();
            bookEntity.Cipher = book.Cipher;
            bookEntity.Title = book.Title;
            bookEntity.Author = book.Author;
            bookEntity.Publisher = book.Publisher;
            bookEntity.Amount = book.Amount;

            return bookEntity;
        }

        private IEntity CreateBookToken(IDomainPOCO domainPOCO)
        {
            BookToken bookToken = domainPOCO as BookToken;
            BookTokenEntity bookTokenEntity = new BookTokenEntity();

            bookTokenEntity.TokenCipher = bookToken.TokenCipher;
            bookTokenEntity.TokenId = bookToken.TokenId;
            bookTokenEntity.IsTaken = bookToken.IsTaken;
            bookTokenEntity.RoomNumber = bookToken.RoomNumber;

            return bookTokenEntity;
        }

        private IEntity CreateBookLease(IDomainPOCO domainPOCO)
        {
            BookLease bookLease = domainPOCO as BookLease;
            BookLeaseEntity bookLeaseEntity = new BookLeaseEntity();
           
            bookLeaseEntity.TokenId = bookLease.TokenId;
            bookLeaseEntity.LesseeId = bookLease.LesseeId;
            bookLeaseEntity.DateOfInitiation = bookLease.DateOfInitiation;
            bookLeaseEntity.DateOfClosure = bookLease.DateOfClosure;
            bookLeaseEntity.FactualDateOfClosure = bookLease.FactualDateOfClosure;
            bookLeaseEntity.SumOfFine = bookLease.SumOfFine;
            bookLeaseEntity.ResponsibleEmployee = bookLease.ResponsibleEmployee;

            return bookLeaseEntity;
        }

        private IEntity CreateMember(IDomainPOCO domainPOCO)
        {
            MemberEntity memberEntity = new MemberEntity();
            return memberEntity;
        }

        private IEntity CreateReadingRoom(IDomainPOCO domainPOCO)
        {
            ReadingRoomEntity readingRoomEnitity = new ReadingRoomEntity();
            ReadingRoom readingRoom = domainPOCO as ReadingRoom;

            readingRoomEnitity.Name = readingRoom.Name;
            readingRoomEnitity.Capacity = readingRoom.Capacity;
            readingRoomEnitity.RoomNumber = readingRoom.RoomNumber;

            return readingRoomEnitity;
        }

        private IEntity CreateEmployee(IDomainPOCO domainPOCO)
        {
            EmployeeEntity employeeEntity = new EmployeeEntity();
            return employeeEntity;
        }
    }
}
