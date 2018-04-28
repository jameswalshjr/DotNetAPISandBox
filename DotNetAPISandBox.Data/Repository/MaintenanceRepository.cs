using DotNetAPISandBox.Data.Interface;
using DotNetAPISandBox.Domain.Dto;
using DotNetAPISandBox.Domain.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using System;

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
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    var functions = await unitOfWork.Repository().FindAsync<FunctionStatusEntity>();

                    return functions.Select(Mapper.Map<FunctionStatus>).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        public  async Task<FunctionStatus> AddFunctionStatus(FunctionStatus functionStatus)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    var entity = (FunctionStatusEntity)functionStatus;
                    var addedStatus = unitOfWork.Repository().Add<FunctionStatusEntity>(entity);
                    var response = await unitOfWork.CommitAsync();
                    
                    return (FunctionStatus)addedStatus;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
