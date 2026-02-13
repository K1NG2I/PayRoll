using RFQ.Application.Interface;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Application.Provider
{
    public class MenuListService : IMenuListService
    {
        private readonly IMenuListRepository _menulistrepository;

        public MenuListService(IMenuListRepository menulistrepository)
        {
            _menulistrepository = menulistrepository;
        }

        public async Task<IEnumerable<MenuListResponseDto>> GetMenu(int profileId)
        {
            return await  _menulistrepository.GetMenu(profileId);
        }
    }
}
