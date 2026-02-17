using Microsoft.Extensions.Configuration;
using RFQ.UI.Domain.Helper;
using RFQ.UI.Domain.Interfaces;
using RFQ.UI.Domain.Model;
using RFQ.UI.Domain.RequestDto;
using RFQ.UI.Domain.ResponseDto;

namespace RFQ.UI.Infrastructure.Provider
{
    public class EmployeeAdaptor : IEmployeeAdaptor
    {
        private readonly AppSettingsGlobal _appSettings;
        private readonly CommonApiAdaptor _commonApiAdaptor;
        private readonly GlobalClass _globalClass;

        public EmployeeAdaptor(AppSettingsGlobal appSettings, CommonApiAdaptor commonApiAdaptor, GlobalClass globalClass)
        {
            _appSettings = appSettings;
            _commonApiAdaptor = commonApiAdaptor;
            _globalClass = globalClass;
        }

        public async Task<PageList<EmployeeResponseDto>?> GetAllEmployees(PagingParam pagingParam)
        {
            try
            {
                var baseUrl = _appSettings.BaseUrl + _appSettings.GetAllEmployee;
                var responseModel = await _commonApiAdaptor.PostAsync<CommonResponseDto>(baseUrl, pagingParam, _globalClass.Token);
                return _commonApiAdaptor.GenerateResponse<EmployeeResponseDto>(responseModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> UpdateEmployee(EmployeeUpdateRequestDto request)
        {
            try
            {
                var baseUrl = _appSettings.BaseUrl + _appSettings.UpdateEmployee;

                var responseModel = await _commonApiAdaptor
                    .PutAsync<CommonResponseDto>(
                        baseUrl,
                        request,
                        _globalClass.Token
                    );

                return responseModel != null;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
