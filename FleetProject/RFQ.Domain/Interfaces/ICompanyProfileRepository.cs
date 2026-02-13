using RFQ.Domain.Models;

namespace RFQ.Domain.Interfaces
{
    public interface ICompanyProfileRepository
    {
        Task<CompanyProfile> GetProfileById(int id);
        Task<IEnumerable<CompanyProfile>> GetAllProfile();
        Task<CompanyProfile> AddProfile(CompanyProfile Profile);
        Task UpdateProfile(CompanyProfile profile);
        Task DeleteProfile(CompanyProfile profile);
    }
}
