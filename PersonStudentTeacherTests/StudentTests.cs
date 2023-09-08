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
    public class StudentTests
    {
        const int aValidSemester = 3;
        const int aValidId = 1;
        const string aValidName = "x";
        const string aLongerValidName = "xxxxxx";
        const string aTooShortName = "";
        const string aNullName = null;

        [TestMethod()]
        public void ToStringTest()
        {
            Student s = new Student() {Id=aValidId, Name = aValidName, Semester = aValidSemester };
            Assert.AreEqual<string>("Id: 1, Name: x, Semester: 3",s.ToString());
        }

        [TestMethod()]
        [DataRow(1)]
        [DataRow(5)]
        [DataRow(8)]
        public void ValidateSemesterTest(int semester)
        {
            Student s = new Student() { Id = aValidId, Name = aValidName, Semester = semester };
            s.ValidateSemester();
        }

        [TestMethod()]
        [DataRow(0)]
        [DataRow(9)]
        public void ValidateSemesterTestException(int semester)
        {
            Student s = new Student() {Id = aValidId, Name = aValidName, Semester = semester};
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => s.ValidateSemester());
        }

        [TestMethod()]
        [DataRow(aValidName)]
        [DataRow(aLongerValidName)]
        public void ValidateNameTest(string name)
        {
            Student s = new Student() { Id = aValidId, Name = name, Semester = aValidSemester };
            s.ValidateName();
        }

        [TestMethod()]
        
        public void ValidateNameTestException()
        {
            Student sNullName = new Student() { Id = aValidId, Name = aNullName, Semester = aValidSemester };
            Assert.ThrowsException<ArgumentNullException>(() => sNullName.ValidateName());

            Student sToShortName = new Student() { Id = aValidId, Name = aTooShortName, Semester = aValidSemester };
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => sToShortName.ValidateName());
        }

        [TestMethod()]
        [DataRow("x",1)]
        [DataRow("xxxxxx",1)]
        [DataRow("x",5)]
        [DataRow("xxxxxx",5)]
        [DataRow("x",8)]
        [DataRow("xxxxxx",8)]
        public void ValidateTest(string name, int semester)
        {
            Student s = new Student() { Id = aValidId, Name = name, Semester = semester };
            s.Validate();
        }
    }
}   