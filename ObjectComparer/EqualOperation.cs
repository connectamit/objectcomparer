using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
    public class EqualOperation : IEqualOperation
    {

        public bool? ComparingTypeObject(object obj1, object obj2)
        {
            if (obj1.GetType() != obj2.GetType())
            {
                DBClient.ClientCode(new OperationStatus(false));
                return false;
            }
            return null;
        }

        public bool? ComparingEqualityObject(object obj1, object obj2)
        {
            if (ReferenceEquals(obj1, obj2))
            {
                DBClient.ClientCode(new OperationStatus(false));
                return true;
            }
            return null;
        }

        public bool? CheckingNull(object obj1, object obj2)
        {
            if (ReferenceEquals(obj1, null) || ReferenceEquals(obj2, null))
            {
                DBClient.ClientCode(new OperationStatus(false));
                return false;
            }
            return null;
        }

        public bool? CheckingBothNull(object obj1, object obj2)
        {
            if (obj1 == null && obj2 == null)
            {
                DBClient.ClientCode(new OperationStatus(true));
                return true;
            }
            return null;
        }

        public bool? CheckingListCount(object obj1, object obj2)
        {
            if(obj1 is List<ObjectComparer.Student> && obj2 is List<ObjectComparer.Student>)
            {
                var objLeft = obj1 as List<Student>;
                var objRight = obj2 as List<Student>;

                if (objLeft.Count == 0 && objRight.Count == 0)
                {
                    DBClient.ClientCode(new OperationStatus(true));
                    return true;
                }
                return null;
            }
            return null;
        }

    }
}
