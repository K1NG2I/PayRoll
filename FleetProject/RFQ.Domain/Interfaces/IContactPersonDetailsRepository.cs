using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFQ.Domain.Models;

namespace RFQ.Domain.Interfaces
{
    public interface IContactPersonDetailsRepository
    {
        /// <summary>
        /// Get all contact persons for an employee
        /// </summary>
        Task<List<ContactPersonDetails>> GetByEmployeeId(int employeeId);

        /// <summary>
        /// Get contact person by primary key
        /// </summary>
        Task<ContactPersonDetails?> GetById(int ContactPersonId);

        /// <summary>
        /// Add new contact person
        /// </summary>
        Task<bool> Add(ContactPersonDetails contactPerson);

        /// <summary>
        /// Update existing contact person
        /// </summary>
        Task<bool> Update(ContactPersonDetails contactPerson);

        /// <summary>
        /// Soft delete contact person (IsActive = false)
        /// </summary>
        Task<bool> SoftDelete(int ContactPersonId, int updatedBy);
    }
}

