
using System;
using NUnit.Framework;
using EmployeeLibrary;
using static EmployeeLibrary.Employee;

namespace EmployeeTests
{
    [TestFixture]
    public class CheckNameTest
    {
        [Test]
        public void Test1()
        {
            var employee = new Employee("A1",
                new DateTime(1990, 1, 1),
                Gender.MALE, 1000,
                CurrentPosition.SENIOR, Education.HIGHER);
            Assert.IsTrue(employee.checkName());

        }

        [Test]
        public void Test2()
        {
            var employee = new Employee("1A",
                new DateTime(1990, 1, 1),
                Gender.MALE, 1000,
                CurrentPosition.SENIOR, Education.HIGHER);
            Assert.IsFalse(employee.checkName());
        }
        
        [Test]
        public void Test3()
        {
            var employee = new Employee("A1B2",
                new DateTime(1990, 1, 1),
                Gender.MALE, 1000,
                CurrentPosition.SENIOR, Education.HIGHER);
            Assert.IsFalse(employee.checkName());
        }
        
        [Test]
        public void Test4()
        {
            var employee = new Employee("A@B",
                new DateTime(1990, 1, 1),
                Gender.MALE, 1000,
                CurrentPosition.SENIOR, Education.HIGHER);
            Assert.IsFalse(employee.checkName());
        }
        
        [Test]
        public void Test5()
        {
            var employee = new Employee("A1B2",
                new DateTime(1990, 1, 1),
                Gender.MALE, 1000,
                CurrentPosition.SENIOR, Education.HIGHER);
            Assert.IsFalse(employee.checkName());
        }
        
        [Test]
        public void Test6()
        {
            var employee = new Employee("A",
                new DateTime(1990, 1, 1),
                Gender.MALE, 1000,
                CurrentPosition.SENIOR, Education.HIGHER);
            Assert.IsFalse(employee.checkName());
        }
        
        [Test]
        public void Test7()
        {
            var employee = new Employee("ABCDEFGHIJKLMNOP",
                new DateTime(1990, 1, 1),
                Gender.MALE, 1000,
                CurrentPosition.SENIOR, Education.HIGHER);
            Assert.IsFalse(employee.checkName());
        }
        
        [Test]
        public void Test8()
        {
            var employee = new Employee("Иван1",
                new DateTime(1990, 1, 1),
                Gender.MALE, 1000,
                CurrentPosition.SENIOR, Education.HIGHER);
            Assert.IsTrue(employee.checkName());
        }
    }
}