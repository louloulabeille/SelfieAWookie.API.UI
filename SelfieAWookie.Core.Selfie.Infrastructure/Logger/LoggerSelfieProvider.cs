using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookie.Core.Selfies.Infrastructure.Logger
{
    public class LoggerSelfieProvider : ILoggerProvider
    {
        private readonly ConcurrentDictionary<string,LoggerSelfie> _loggerList = new();

        public ILogger CreateLogger(string categoryName)
        {
            this._loggerList.GetOrAdd(categoryName, key => new LoggerSelfie());
            return _loggerList[categoryName];
        }

        public void Dispose()
        {
            _loggerList.Clear();
            GC.SuppressFinalize(this);
        }
    }
}
