using PersonStudentTeacher;

namespace TestPersonStudentTeacher
{
    [TestClass]
    public class UnitTestTeacher
    {
        [TestMethod]
        public void TestTeacher()
        {
            //Arrange: Asssumed to be valid values
            int id = 1;
            string name = "Some name";
            int salary = 42;

            //Act
            Teacher t = new Teacher() {Id = id, Name = name, Salary = salary };

            //Assert
            Assert.AreEqual(id, t.Id);
            Assert.AreEqual(name, t.Name);  
            Assert.AreEqual(salary, t.Salary);

            t.Validate();
        }

        [TestMethod]
        public void TestMinimumTeacher()
        {
            //Arrange: Asssumed to be valid values
            int id = 1;
            string name = "X";
            int salary = 1;

            //Act
            Teacher t = new Teacher() { Id = id, Name = name, Salary = salary };

            //Assert
            Assert.AreEqual(id, t.Id);
            Assert.AreEqual(name, t.Name);
            Assert.AreEqual(salary, t.Salary);

            t.Validate();
        }

        [TestMethod]
        public void TestValidateSalary()
        {
            //Arrange
            int id = 1;
            string name = "Some name";
            int salary = 0;
            
            try
            {
                //Act
                Teacher t = new Teacher() { Id = id, Name = name, Salary = salary };

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
        }

        public void TestValidateName<T>(string? name) where T : Exception
        {
            //Arrange
            int id = 1;
            int salary = 42;

            try
            {
                //Act
                Teacher t = new Teacher() { Id = id, Name = name, Salary = salary };

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