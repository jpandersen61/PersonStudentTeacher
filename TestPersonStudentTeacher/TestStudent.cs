
using PersonStudentTeacher;

namespace TestPersonStudentTeacher
{
    [TestClass]
    public class UnitTestStudent
    {
        public void TestStudent(string name, int semester)
        {
            //Arrange: Asssumed to be valid values
            int id = 1;
            
            //Act
            Student s = new Student() { Id = id, Name = name, Semester = semester };

            //Assert
            Assert.AreEqual(id, s.Id);
            Assert.AreEqual(name, s.Name);
            Assert.AreEqual(semester, s.Semester);

            s.Validate();
        }

        [TestMethod]
        public void TestStudentMaxLimits()
        {
            TestStudent("Don't care",8);
        }

        [TestMethod]
        public void TestStudentMinLimits()
        {
            TestStudent("X",1); ;
        }



        /*public void TestValidateSemester(int semester)
        {
            //Arrange
            int id = 1;
            string name = "Some name";
            
            try
            {
                //Act
                Student t = new Student() { Id = id, Name = name, Semester = semester };

                //Assert
                Assert.Fail("NO exception thrown");
            }

            catch (ArgumentOutOfRangeException ex)
            {

            }

            catch (Exception ex)
            {
                //Assert
                Assert.Fail("Wrong exception thrown");
            }
        }*/

        public void TestValidateSemester(int semester)
        {
            //Arrange
            int id = 1;
            string name = "Some name";

            Assert.ThrowsException<ArgumentOutOfRangeException>(
                     () => new Student() { Id = id, Name = name, Semester = semester });    
        }

        [TestMethod]
        public void TestValidateSemesterLowerOutOfBounds()
        {
            TestValidateSemester(0);
        }

        [TestMethod]
        public void TestValidateSemesterUpperOutOfBounds()
        {
            TestValidateSemester(9);
        }

        /*public void TestValidateName<T>(string? name) where T : Exception
        {
            //Arrange
            int id = 1;
            int semester = 3;

            try
            {
                //Act
                Student t = new Student() { Id = id, Name = name, Semester = semester };

                //Assert
                Assert.Fail("NO exception thrown");
            }

            //catch (ArgumentNullException ex)
            catch (T ex)
            {

            }

            catch (Exception ex)
            {
                //Assert
                Assert.Fail("Wrong exception thrown");
            }
        }*/

        public void TestValidateName<T>(string? name) where T : Exception
        {
            //Arrange
            int id = 1;
            int semester = 3;

            Assert.ThrowsException<T>(() => new Student() { Id = id, Name = name, Semester = semester });
            
        }

        [TestMethod]
        public void TestValidateNameNull()
        {
            TestValidateName<ArgumentNullException>(null);
        }

        [TestMethod]
        public void TestValidateNameToShort()
        {
            TestValidateName<ArgumentOutOfRangeException>("");
        }
    }
}
