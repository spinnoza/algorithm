using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public  class Student
    {
        public  int ClassNo { get; set; }
        public  int Age { get; set; }
        public  int Id { get; set; }

        public Student(int classNo, int age, int id)
        {
            ClassNo = classNo;
            Age = age;
            Id = id;
        }
    }
}
