
using BareEFC_Data_Access.Entities;
using Domain.ModelPOCO;

namespace BareEFC_Data_Access
{
    internal class DomainObjectFactory
    {
        private delegate IDomainPOCO Create(IEntity entity);
        private Dictionary<Type, Create> creationDictionary = new Dictionary<Type, Create>();

        public DomainObjectFactory() 
        {
            creationDictionary.Add(typeof(BookEntity), CreateBook);
            creationDictionary.Add(typeof(BookTokenEntity), CreateBookToken);
            creationDictionary.Add(typeof(BookLeaseEntity), CreateBookLease);
            creationDictionary.Add(typeof(MemberEntity),CreateMember);
            creationDictionary.Add(typeof(ReadingRoomEntity), CreateReadingRoom);
            creationDictionary.Add(typeof(EmployeeEntity), CreateEmployee);
        }
        

        public IDomainPOCO CreateDomainPOCO(IEntity entity)
        {   

            return creationDictionary[entity.GetType()](entity);
        }

        private IDomainPOCO CreateBook(IEntity entity)
        {

            BookEntity bookEntity = entity as BookEntity;
            Book book = new Book();

            book.Cipher = bookEntity.Cipher;
            book.Author = bookEntity.Author;
            book.Publisher = bookEntity.Publisher;
            book.Amount = bookEntity.Amount;
            book.DateOfPublishing = bookEntity.DateOfPublishing;

            return book;
        }

        private IDomainPOCO CreateBookToken(IEntity entity)
        {
            BookTokenEntity bookTokenEntity = entity as BookTokenEntity;
            BookToken bookToken = new BookToken();

            bookToken.TokenCipher = bookTokenEntity.TokenCipher;
            bookToken.TokenId = bookTokenEntity.TokenId;
            bookToken.RoomNumber = bookTokenEntity.RoomNumber;
            bookToken.IsTaken = bookTokenEntity.IsTaken;
            
            return bookToken;
        }

        private IDomainPOCO CreateBookLease(IEntity entity)
        {
            BookLeaseEntity bookLeaseEntity = entity as BookLeaseEntity;
            BookLease bookLease = new BookLease();

            bookLease.TokenId = bookLeaseEntity.TokenId;
            bookLease.LesseeId = bookLeaseEntity.LesseeId;
            bookLease.SumOfFine = bookLeaseEntity.SumOfFine;
            bookLease.DateOfInitiation = bookLeaseEntity.DateOfInitiation;
            bookLease.DateOfClosure = bookLeaseEntity.DateOfClosure;
            bookLease.FactualDateOfClosure = bookLeaseEntity.FactualDateOfClosure;
            
            return bookLease;
        }

        private IDomainPOCO CreateMember(IEntity entity)
        {
            MemberEntity memberEntity = entity as MemberEntity;
            Member member = new Member();

            member.MemberId = memberEntity.MemberId;
            member.Address = memberEntity.Address;
            member.TelephoneNumber = memberEntity.TelephoneNumber;
            member.PassportNumber = memberEntity.PassportNumber;
            member.Birthdate = memberEntity.Birthdate;
            member.Education = memberEntity.Education;
            member.FullName = memberEntity.FullName;

            return member;
        }

        private IDomainPOCO CreateReadingRoom(IEntity entity)
        {
            ReadingRoomEntity readingRoomEntity = new ReadingRoomEntity();
            ReadingRoom readingRoom = new ReadingRoom();

            readingRoom.RoomNumber = readingRoomEntity.RoomNumber;
            readingRoom.Name = readingRoomEntity.Name;
            readingRoom.Capacity = readingRoomEntity.Capacity;

            return readingRoom;
        }

        private IDomainPOCO CreateEmployee(IEntity entity)
        {
            EmployeeEntity employeeEntity = entity as EmployeeEntity;
            Employee employee = new Employee();

            employee.TaxpayerId = employeeEntity.TaxpayerId;
            employee.PassportNumber = employeeEntity.PassportNumber;
            employee.FullName = employeeEntity.FullName;
            employee.SocialSecurityNumber = employeeEntity.SocialSecurityNumber;
            employee.EmployeeSex = employeeEntity.EmployeeSex;
            employee.Photo = employeeEntity.Photo;
            
            return employee;
        }
    }
}
