using RFQ.Domain.Helper;
using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;
using RFQ.Domain.ResponseDto;

namespace RFQ.Application.Interface
{
    public interface ICompanyUserService
    {
        //CompanyUser
        Task<CompanyUser?> GetUserById(int id);
        Task<PageList<CompanyUserResponseDto>> GetAllUser(PagingParam pagingParam);
        Task<CompanyUser> AddUser(CompanyUser user);
        Task UpdateUser(CompanyUser user);
        Task<int> DeleteUser(int id);
        Task<CommanResponseDto> GetAuthentication(string loginId, string password);
        Task<CompanyUser?> GetByEmailAsync(string emailId);
        Task<bool> UpdateUserPassWord(UpdateUserPasswordDto user);
        Task<MasterUserActivityLog> AddUserActivitylog(MasterUserActivityLog userActivityLog);
        Task<CompanyUser?> GetByLoginIdAsync(string LoginId);
    }
}
