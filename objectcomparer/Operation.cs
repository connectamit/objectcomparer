using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
    public class Operation : IOperation
    {
        private readonly ILogger _logger = null;
        private readonly DBOperations _dbOperations = null;

        public Operation(ILogger logger)
        {
            _logger = logger;
        }

        public bool AreEqual(object obj1, object obj2)
        {

            try
            {
                //First check if both the objects are null
                // Null of both the objects means equal
                if (obj1 == null && obj1 == null)
                {
                    DBClient.ClientCode(new OperationStatus(true));
                    return true;
                }

                //When obj1 or  obj2 is null
                if (ReferenceEquals(obj1, null) || ReferenceEquals(obj2, null))
                {
                    DBClient.ClientCode(new OperationStatus(false));
                    return false;
                }

                //When obj2 is null
                //if (ReferenceEquals(obj2, null))
                //{
                //    return false;
                //}

                //When both the objects are same
                if (ReferenceEquals(obj1, obj2))
                {
                    DBClient.ClientCode(new OperationStatus(true));
                    return true;
                }

                //When both the object type is not equal
                if (obj1.GetType() != obj2.GetType())
                {
                    DBClient.ClientCode(new OperationStatus(false));
                    return false;
                }

                //Getting all properties of of the obj2 object to iterate over the properties
                var propertyInformObj = obj2.GetType().GetProperties();

                //Comparing the property values of the obj1 and obj2 object
                foreach (var propertyInfo in propertyInformObj)
                {
                    var obj1Value = propertyInfo.GetValue(obj2);

                    var obj2Value = propertyInfo.GetValue(obj1);

                    if (obj1Value == null && obj2Value == null)
                    {
                        continue;
                    }

                    //When the property is a generic collection type
                    if ((obj2Value is IList && propertyInfo.PropertyType.IsGenericType) || (obj1Value is IList && propertyInfo.PropertyType.IsGenericType))
                    {
                        dynamic currentValue = obj2Value;

                        dynamic otherValue = obj1Value;

                        if (currentValue != null && currentValue.Count > 0)
                        {
                            var result = false;

                            foreach (object cValue in currentValue)
                            {
                                if (otherValue == null || otherValue.Count == 0)
                                {
                                    DBClient.ClientCode(new OperationStatus(false));
                                    return false;
                                }

                                foreach (object oValue in otherValue)
                                {
                                    //Recursive call, to check object again
                                    var areEqual = AreEqual(cValue, oValue);

                                    if (!areEqual)
                                    {
                                        continue;
                                    }
                                    result = true;

                                    break;
                                }

                            }
                            if (!result)
                            {
                                DBClient.ClientCode(new OperationStatus(false));
                                return false;
                            }
                        }
                    }
                    else
                    {
                        //When the property is a non collection type
                        var currentType = obj2Value.GetType();

                        if (currentType.IsValueType || obj2Value is string)
                        {
                            var areObjectEquals = obj2Value.Equals(obj1Value);

                            if (!areObjectEquals)
                            {
                                DBClient.ClientCode(new OperationStatus(false));
                                return false;
                            }
                        }
                        else
                        {
                            var areObjectEquals = AreEqual(obj2Value, obj1Value);

                            if (areObjectEquals == false)
                            {
                                DBClient.ClientCode(new OperationStatus(false));
                                return false;
                            }
                        }
                    }
                }
            }

            catch(Exception ex)
            {
                _logger.LogException(ex);
                DBClient.ClientCode(new OperationStatus(false));
                return false;
            }
            DBClient.ClientCode(new OperationStatus(true));
            return true;
        }
    }
}
