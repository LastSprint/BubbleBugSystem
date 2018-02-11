using System.Collections.Generic;
using System.Threading.Tasks;
using BubbleBugSharedModels;
using BubbleBugSystemController.Services;
using Microsoft.AspNetCore.Mvc;

namespace BubbleBugSystemController.Controllers {

    [Produces("application/json")]
    [Route("api/Service")]
    public class ServiceController : Controller {

        private readonly ServiceControllerService _controllerService;

        public ServiceController(ServiceControllerService controllerService) {
            this._controllerService = controllerService;
        }


        public async Task<IList<ServiceModel>> GetAllExistedServices() {
            var task = this._controllerService.GetAllServices();
            await Task.WhenAll(task);

            var result = await task;

            return result;
        }

    }
}