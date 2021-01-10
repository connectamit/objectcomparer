using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
    public class Student
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public int[] Marks;
        public List<Subject> Subjects { get; set; }
        public Address Address { get; set; }

    }

    public class GeoLocation
    {
        public double Lat { get; set; }
        public double Long { get; set; }
    }

    public class Address
    {
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public GeoLocation GeoLocation { get; set; }
    }


    public class Subject
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
