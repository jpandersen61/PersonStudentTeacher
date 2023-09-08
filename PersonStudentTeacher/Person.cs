using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonStudentTeacher
{
    public class Person
    {
        public int Id { get; set; } //Moved to Person
        public string? Name { get; set; } //Moved to Person

        public override string ToString()
        {
            return "";
        }

        public void ValidateName()
        {
            if (Name == null)
                throw new ArgumentNullException(nameof(Name));

            if (Name.Length < 1)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public virtual void Validate()
        {            
            ValidateName();
        }
    }
}
