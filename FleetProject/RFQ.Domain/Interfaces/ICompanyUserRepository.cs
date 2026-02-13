using RFQ.Domain.Helper;
using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;
using RFQ.Domain.ResponseDto;

namespace RFQ.Domain.Interfaces
{
    public interface ICompanyUserRepository
    {
        Task<CompanyUser?> GetUserById(int id);
        Task<PageList<CompanyUserResponseDto>> GetAllUser(PagingParam pagingParam);
        Task<CompanyUser> AddUser(CompanyUser user);
        Task UpdateUser(CompanyUser user);
        Task DeleteUser(CompanyUser user);
        Task<CompanyUser?> GetAuthentication(string EmailId, string Password);
        Task<CompanyUser?> GetByEmailAsync(string emailId);
        Task<CompanyUser?> GetByLoginIdAsync(string LoginId);
        Task<bool> UpdateUserPassWord(UpdateUserPasswordDto user);
        Task<MasterUserActivityLog> AddUserActivitylog(MasterUserActivityLog userActivityLog);
        Task<CompanyUser?> GetExistingUserById(int id);
    }
}
