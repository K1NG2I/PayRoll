using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;
using RFQ.Domain.ResponseDto;

namespace RFQ.Application.Interface
{
    public interface ICompanyProfileRightService
    {
        Task<CompanyProfileRight> GetProfileRightsById(int id);
        Task<IEnumerable<CompanyProfileRight>> GetAllProfileRight();
        Task<CompanyProfileRight> AddProfileRight(CompanyProfileRight profile);
        Task UpdateProfileRights(CompanyProfileRight profile);
        //Task<int> DeleteProfileRights(int id);
        Task<IEnumerable<CompanyProfileRightResponse>> GetProfileRightsByProfileId(int profileId);
        Task<bool> AddOrUpdateProfileRights(List<CompanyProfileRightRequestDto> profileList);
    }
}
