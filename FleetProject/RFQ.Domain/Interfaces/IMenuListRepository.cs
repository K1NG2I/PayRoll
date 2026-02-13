using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Domain.Interfaces
{
    public interface IMenuListRepository
    {
        Task<IEnumerable<MenuListResponseDto>> GetMenu(int profileId);

    }
}
