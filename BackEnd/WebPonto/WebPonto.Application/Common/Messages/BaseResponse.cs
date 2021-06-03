using System.Collections.Generic;

namespace WebPonto.Application.Common.Messages
{
    public abstract class BaseResponse
    {
        public bool Success { get; set; } = true;

        public IEnumerable<object> Errors { get; set; } = null;
    }
}
