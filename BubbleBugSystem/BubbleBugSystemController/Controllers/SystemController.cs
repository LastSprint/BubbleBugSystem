﻿using BubbleBugSystemController.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BubbleBugSystemController.Controllers {
    [Route("api/[controller]")]
    public class SystemController : Controller {

        private readonly ILogger _logger;

        public SystemController(ILogger logger) {
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
