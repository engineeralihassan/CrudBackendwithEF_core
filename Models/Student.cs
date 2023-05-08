using System;
using System.ComponentModel.DataAnnotations;

namespace FullStackCrud.Models
{
    public class Student
    {
        [Key]
        public Guid id { get; set; }
        public string name { get; set; }
        public string fatherName { get; set; }
        public string standar { get; set; }
        public string section { get; set; }
        public int rollNo { get; set; }
        public string contact { get; set; }
        public int fees { get; set; }
        public double cgpa { get; set; }
        public string degree { get; set; }
    }
}
