
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Application.Interface
{
    public interface IMenuListService
    {
        Task<IEnumerable<MenuListResponseDto>> GetMenu(int profileId);
    }
}
