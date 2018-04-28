using DotNetAPISandBox.Engine.Interface;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace DotNetAPISandBox.Controllers.Maintenance.v1
{
    [RoutePrefix("Maintenance/V1")]
    public class MaintenanceController : ApiController
    {
        private readonly IMaintenanceEngine maintEngine;

        public MaintenanceController(IMaintenanceEngine _maintEngine)
        {
            this.maintEngine = _maintEngine;
        }

        [HttpGet]
        [Route("FunctionStatus")]
        public async Task<IHttpActionResult> GetFunctionStatus()
        {
            try
            {
                var results = await maintEngine.GetAllFunctionStatus();
                if(results.Any())
                {
                    return Ok(results);
                }
                else
                {
                    return Content(HttpStatusCode.NoContent, String.Empty);
                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}