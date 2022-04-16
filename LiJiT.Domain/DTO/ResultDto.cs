using System;
using System.Collections.Generic;

namespace LiJiT.Domain.DTO
{
    public class ResultDto<T> :BaseResponse
    {
        public T Data { get; set; }
    }
}
