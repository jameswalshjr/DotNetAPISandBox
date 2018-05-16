using DotNetAPISandBox.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAPISandBox.Engine.Interface
{
    public interface IMaintenanceEngine
    {
        Task<IQueryable<FunctionStatus>> GetAllFunctionStatus();
        Task<FunctionStatus> AddFunctionStatus(FunctionStatus functionStatus);
        Task<FunctionStatus> GetFunctionStatusByName(string functionName);
        Task<FunctionStatus> UpdateFunctionStatus(FunctionStatusUpdate functionStatusUpdate);

    }
}
