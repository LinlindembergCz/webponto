using Abp.Domain.Entities;
using Abp.Events.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebPonto.Domain.Aggregates.PersonAggregate
{

    public partial class Person 
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}
