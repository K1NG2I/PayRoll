using RFQ.UI.Domain.Helper;
using RFQ.UI.Domain.Interfaces;
using RFQ.UI.Domain.Model;
using RFQ.UI.Domain.RequestDto;
using RFQ.UI.Domain.ResponseDto;

namespace RFQ.UI.Infrastructure.Provider
{
    public class ContactPersonDetailsAdaptor : IContactPersonDetailsAdaptor
    {
        private readonly AppSettingsGlobal _appSettings;
        private readonly CommonApiAdaptor _commonApiAdaptor;
        private readonly GlobalClass _globalClass;

        public ContactPersonDetailsAdaptor(
            AppSettingsGlobal appSettings,
            CommonApiAdaptor commonApiAdaptor,
            GlobalClass globalClass)
        {
            _appSettings = appSettings;
            _commonApiAdaptor = commonApiAdaptor;
            _globalClass = globalClass;
        }

        // =========================
        // LIST BY EMPLOYEE (FIXED)
        // =========================
        public async Task<List<ContactPersonDetailsResponseDto>> GetByEmployeeId(int employeeId)
        {
            var url =
                $"{_appSettings.BaseUrl}{_appSettings.GetContactPersonsByEmployee}/{employeeId}";

            var responseModel =
                await _commonApiAdaptor.GetAsync<CommanResponseDto>(
                    url,
                    _globalClass.Token);

            var pageResult =
                _commonApiAdaptor.GenerateResponse<ContactPersonDetailsResponseDto>(responseModel);

            return pageResult?.Result ?? new List<ContactPersonDetailsResponseDto>();
        }


        // =========================
        // ADD (FIXED RESPONSE CHECK)
        // =========================
        public async Task<bool> Add(ContactPersonDetailsRequestDto request)
        {
            var url = _appSettings.BaseUrl + _appSettings.AddContactPerson;

            var response = await _commonApiAdaptor
                .PostAsync<ApiResultDto>(
                    url,
                    request,
                    _globalClass.Token);

            return response != null && response.IsSuccess;
        }

        // =========================
        // UPDATE (FIXED)
        // =========================
        public async Task<bool> Update(ContactPersonDetailsRequestDto request)
        {
            var url = _appSettings.BaseUrl + _appSettings.UpdateContactPerson;

            var response = await _commonApiAdaptor
                .PostAsync<ApiResultDto>(
                    url,
                    request,
                    _globalClass.Token);

            return response != null && response.IsSuccess;
        }

        // =========================
        // DELETE (FIXED)
        // =========================
        public async Task<bool> Delete(int contactPersonDetailId, int updatedBy)
        {
            var url =
                $"{_appSettings.BaseUrl}{_appSettings.DeleteContactPerson}/" +
                $"{contactPersonDetailId}/{updatedBy}";

            var response = await _commonApiAdaptor
                .DeleteAsync<ApiResultDto>(
                    url,
                    _globalClass.Token);

            return response != null && response.IsSuccess;
        }
    }

    // =========================
    // API RESULT DTO
    // =========================
    public class ApiResultDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
