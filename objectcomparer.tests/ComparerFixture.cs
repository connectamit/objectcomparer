using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ObjectComparer.Tests
{
    [TestClass]
    public class ComparerFixture
    {
        //[TestMethod]
        //public void Null_values_are_similar_test()
        //{
        //    string first = null, second = null;
        //    Assert.IsTrue(Comparer.AreSimilar(first, second));
        //}


        [TestMethod]
        public void Two_Objects_Are_Similar()
        {
            var a = new Student { Name = "Amit", ID = 121, Marks = new[] { 10, 20, 30, 40 } };
            var b = new Student { Name = "Amit", ID = 121, Marks = new[] { 10, 20, 30, 40 } };

            Assert.IsTrue(Comparer.AreObjectsEqual(a,b, "Equals"));
        }

        [TestMethod]
        public void Two_Objects_Are_Not_Similar_DiffObjectType()
        {
            var a = new Student { Name = "Amit", ID = 121, Marks = new[] { 10, 20, 30, 40 } };
            var b = new Student { Name = "Amit", ID = 121, Marks = new[] { 10, 20, 30, 40 } };

            List<Student> c = new List<Student>();
            c.Add(b);

            Assert.IsFalse(Comparer.AreObjectsEqual(a, c, "Equals"));
        }

        [TestMethod]
        public void Two_Objects_Are_Similar_OrderDiff()
        {
            var a = new Student { Name = "Amit", ID = 121, Marks = new[] { 10, 20, 30, 40 } };
            var b = new Student { Name = "Amit", ID = 121, Marks = new[] { 10, 20, 40, 30 } };

            Assert.IsTrue(Comparer.AreObjectsEqual(a, b, "Equals"));
        }

        [TestMethod]
        public void Two_Objects_Are_Similar_BothNull()
        {
            //Can avoid this test case, for bad data input, but was not sure
            var a = new Student { Name = "Amit", ID = 121, Marks = new[] { 10, 20, 30, 40 } };
            var b = new Student { Name = "Amit", ID = 121, Marks = new[] { 10, 20, 40, 30 } };

            Assert.IsTrue(Comparer.AreObjectsEqual(null, null, "Equals"));
        }

        [TestMethod]
        public void Two_Objects_Are_Not_Similar_Null()
        {
            var a = new Student { Name = "Amit", ID = 121, Marks = new[] { 10, 20, 30, 40 } };
            string b=null ;

            Assert.IsFalse(Comparer.AreObjectsEqual(a, b, "Equals"));
        }

        [TestMethod]
        public void Two_Objects_Are_Not_Similar_PropertyMissing()
        {
            var a = new Student { Name = "Amit", ID = 121, Marks = new[] { 10, 20, 30, 40 } };
            var b = new Student { Name = "Amit", ID = 12 };


            Assert.IsFalse(Comparer.AreObjectsEqual(a, b, "Equals"));
        }

        [TestMethod]
        public void Two_Objects_Are_Not_Similar_ListType()
        {
            var a = new Student { Name = "Amit", ID = 121, Marks = new[] { 10, 20, 30, 40 }, Subjects=new List<Subject> { new Subject { ID=1, Name="English" } } };
            var b = new Student { Name = "Amit", ID = 121, Marks = new[] { 10, 20, 30, 40 } };

            Assert.IsFalse(Comparer.AreObjectsEqual(a, b, "Equals"));
        }

        [TestMethod]
        public void Two_Objects_Are_ListType()
        {
            List<Subject> c = new List<Subject>();
            c.Add(new Subject { ID = 1, Name = "English" });

            var a = new Student { Name = "Amit", ID = 121, Marks = new[] { 10, 20, 30, 40 }, Subjects = new List<Subject> { new Subject { ID = 1, Name = "English" } } };
            var b = new Student { Name = "Amit", ID = 121, Marks = new[] { 10, 20, 30, 40 }, Subjects=c };

            Assert.IsTrue(Comparer.AreObjectsEqual(a, b, "Equals"));
        }

        [TestMethod]
        public void Two_Objects_Are_Similar_ClassType()
        {

            var a = new Student { Address=new Address { Street1="Lane17", Street2="Lane18", GeoLocation=new GeoLocation { Lat=1111122.23, Long=1233344.78} } };
            var b = new Student { Address = new Address { Street1 = "Lane17", Street2 = "Lane18", GeoLocation = new GeoLocation { Lat = 1111122.23, Long = 1233344.78 } } };

            Assert.IsTrue(Comparer.AreObjectsEqual(a, b, "Equals"));
        }
    }
}
