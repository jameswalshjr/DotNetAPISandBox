using DotNetAPISandBox.Data.Interface;
using DotNetAPISandBox.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAPISandBox.Data.Repository
{
    public class MaintenanceRepository
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
                var functions = await unitOfWork.Repository().FindAsync<FunctionStatus>();

                return functions.ToList() ;
            }
        }
    }
}
