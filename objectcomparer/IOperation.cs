using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
    public interface IOperation
    {
        bool AreEqual(object obj1, object obj2);
    }
}
