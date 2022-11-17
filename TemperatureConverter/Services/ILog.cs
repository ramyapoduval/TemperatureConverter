using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureConverter.Services
{
    public interface ILog
    {
        void Debug(string text);
        void Error(string text);
        void Fatal(string text);
        void Info(string text);
        void Warning(string text);
    }
}
