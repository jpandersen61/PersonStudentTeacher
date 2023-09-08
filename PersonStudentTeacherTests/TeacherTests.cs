using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonStudentTeacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonStudentTeacher.Tests
{
    [TestClass()]
    public class TeacherTests
    {
        const int aValidId = 1;
        const string aValidName = "x";
        const string aLongerValidName = "xxxxxx";
        const string aTooShortName = "";
        const string aNullName = null;
        const int minValidSalary = 0;
        const int aValidSalary = 42;
        const int tooLowSalary = (-1);
        const int muchTooLowSalary = (-42);

        [TestMethod()]
        [DataRow(aValidName)]
        [DataRow(aLongerValidName)]
        public void ValidateNameTest(string name)
        {
            Teacher t = new Teacher() { Id = aValidId, Name = name, Salary = aValidSalary };
            t.ValidateName();
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Teacher t = new Teacher() { Id = aValidId, Name = aValidName, Salary = aValidSalary };
            Assert.AreEqual<string>("Id: 1, Name: x, Salary: 42", t.ToString());
        }

        [TestMethod()]
        public void ValidateTestException()
        {
            Teacher tNullName = new Teacher() { Id = aValidId, Name = aNullName, Salary = aValidSalary };
            Assert.ThrowsException<ArgumentNullException>(() => tNullName.ValidateName());

            Teacher tToShortName = new Teacher() { Id = aValidId, Name = aTooShortName, Salary = aValidSalary };
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => tToShortName.ValidateName());
        }

        

        [TestMethod()]
        [DataRow(minValidSalary)]
        [DataRow(aValidSalary)]
        public void ValidateSalaryTest(int salary)
        {
            Teacher t = new Teacher() { Id = aValidId, Name = aValidName, Salary = salary };
            t.ValidateSalary();
        }

        [TestMethod()]
        [DataRow(tooLowSalary)]
        [DataRow(muchTooLowSalary)]
        public void ValidateSalaryTestException(int salary)
        {
            Teacher t = new Teacher() { Id = aValidId, Name = aValidName, Salary = salary };
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => t.ValidateSalary());
            
        }
    }
}