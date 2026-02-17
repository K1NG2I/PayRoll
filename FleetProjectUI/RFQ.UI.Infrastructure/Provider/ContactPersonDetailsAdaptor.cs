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

        public async Task<List<ContactPersonDetailsResponseDto>> GetByEmployeeId(int employeeId)
        {
            try
            {
                var url =
                    $"{_appSettings.BaseUrl}{_appSettings.GetContactPersonsByEmployee}/{employeeId}";

                var response =
                    await _commonApiAdaptor.GetAsync<
                        CommonListResponseDto<ContactPersonDetailsResponseDto>
                    >(url, _globalClass.Token);

                return response?.Data ?? new List<ContactPersonDetailsResponseDto>();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<bool> Add(ContactPersonDetailsRequestDto request)
    {
        try
        {
            var url = _appSettings.BaseUrl + _appSettings.AddContactPerson;

            var responseModel =
                await _commonApiAdaptor.PostAsync<CommonResponseDto>(
                    url,
                    request,
                    _globalClass.Token);

            return responseModel != null;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> Update(ContactPersonDetailsRequestDto request)
    {
        try
        {
            var url = _appSettings.BaseUrl + _appSettings.UpdateContactPerson;

            var responseModel =
                await _commonApiAdaptor.PostAsync<CommonResponseDto>(
                    url,
                    request,
                    _globalClass.Token);

            return responseModel != null;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> Delete(int contactPersonDetailId, int updatedBy)
    {
        try
        {
            var url =
                $"{_appSettings.BaseUrl}{_appSettings.DeleteContactPerson}/" +
                $"{contactPersonDetailId}/{updatedBy}";

            var responseModel =
                await _commonApiAdaptor.DeleteAsync<CommonResponseDto>(
                    url,
                    _globalClass.Token);

            return responseModel != null;
        }
        catch (Exception)
        {
            throw;
        }
    }
}

}
