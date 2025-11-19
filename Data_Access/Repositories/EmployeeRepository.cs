
using BareEFC_Data_Access.Entities;
using Data_Access;
using Microsoft.EntityFrameworkCore;

namespace BareEFC_Data_Access.Repositories
{
    internal class EmployeeRepository : IEntityRepository
    {
        public void Add(IEntity entityToAdd)
        {
            using (LibraryContext context = new LibraryContext())
            {
                if (context.Employees.Any(ent => ent.PassportNumber == entityToAdd.PrimaryKey)) throw new Exception("Employee with such passport number already exists");

                context.Employees.Add((EmployeeEntity)entityToAdd);

                context.SaveChanges();
            }
        }

        public void Redact(IEntity entityToUpdate, IEntity updatedEntity)
        {

            using (LibraryContext context = new LibraryContext())
            {
                
            }
        }

        public IEntity Remove(IEntity entityToRemove)
        {
            EmployeeEntity entity;

            using (LibraryContext context = new LibraryContext())
            {
                entity = context.Employees.Where(en => en.PassportNumber == (string)entityToRemove.PrimaryKey).Include(en => en.LeasesOnEmployee).SingleOrDefault();
                var inheritingEmployee = context.Employees.Include(emp => emp.LeasesOnEmployee).OrderByDescending(emp => emp.LeasesOnEmployee.Count).Last();

                foreach (var lease in entity.LeasesOnEmployee)  inheritingEmployee.LeasesOnEmployee.Add(lease);

                context.Remove(entity);

                context.SaveChanges();
            }

            return entityToRemove;
        }

        public List<IEntity> Retrieve()
        {
            List<IEntity> entities;

            using (LibraryContext context = new LibraryContext())
            {
                entities = context.Employees.AsNoTracking().Cast<IEntity>().ToList();
            }

                return entities;
        }


    }
}
