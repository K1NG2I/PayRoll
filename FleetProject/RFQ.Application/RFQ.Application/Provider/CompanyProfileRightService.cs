using RFQ.Application.Interface;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;
using RFQ.Domain.ResponseDto;

namespace RFQ.Application.Provider
{
    public class CompanyProfileRightService : ICompanyProfileRightService
    {
        private readonly ICompanyProfileRightRepository _companyProfileRightService;

        public CompanyProfileRightService(ICompanyProfileRightRepository companyProfileRightService)
        {
            _companyProfileRightService = companyProfileRightService;
        }

        public async Task<CompanyProfileRight> AddProfileRight(CompanyProfileRight profile)
        {
            return await _companyProfileRightService.AddProfileRights(profile);
        }

        public async Task<int> DeleteProfileRights(int id)
        {
            var results = await _companyProfileRightService.GetProfileRightsById(id);
            if (results != null)
            {

                await _companyProfileRightService.DeleteProfileRights(results);
                return 1;
            }
            return 0;
        }

        public async Task<CompanyProfileRight> GetProfileRightsById(int id)
        {
            return await _companyProfileRightService.GetProfileRightsById(id);
        }


        public Task<IEnumerable<CompanyProfileRight>> GetAllProfileRight()
        {
            return _companyProfileRightService.GetAllProfileRights();
        }
       
        public async Task UpdateProfileRights(CompanyProfileRight profile)
        {
            await _companyProfileRightService.UpdateProfileRights(profile);
        }
        public Task<IEnumerable<CompanyProfileRightResponse>> GetProfileRightsByProfileId(int profileId)
        {
            return _companyProfileRightService.GetProfileRightsByProfileId(profileId);
        }

        public async Task<bool> AddOrUpdateProfileRights(List<CompanyProfileRightRequestDto> profileList)
        {
            return await _companyProfileRightService.AddOrUpdateProfileRights(profileList);
        }
    }
}
