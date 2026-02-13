using Microsoft.AspNetCore.Identity;
using RFQ.Application.Helper;
using RFQ.Application.Interface;
using RFQ.Domain.Enums;
using RFQ.Domain.Helper;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;
using RFQ.Domain.ResponseDto;
using Microsoft.Extensions.Configuration;

namespace RFQ.Application.Provider
{
    public class CompanyUserService : ICompanyUserService
    {
        private readonly ICompanyUserRepository _companyUserRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly LinkItemContextHelper _linkItemContextHelper;
        private readonly ICompanyService _companyService;
        private readonly IConfiguration _configuration;

        public CompanyUserService(ICompanyUserRepository companyUserRepository, IPasswordHasher passwordHasher, LinkItemContextHelper linkItemContextHelper, ICompanyService companyService, IConfiguration configuration)
        {
            _companyUserRepository = companyUserRepository;
            _passwordHasher = passwordHasher;
            _linkItemContextHelper = linkItemContextHelper;
            _companyService = companyService;
            _configuration = configuration;
        }

        public async Task<PageList<CompanyUserResponseDto>> GetAllUser(PagingParam pagingParam)
        {
            var result = await _companyUserRepository.GetAllUser(pagingParam);
            result.DisplayColumns = await _linkItemContextHelper.GetDisplayColumns(ELinkItems.User);
            return result;
        }

        public async Task<CompanyUser?> GetUserById(int id)
        {
            return await _companyUserRepository.GetUserById(id);
        }

        public async Task UpdateUser(CompanyUser user)
        {
            await _companyUserRepository.UpdateUser(user);
        }

        public async Task<CompanyUser> AddUser(CompanyUser user)
        {
            user.Password = _passwordHasher.Encrypt(user.Password);
            return await _companyUserRepository.AddUser(user);
        }

        public async Task<int> DeleteUser(int id)
        {
            var result = await _companyUserRepository.GetExistingUserById(id);
            if (result != null)
            {
                if (result.StatusId == (int)EStatus.IsActive)
                    result.StatusId = (int)EStatus.Deleted;
                else
                    result.StatusId = (int)EStatus.IsActive;
                await _companyUserRepository.DeleteUser(result);
                return 1;
            }
            return 0;
        }

        public async Task<CommanResponseDto> GetAuthentication(string loginId, string password)
        {
            var user = await _companyUserRepository.GetByLoginIdAsync(loginId);

            if (user == null)
            {
                return new CommanResponseDto
                {
                    Data = false,
                    Message = "Enter valid Login Name",
                    StatusCode = 404 // Not Found
                };
            }

            string passwordHash = _passwordHasher.Encrypt(password);

            if (!user.Password.Equals(passwordHash))
            {
                return new CommanResponseDto
                {
                    Data = false,
                    Message = "Enter correct password",
                    StatusCode = 401 // Unauthorized
                };
            }

            if (user != null && user.CompanyId > 0)
            {
                var Company = await _companyService.GetCompanyById((int)user.CompanyId);
                if (Company == null)
                {
                    return new CommanResponseDto
                    {
                        Data = false,
                        Message = "This User Company Is Deactivated",
                        StatusCode = 404 
                    };
                }
            }

            return new CommanResponseDto
            {
                Data = user,
                Message = "Login successful",
                StatusCode = 200 // OK
            };
        }

        public async Task<CompanyUser?> GetByEmailAsync(string emailId)
        {
            return await _companyUserRepository.GetByEmailAsync(emailId);
        }

        public async Task<bool> UpdateUserPassWord(UpdateUserPasswordDto user)
        {
            return await _companyUserRepository.UpdateUserPassWord(user);
        }
        public async Task<MasterUserActivityLog> AddUserActivitylog(MasterUserActivityLog userActivityLog)
        {
            return await _companyUserRepository.AddUserActivitylog(userActivityLog);
        }

        public async Task<CompanyUser?> GetByLoginIdAsync(string LoginId)
        {
            var user = await _companyUserRepository.GetByLoginIdAsync(LoginId);
            return user;
        }

        public string GetLandingDisplayName()
        {
            return _configuration["Landing:DisplayName"];
        }

    }
}
