using PersonLogin.Business.Abstract;
using PersonLogin.DataAccess.Abstract;
using PersonLogin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLogin.Business.Concrete
{
    public class PersonManager : IPersonService
    {
        private IPersonRepository _personRepository;

        public PersonManager(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task< List<Person> >GetAllPersons()
        {
            return await _personRepository.GetAll();
        }

        public async  Task<Person> GetByIdPerson(int id)
        {
            return await _personRepository.GetById(id);
        }

        public async Task<Person> GetByNamePerson(string name)
        {
            return await _personRepository.GetByName(name);
        }

        public async Task<Person> PersonCreate(Person person)
        {
            return await _personRepository.Create(person);
        }

        public async Task PersonDelete(int id)
        {
           await _personRepository.Delete(id);
        }

        public async Task<Person> PersonUpdate(Person person)
        {
           return await _personRepository.Update(person);
        }
    }
}
