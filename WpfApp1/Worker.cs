using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Worker
    {
        public int Id { get; set; }
        public string SurnameAndInitials { get; set; }
        public string Education { get; set; }
        public string Specialty { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Worker() { }
        public Worker(int id, string surnameAndInitials, string education, string specialty, DateTime dateOfBirth)
        {
            Id = id;
            SurnameAndInitials = surnameAndInitials;
            Education = education;
            Specialty = specialty;
            DateOfBirth = dateOfBirth;
        }
        override public string ToString()
        {
            return $"{Id}, {SurnameAndInitials}, {Education}, {Specialty}, {DateOfBirth.ToShortDateString()}";
        }
    }
}
