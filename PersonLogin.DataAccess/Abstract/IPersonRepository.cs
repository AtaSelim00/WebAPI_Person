using PersonLogin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLogin.DataAccess.Abstract
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetAll();
        Task<Person> GetById(int id);
        Task<Person> GetByName(string name);
        Task<Person> Create(Person person);
        Task<Person> Update(Person person);
        Task Delete(int id);
    }
}
