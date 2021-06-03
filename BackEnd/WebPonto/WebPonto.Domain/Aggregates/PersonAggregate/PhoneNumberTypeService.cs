using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebPonto.Domain.Aggregates.PersonAggregate.Interfaces;

namespace WebPonto.Domain.Aggregates.PersonAggregate
{
    public class PhoneNumberTypeService : IPhoneNumberTypeService
    {
        private readonly IPhoneNumberTypeRepository _phoneNumberTypeRepository;
        public PhoneNumberTypeService(IPhoneNumberTypeRepository phoneNumberTypeRepository)
        {
            _phoneNumberTypeRepository = phoneNumberTypeRepository;

        }

        public async Task<List<PhoneNumberType>> FindAllAsync() => (await _phoneNumberTypeRepository.FindAllAsync()).ToList();
    }
}
