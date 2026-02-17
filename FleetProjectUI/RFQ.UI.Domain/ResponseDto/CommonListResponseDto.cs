using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFQ.UI.Domain.ResponseDto
{
    public class CommonListResponseDto<T>
    {
        public int StatusCode { get; set; }
        public List<T> Data { get; set; } = new List<T>();
        public string? Message { get; set; }
        public string? ErrorMessage { get; set; }
    }

}
