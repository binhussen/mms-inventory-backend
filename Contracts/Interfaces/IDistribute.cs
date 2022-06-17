using DataModel.Models.Entities;
using DataModel.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface IDistribute
    {
        Task<IEnumerable<Distribute>> GetDistributesAsync(DistributeParameters distributeParameters,bool trackChanges);
        Task<Distribute> GetDistributeAsync(int id, bool trackChanges);
        void CreateDistribute(Distribute distribute);
        void DeleteDistribute(Distribute distribute);
    }
}
