using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Traders.Employees.Api.Logging
{
    public interface INLogManager
    {
        void Debug(string message, params object[] args);
        void Info(string message, params object[] args);
        void Warn(string message, params object[] args);
        void Warn(string message, Exception exception, params object[] args);
        void Error(string message);
        void Error(string message, Exception exception, params object[] args);
        void Fatal(string message);
        void Fatal(string message, Exception exception, params object[] args);
    }
}
