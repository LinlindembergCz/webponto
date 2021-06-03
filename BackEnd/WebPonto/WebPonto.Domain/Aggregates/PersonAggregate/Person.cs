using Abp.Domain.Entities;
using Abp.Events.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebPonto.Domain.Aggregates.PersonAggregate
{

    public partial class Person 
    {
        public int BusinessEntityID { get; set; }

        public string Name { get; set; }

        public ICollection<PersonPhone> Phones { get; set; }

        public ICollection<IEventData> DomainEvents => throw new NotImplementedException();
    }
}
