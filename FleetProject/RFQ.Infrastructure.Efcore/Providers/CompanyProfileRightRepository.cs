using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;
using RFQ.Domain.ResponseDto;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RFQ.Infrastructure.Efcore.Providers
{
    public class CompanyProfileRightRepository : ICompanyProfileRightRepository
    {
        private readonly FleetLynkDbContext _appDbContext;
        private readonly IMapper _mapper;
        public CompanyProfileRightRepository(FleetLynkDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }
        public async Task DeleteProfileRights(CompanyProfileRight profile)
        {
            _appDbContext.companyProfileRights.Update(profile);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<CompanyProfileRight>> GetAllProfileRights()
        {
            return await _appDbContext.companyProfileRights.ToListAsync();
        }

        public Task<CompanyProfileRight> GetProfileRightsById(int id)
        {
            return _appDbContext.companyProfileRights.Where(x => x.UserProfileRightId == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task UpdateProfileRights(CompanyProfileRight profile)
        {
            _appDbContext.companyProfileRights.Update(profile);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<CompanyProfileRight> AddProfileRights(CompanyProfileRight profile)
        {
            await _appDbContext.companyProfileRights.AddAsync(profile);
            await _appDbContext.SaveChangesAsync();
            return profile;
        }
        public async Task<IEnumerable<CompanyProfileRightResponse>> GetProfileRightsByProfileId(int profileId)
        {
            var result = await (from ce in _appDbContext.companyProfileRights
                                join li in _appDbContext.link_Item
                                on ce.LinkId equals li.LinkId
                                where ce.ProfileId == profileId
                                select new CompanyProfileRightResponse
                                {
                                    UserProfileRightId = ce.UserProfileRightId,
                                    ProfileId = ce.ProfileId,
                                    LinkId = ce.LinkId,
                                    IsAdd = ce.IsAdd,
                                    IsEdit = ce.IsEdit,
                                    IsView = ce.IsView,
                                    IsCancel = ce.IsCancel,
                                    LinkGroupId = li.LinkGroupId
                                }).ToListAsync();

            return result;
            //return  _appDbContext.companyProfileRights.Where(x => x.ProfileId == profileId).ToListAsync();
        }

        public async Task<bool> AddOrUpdateProfileRights(List<CompanyProfileRightRequestDto> profileList)
        {
            var mappedProfileList = _mapper.Map<List<CompanyProfileRight>>(profileList);

            if (profileList == null || profileList.Count == 0)
                return false;

            var profileId = profileList[0].ProfileId;

            var existingRights = await _appDbContext.companyProfileRights.Where(x => x.ProfileId == profileId
             && profileList.Select(p => p.UserProfileRightId).Contains(x.UserProfileRightId)).ToListAsync();

            if (existingRights != null && existingRights.Count > 0)
            {
                foreach (var existing in existingRights)
                {
                    var updated = profileList.FirstOrDefault(x => x.LinkId == existing.LinkId && x.ProfileId == existing.ProfileId);
                    if (updated != null)
                    {
                        existing.IsAdd = updated.IsAdd;
                        existing.IsEdit = updated.IsEdit;
                        existing.IsView = updated.IsView;
                        existing.IsCancel = updated.IsCancel;
                    }
                }
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                // Add any new entries that didn't exist previously
                if (profileList.Any())
                {
                    await _appDbContext.companyProfileRights.AddRangeAsync(mappedProfileList);
                }
                await _appDbContext.SaveChangesAsync();
                return true;
            }
        }

    }

}

