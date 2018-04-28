using DotNetAPISandBox.Data.Interface;
using DotNetAPISandBox.Domain.Dto;
using DotNetAPISandBox.Domain.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace DotNetAPISandBox.Data.Repository
{
    public class MaintenanceRepository : IMaintenanceRepository
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public MaintenanceRepository(IUnitOfWorkFactory _unitOfWorkFactory)
        {
            this.unitOfWorkFactory = _unitOfWorkFactory;
        }

        public async Task<List<FunctionStatus>> GetFunctionStatus()
        {
            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                var functions = await unitOfWork.Repository().FindAsync<FunctionStatusEntity>();

                return functions.Select(Mapper.Map<FunctionStatus>).ToList();
            }
        }
    }
}
