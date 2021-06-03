using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebPonto.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneRepository
    {
        Task<IEnumerable<PersonAggregate.PersonPhone>> FindAllAsync();
    }
}
