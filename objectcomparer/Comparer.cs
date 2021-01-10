using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
    public static class Comparer
    {
        public static bool AreSimilar<T>(T first, T second)
        {
            /// Add your implementation logic here. Feel free to add classes and types as required for your solution.
            return true;
        }

        public static bool AreObjectsEqual(object obj1, object obj2, string operationName="None")
        {
            if (operationName.Equals("Equals"))
            {
                IOperation operation = new Operation( new Logger());
                var equal = operation.AreEqual(obj1, obj2);
                return equal;
            }

            return false;
        }
    }


}
