using RFQ.Application.Interface;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;

namespace RFQ.Application.Provider
{
    public class ContactPersonDetailsService : IContactPersonDetailsService
    {
        private readonly IContactPersonDetailsRepository _contactPersonRepository;

        public ContactPersonDetailsService(
            IContactPersonDetailsRepository contactPersonRepository)
        {
            _contactPersonRepository = contactPersonRepository;
        }

        // =========================
        // GET BY EMPLOYEE
        // =========================
        public async Task<List<ContactPersonDetails>> GetContactPersonsByEmployee(int employeeId)
        {
            if (employeeId <= 0)
                return new List<ContactPersonDetails>();

            return await _contactPersonRepository.GetByEmployeeId(employeeId);
        }

        // =========================
        // GET BY ID
        // =========================
        public async Task<ContactPersonDetails?> GetContactPersonById(int ContactPersonId)
        {
            if (ContactPersonId <= 0)
                return null;

            return await _contactPersonRepository.GetById(ContactPersonId);
        }

        // =========================
        // ADD
        // =========================
        public async Task<bool> AddContactPerson(ContactPersonDetails contactPersonDetails)
        {
            if (contactPersonDetails == null)
                return false;

            contactPersonDetails.CreatedOn = DateTime.UtcNow;

            return await _contactPersonRepository.Add(contactPersonDetails);
        }

        // =========================
        // UPDATE
        // =========================
        public async Task<bool> UpdateContactPerson(ContactPersonDetails contactPersonDetails)
        {
            if (contactPersonDetails == null ||
                contactPersonDetails.ContactPersonId <= 0)
                return false;

            contactPersonDetails.UpdatedOn = DateTime.UtcNow;

            return await _contactPersonRepository.Update(contactPersonDetails);
        }

        // =========================
        // SOFT DELETE
        // =========================
        public async Task<bool> DeleteContactPerson(int ContactPersonId, int updatedBy)
        {
            if (ContactPersonId <= 0)
                return false;

            return await _contactPersonRepository
                .SoftDelete(ContactPersonId, updatedBy);
        }
    }
}
