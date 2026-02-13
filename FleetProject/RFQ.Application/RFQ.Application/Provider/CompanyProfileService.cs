using RFQ.Application.Interface;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;

namespace RFQ.Application.Provider
{
    public class CompanyProfileService : ICompanyProfileService

    {
        private readonly ICompanyProfileRepository _companyProfileRepository;

        public CompanyProfileService(ICompanyProfileRepository companyProfileRepository)
        {
            _companyProfileRepository = companyProfileRepository;
        }

        public async Task<CompanyProfile> AddProfile(CompanyProfile profile)
        {
            return await _companyProfileRepository.AddProfile(profile);
        }

        public async Task<int> DeleteProfile(int profileId)
        {
            var result = await _companyProfileRepository.GetProfileById(profileId);
            if (result != null)
            {
                await _companyProfileRepository.DeleteProfile(result);
                return 1;
            }
            return 0;
        }
        public Task<IEnumerable<CompanyProfile>> GetAllProfile()
        {
            return _companyProfileRepository.GetAllProfile();
        }

        public async Task<CompanyProfile> GetProfileById(int id)
        {
            return await _companyProfileRepository.GetProfileById(id);
        }

        public async Task UpdateProfile(CompanyProfile profile)
        {
            await _companyProfileRepository.UpdateProfile(profile);
        }
    }
}
