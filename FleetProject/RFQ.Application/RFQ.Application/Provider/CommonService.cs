using RFQ.Application.Interface;
using RFQ.Domain.Interfaces;
using RFQ.Domain.RequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFQ.Application.Provider
{
    public class CommonService : ICommonService
    {
        private readonly ICommonRepositroy _commonRepositroy;
        public CommonService(ICommonRepositroy commonRepositroy)
        {
            _commonRepositroy = commonRepositroy;
        }

        public async Task<string> GetAutoGenerateCode(AutoGenerateCodeRequestDto requestDto)
        {
            return await _commonRepositroy.GetAutoGenerateCode(requestDto);
        }
    }
}
