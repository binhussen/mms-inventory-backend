using DataModel.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface IApprove
    {
        Task<IEnumerable<Approve>> GetApproveAsync(bool trackChanges);
        Task<Approve> GetApproveAsync(int id, bool trackChanges);
        void CreateApprove(Approve approve);
        void DeleteApprove(Approve approve);
    }
}
