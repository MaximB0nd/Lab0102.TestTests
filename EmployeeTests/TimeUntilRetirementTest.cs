using System;
using NUnit.Framework;
using EmployeeLibrary;
using static EmployeeLibrary.Employee;


namespace EmployeeTests
{
    [TestFixture]
    public class TimeUntilRetirementTest
    {
        [Test]
        public void Test1()
        {
            var employee = new Employee("A1",
                DateTime.Today.AddDays(1), 
                Gender.MALE, 1000,
                CurrentPosition.MANAGER, Education.HIGHER);
            
            Assert.Throws<ArgumentException>(() => employee.timeUntilRetirement());
            
        }
        
        [Test]
        public void Test2()
        {
            var employee = new Employee("A1",
                DateTime.Today.AddYears(-65), 
                Gender.MALE, 1000,
                CurrentPosition.MANAGER, Education.HIGHER);
            
            Assert.AreEqual(0, employee.timeUntilRetirement());
        }
        
        [Test]
        public void Test3()
        {
            var employee = new Employee("A1",
                DateTime.Today.AddYears(-60), 
                Gender.FEMALE, 1000,
                CurrentPosition.MANAGER, Education.HIGHER);
            
            Assert.AreEqual(0, employee.timeUntilRetirement());
        }
    }
}