using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonStudentTeacher
{
    public class Student:Person
    {


        //public int Id { get; set; } //Moved to Person
        //public string? Name { get; set; } //Moved to Person

        public int Semester { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Semester: {Semester}";
        }

        public void ValidateSemester()
        {
            if (Semester < 1 || Semester > 8)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        //Moved to base class Person
        //public void ValidateName()
        //{
        //    if (Name == null)
        //        throw new ArgumentNullException(nameof(Name));

        //    if (Name.Length < 1)
        //    {
        //        throw new ArgumentOutOfRangeException();
        //    }
        //}

        
        public override void Validate()
        {
            ValidateSemester();
            //ValidateName(); //Moved to base class Person
            //Now called by base class
            base.Validate();
        }

    }
}
