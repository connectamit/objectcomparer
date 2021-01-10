using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
    public class Logger : ILogger
    {
        public void LogException(Exception exception)
        {
            //TEMP CODE, WILL log exception in db or file
            throw new NotImplementedException(exception.Message);
        }
    }
}
