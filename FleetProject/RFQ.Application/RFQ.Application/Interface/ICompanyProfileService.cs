using RFQ.Domain.Models;

namespace RFQ.Application.Interface
{
    public interface ICompanyProfileService
    {

        //CompanyProfile
        Task<CompanyProfile> GetProfileById(int id);
        Task<IEnumerable<CompanyProfile>> GetAllProfile();
        Task<CompanyProfile> AddProfile(CompanyProfile profile);
        Task UpdateProfile(CompanyProfile profile);
        Task<int> DeleteProfile(int profileId);
    }
}
