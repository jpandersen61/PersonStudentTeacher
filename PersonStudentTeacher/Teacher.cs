using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonStudentTeacher;

namespace PersonStudentTeacher
{
    public class Teacher : Person
    {
        //public int Id { get; set; } //Moved to Person
        //public string? Name { get; set; } //Moved to Person

        public int Salary { get; set; } 
                              
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Salary: {Salary}";
        }

        public override void Validate()
        {
            //ValidateName(); //Moved base class Person
            ValidateSalary();
        }

        //Moved to base class Person
        //public void ValidateName()
        //{
        //    if (Name == null)
        //       throw new ArgumentNullException(nameof(Name));   
            
        //    if (Name.Length < 1)
        //    {
        //        throw new ArgumentOutOfRangeException();
        //    }
        //}

        public void ValidateSalary()
        {
            if (Salary < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
