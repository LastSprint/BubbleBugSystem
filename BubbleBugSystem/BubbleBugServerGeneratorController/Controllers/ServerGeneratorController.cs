using BubbleBugServerGeneratorController.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BubbleBugServerGeneratorController.Controllers
{
    [Route("api/[controller]")]
    public class ServerGeneratorController : Controller {

        private readonly ILogger _logger;

        public ServerGeneratorController(ILogger logger) {
            this._logger = logger;
        }

        /// <summary>
        /// Запускает генерацию мокового сервера.
        /// </summary>
        /// <param name="pathToSpecification">Путь к файлу спецификации</param>
        /// <returns></returns>
        [HttpPost]
        public object StartGenerator(string pathToSpecification) {

            if (!System.IO.File.Exists(pathToSpecification)) {
                this._logger.LogError(LoggingEvents.FileNotFonund, $"{this} can't read file from path {pathToSpecification}");
                return new BadRequestResult();
            }

            return new CreatedResult(this.HttpContext.Connection.LocalIpAddress.ToString(), "Server was created");
        }
    }
}
