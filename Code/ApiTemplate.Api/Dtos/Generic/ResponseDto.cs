using System.Collections.Generic;

namespace ApiTemplate.Api.Dtos.Generic
{
    public class ResponseDto<T>
    {
        public T Result { get; set; }

        public bool Succeeded { get; set; }

        public List<string> Warnings { get; set; }

        public List<string> Errors { get; set; }
    }
}