using WebPonto.Application.Common.Messages;
using WebPonto.Application.Dtos;
using System.Collections.Generic;

namespace WebPonto.Application.Messages.Response
{
    public class PersonResponse : BaseResponse
    {
        public List<PersonDto> PersonObjects { get; set; }
    }
}
