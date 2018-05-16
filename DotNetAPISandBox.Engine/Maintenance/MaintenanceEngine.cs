using DotNetAPISandBox.Data.Interface;
using DotNetAPISandBox.Domain.Dto;
using DotNetAPISandBox.Engine.Interface;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetAPISandBox.Engine.Maintenance
{
    public class MaintenanceEngine : IMaintenanceEngine
    {
        private readonly IMaintenanceRepository maintRepo;

        public MaintenanceEngine(IMaintenanceRepository _maintRepo)
        {
            this.maintRepo = _maintRepo;
        }
        public async Task<IQueryable<FunctionStatus>> GetAllFunctionStatus()
        {
            try
            {
                var functions = await maintRepo.GetFunctionStatus();
                if(functions.Count > 0)
                {
                    return functions.AsQueryable();
                }
                else
                {
                    return Enumerable.Empty<FunctionStatus>().AsQueryable();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<FunctionStatus> AddFunctionStatus(FunctionStatus functionStatus)
        {
            try
            {
                return functionStatus = await maintRepo.AddFunctionStatus(functionStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<FunctionStatus> UpdateFunctionStatus(FunctionStatusUpdate functionStatusUpdate)
        {
            try
            {
                var function = await maintRepo.GetFunctionStatusByName(functionStatusUpdate.FunctionName);
                if(function != default(FunctionStatus))
                {
                    function.EnableFunction = functionStatusUpdate.EnableFunction;
                    function = await maintRepo.UpdateFunctionStatus(function);
                    return function;
                }
                else
                {
                    return default(FunctionStatus);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<FunctionStatus> GetFunctionStatusByName(string functionName)
        {
            try
            {
                var function = await maintRepo.GetFunctionStatusByName(functionName);
                if(function != default(FunctionStatus))
                {
                    return function;
                }
                else
                {
                    return default(FunctionStatus);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
