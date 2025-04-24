using System;
using NUnit.Framework;
using EmployeeLibrary;
using static EmployeeLibrary.Employee;

namespace EmployeeTests
{
    [TestFixture]
    public class MonthPaymentTest
    {
        [Test]
        public void Test1()
        {
            var employee = new Employee("A1",
                new DateTime(1990, 1, 1),
                Gender.MALE, 1000m,
                CurrentPosition.DIRECTOR, Education.HIGHER);
            
            Assert.AreEqual(1150m, employee.monthPayment());
        }
        
        [Test]
        public void Test2()
        {
            var employee = new Employee("A1",
                new DateTime(1990, 1, 1),
                Gender.MALE, 1000m,
                CurrentPosition.MIDDLE, Education.HIGHER);
            
            Assert.AreEqual(1100m, employee.monthPayment());
        }
        
        [Test]
        public void Test3()
        {
            var employee = new Employee("A1",
                new DateTime(1990, 1, 1),
                Gender.MALE, 1000m,
                CurrentPosition.JUNIOR, Education.HIGHER);
            
            Assert.AreEqual(1050m, employee.monthPayment());
        }
        
        [Test]
        public void Test4()
        {
            var employee = new Employee("A1",
                new DateTime(1990, 1, 1),
                Gender.MALE, 1000m,
                CurrentPosition.MANAGER, Education.HIGHER);
            
            Assert.AreEqual(1030m, employee.monthPayment());
        }
        
        [Test]
        public void Test5()
        {
            var employee = new Employee("A1",
                new DateTime(1990, 1, 1),
                Gender.MALE, 0m,
                CurrentPosition.MANAGER, Education.HIGHER);
            
            Assert.AreEqual(0m, employee.monthPayment());
        }
    }
}