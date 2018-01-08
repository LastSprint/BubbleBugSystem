using System.IO;
using BubbleBugSystemController.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BubbleBugSystemController.Controllers {
    [Route("api/[controller]")]
    public class SystemController: Controller {

        private readonly ILogger _logger;

        private string ActionIdentifier => this.HttpContext.Connection.RemoteIpAddress.ToString();

        public SystemController(ILogger logger) {
            this._logger = logger;
        }

        /// <summary>
        /// Запускает генерацию мокового сервера.
        /// </summary>
        /// <param name="file">Файл со спецификациейи</param>
        /// <returns></returns>
        [HttpPost]
        public object StartGenerator(IFormFile file, [FromForm] bool needsToGenerateDefaultMokcs, [FromForm]bool needsToDeployAtOnce) {

            if (!this.FileValidation(file)) {
                this._logger.LogError(LoggingEvents.BadFileLoading, $"Validation of file sended from: {this.ActionIdentifier} failed!");
                return new BadRequestResult();
            }

            string specification;

            using (var stream = new StreamReader(file.OpenReadStream())) {
                specification = stream.ReadToEnd();
            }

            if (specification.Length == 0) {
                this._logger.LogError(LoggingEvents.FileIsEmpty, $"File with name {file.Name} from: {this.ActionIdentifier} is empty");
                return new BadRequestResult();
            }

            return new CreatedResult(this.HttpContext.Connection.LocalIpAddress.ToString(), "Server was created");
        }

        private bool FileValidation(IFormFile file) {
            return file.Length > 0;
        }
    }
}
