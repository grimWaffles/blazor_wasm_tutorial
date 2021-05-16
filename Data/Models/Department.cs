using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlazorWasmTutorial.Data.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "This is required!")]
        public string Code { get; set; }
        [Required(ErrorMessage = "This is required!")]
        public string DepartmentName { get; set; }
        [Required(ErrorMessage = "This is required!")]
        public string School { get; set; }

        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

        public Department()
        {

        }
    }
}
