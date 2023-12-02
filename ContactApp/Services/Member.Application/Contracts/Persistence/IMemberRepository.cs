using Member.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Member.Application.Contracts.Persistence
{
    public interface IMemberRepository
    {
        Task<IReadOnlyCollection<MemberInfo>> GetAllAsync();
        Task<MemberInfo> GetByIdAsync(int id);
        Task<MemberInfo> AddAsync(MemberInfo memberInfo);
        Task<IReadOnlyCollection<MemberInfo>> UpdateAsync(MemberInfo memberInfo);
        Task<bool> DeleteAsync(int id);

    }
}
