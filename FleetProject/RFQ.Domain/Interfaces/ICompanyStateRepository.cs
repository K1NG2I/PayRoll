using RFQ.Domain.Models;

namespace RFQ.Domain.Interfaces
{
    public interface ICompanyStateRepository
    {
        //CompanyState
        Task<CompanyState> GetStateById(int id);
        Task<IEnumerable<CompanyState>> GetAllState();
        Task<CompanyState> AddState(CompanyState state);
        Task UpdateState(CompanyState state);
        Task DeleteState(CompanyState state);
    }
}
