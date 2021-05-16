using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BlazorWasmTutorial.Data.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string StudentName { get; set; }
        [Required]
        public string Major { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }


        public Student()
        {

        }
    }
}
