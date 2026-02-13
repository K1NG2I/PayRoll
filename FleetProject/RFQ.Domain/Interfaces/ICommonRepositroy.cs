using RFQ.Domain.Helper;
using RFQ.Domain.RequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFQ.Domain.Interfaces
{
    public interface ICommonRepositroy
    {
        Task<PageList<T>> GetAllRecordsFromStoredProcedure<T>(string SpName, PagingParam pagingParam) where T : class, new();
        Task<string> GetAutoGenerateCode(AutoGenerateCodeRequestDto requestDto);
    }
}
