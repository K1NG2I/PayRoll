using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;
using RFQ.Domain.ResponseDto;

namespace RFQ.Domain.Interfaces
{
    public interface ICompanyProfileRightRepository
    {
        Task<CompanyProfileRight> GetProfileRightsById(int id);
        Task<IEnumerable<CompanyProfileRight>> GetAllProfileRights();
        Task<CompanyProfileRight> AddProfileRights(CompanyProfileRight profile);
        Task UpdateProfileRights(CompanyProfileRight profile);
        Task DeleteProfileRights(CompanyProfileRight profile);
        Task<IEnumerable<CompanyProfileRightResponse>> GetProfileRightsByProfileId(int profileId);
        Task<bool> AddOrUpdateProfileRights(List<CompanyProfileRightRequestDto> profileList);
    }
}
