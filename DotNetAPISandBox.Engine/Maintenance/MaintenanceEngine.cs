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
    }
}
