using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
    public class OperationStatus : DBOperations
    {
        bool status = false;
        public OperationStatus(object obj)
        {
            status = (Boolean)obj;
        }
        protected override void Status()
        {
            //Save the status in db

        }
    }
}
