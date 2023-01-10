using PersonLogin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLogin.Business.Abstract
{
    public interface IPersonService
    {
        Task<List<Person>> GetAllPersons();
        Task<Person> GetByIdPerson(int id);
        Task<Person> GetByNamePerson(string name);
        Task<Person> PersonCreate(Person person);
        Task<Person> PersonUpdate(Person person);
        Task PersonDelete(int id);
    }
}
