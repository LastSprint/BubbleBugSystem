using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace BubbleBugSystemController.Logging {

    public class LoggingEvents {

        public static EventId BadFileLoading { get; } = new EventId();
        public static EventId FileIsEmpty { get; } = new EventId();

    }
}
