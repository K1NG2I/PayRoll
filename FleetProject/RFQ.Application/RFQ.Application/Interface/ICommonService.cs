using RFQ.Domain.RequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFQ.Application.Interface
{
    public interface ICommonService
    {
        Task<string> GetAutoGenerateCode(AutoGenerateCodeRequestDto requestDto);
    }
}
