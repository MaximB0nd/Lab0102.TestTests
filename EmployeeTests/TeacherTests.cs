using System;
using NUnit.Framework;
using EmployeeLibrary;
using static EmployeeLibrary.Employee;


namespace EmployeeTests
{
    [TestFixture]
    public class TeacherTests
    {
        
        public void MonthPaymentTests(double salary, Employee.CurrentPosition currentPosition, double expected)
        {
            //arrange
            Employee employee = new Employee("Вася", DateTime.Now.AddYears(-35), Gender.MALE, (decimal) salary, currentPosition, Education.SECONDARY);

            //act
            decimal actual = employee.monthPayment();

            //assert
            Assert.AreEqual((decimal) expected, actual);
        }

        [Test]
        public void runMonthPaymentTests()
        {
            MonthPaymentTests(1000.0d, CurrentPosition.DIRECTOR, 1150.0d);
            MonthPaymentTests(1000.0d, CurrentPosition.MANAGER, 1030.0d);
            MonthPaymentTests(1000.0d, CurrentPosition.JUNIOR, 1050.0d);
            MonthPaymentTests(1000.0d, CurrentPosition.MIDDLE, 1100.0d);
            MonthPaymentTests(1000.0d, CurrentPosition.SENIOR, 1150.0d);
            
            
        }
        
        public void CheckNameTests(string name, bool expected)
        {
            //arrange
            Employee employee = new Employee(name, DateTime.Now.AddYears(-35), Gender.MALE, 1000.0M, CurrentPosition.SENIOR, Education.SECONDARY);

            //act
            bool actual = employee.checkName();

            //assert
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void runCheckNameTests()
        {
            //CheckNameTests("Fedor", true);
            CheckNameTests("Федор Борисович1", true);
            CheckNameTests("Федор1",  true);
            CheckNameTests("Федор-Борисович", true);
            CheckNameTests("Фz", true);
            CheckNameTests("1Федор", false);
        }

        

    }
}