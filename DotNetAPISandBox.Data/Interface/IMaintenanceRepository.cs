using DotNetAPISandBox.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetAPISandBox.Data.Interface
{
    public interface IMaintenanceRepository
    {
        Task<List<FunctionStatus>> GetFunctionStatus();
        Task<FunctionStatus> AddFunctionStatus(FunctionStatus functionStatus);
    }
}
