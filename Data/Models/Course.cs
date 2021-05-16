using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWasmTutorial.Data.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string CourseType { get; set; }
        [Required]
        public int Credit { get; set; }

        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

        public Course()
        {

        }
    }
}
