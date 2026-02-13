using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFQ.Domain.Models;

namespace RFQ.Application.Interface
{
    public interface IContactPersonDetailsService
    {
        Task<List<ContactPersonDetails>> GetContactPersonsByEmployee(int employeeId);

        Task<ContactPersonDetails?> GetContactPersonById(int ContactPersonId);

        Task<bool> AddContactPerson(ContactPersonDetails contactPerson);

        Task<bool> UpdateContactPerson(ContactPersonDetails contactPerson);

        Task<bool> DeleteContactPerson(int ContactPersonId, int updatedBy);
    }
}

