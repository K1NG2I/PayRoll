using RFQ.Domain.Models;

namespace RFQ.Application.Interface
{
    public interface ICompanyStateService
    {
        //CompanyState
        Task<CompanyState> GetStateById(int id);
        Task<IEnumerable<CompanyState>> GetAllState();
        Task<CompanyState> AddState(CompanyState state);
        Task UpdateState(CompanyState state);
        Task<int> DeleteState(int id);
    }
}
