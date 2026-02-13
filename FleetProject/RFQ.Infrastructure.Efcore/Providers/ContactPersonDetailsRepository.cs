using Microsoft.EntityFrameworkCore;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;

namespace RFQ.Infrastructure.Efcore.Providers
{
    public class ContactPersonDetailsRepository : IContactPersonDetailsRepository
    {
        private readonly FleetLynkDbContext _context;

        public ContactPersonDetailsRepository(FleetLynkDbContext context)
        {
            _context = context;
        }

        // =========================
        // GET BY EMPLOYEE ID
        // =========================
        public async Task<List<ContactPersonDetails>> GetByEmployeeId(int employeeId)
        {
            return await _context.contactPersonDetails
                .AsNoTracking()
                .Where(x => x.EmployeeId == employeeId && x.IsActive == true)
                .OrderBy(x => x.ContactPersonId)
                .ToListAsync();
        }

        // =========================
        // GET BY ID
        // =========================
        public async Task<ContactPersonDetails?> GetById(int ContactPersonId)
        {
            return await _context.contactPersonDetails
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ContactPersonId == ContactPersonId);
        }

        // =========================
        // ADD
        // =========================
        public async Task<bool> Add(ContactPersonDetails contactPerson)
        {
            await _context.contactPersonDetails.AddAsync(contactPerson);
            return await _context.SaveChangesAsync() > 0;
        }

        // =========================
        // UPDATE
        // =========================
        public async Task<bool> Update(ContactPersonDetails contactPerson)
        {
            var existing = await _context.contactPersonDetails
                .FirstOrDefaultAsync(x => x.ContactPersonId == contactPerson.ContactPersonId);

            if (existing == null)
                return false;

            existing.Relation = contactPerson.Relation;
            existing.ContactPersonName = contactPerson.ContactPersonName;
            existing.IsActive = contactPerson.IsActive;
            existing.UpdatedBy = contactPerson.UpdatedBy;
            existing.UpdatedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        // =========================
        // SOFT DELETE
        // =========================
        public async Task<bool> SoftDelete(int ContactPersonId, int updatedBy)
        {
            var existing = await _context.contactPersonDetails
                .FirstOrDefaultAsync(x => x.ContactPersonId == ContactPersonId);

            if (existing == null)
                return false;

            existing.IsActive = false;
            existing.UpdatedBy = updatedBy;
            existing.UpdatedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
