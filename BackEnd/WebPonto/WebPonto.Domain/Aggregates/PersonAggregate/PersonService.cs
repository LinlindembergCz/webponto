using WebPonto.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPonto.Domain.Aggregates.PersonAggregate
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;

        }

        public async Task<List<Person>> FindAllAsync() => (await _personRepository.FindAllAsync()).ToList();

        public  Person FindById(int id) => ( _personRepository.FindById(id));

        public void Create(Person entity)
        {
            _personRepository.Create(entity);
        }

        public void Modify(Person entity)
        {
            _personRepository.Modify(entity);
        }

        public void Delete(int id)
        {
            _personRepository.Delete(id);
        }

    }
}
