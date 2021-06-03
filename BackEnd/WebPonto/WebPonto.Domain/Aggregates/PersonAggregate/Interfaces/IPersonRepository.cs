using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebPonto.Domain.Aggregates.PersonAggregate.Interfaces
{ 
    public interface IPersonRepository
    {
        //Task<IEnumerable<PersonAggregate.Person>> FindAllAsync();

        Task<ICollection<Person>> FindAllAsync();

        PersonAggregate.Person FindById(int id);

        void Create(Person entity);

        void Modify(Person entity);

        void Delete(int id);
    }
}
