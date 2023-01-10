using Microsoft.EntityFrameworkCore;
using PersonLogin.DataAccess.Abstract;
using PersonLogin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLogin.DataAccess.Concrete
{
    public class PersonRepository : IPersonRepository
    {
        public async Task<Person> Create(Person person)
        {
            using (var context=new PersonContext())
            {
                context.Persons.Add(person);
               await context.SaveChangesAsync();
                return person;
            }
        }

        public async Task Delete(int id)
        {
            using (var context= new PersonContext())
            {
                var deletedPerson = context.Persons.Find(id);
                context.Persons.Remove(deletedPerson);
                await context.SaveChangesAsync();
            }
        }

        public async Task< List<Person>> GetAll()
        {
            using (var context=new PersonContext())
            {
                return await context.Persons.ToListAsync();
              
                
            }
        }

        public async Task< Person> GetById(int id)
        {
            using (var context= new PersonContext())
            {
               return await context.Persons.FindAsync(id);
            }
        }

        public async Task<Person> GetByName(string name)
        {
            using (var context= new PersonContext())
            {
                return await context.Persons.FirstOrDefaultAsync(p=>p.Name.ToLower()==name.ToLower());
            }
        }

        public async Task<Person> Update(Person person)
        {
            using (var context=new PersonContext())
            {
                context.Update(person);
               await context.SaveChangesAsync();
                return person;
            }
        }
    }
}
