using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
    public interface IEqualOperation
    {

        bool? ComparingTypeObject(object obj1, object obj2);

        bool? ComparingEqualityObject(object obj1, object obj2);

        bool? CheckingNull(object obj1, object obj2);

        bool? CheckingBothNull(object obj1, object obj2);

        bool? CheckingListCount(object obj1, object obj2);
    }
}
