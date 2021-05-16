using BlazorWasmTutorial.Data.API;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWasmTutorial.Pages
{
    public class StudentBase : ComponentBase
    {
        [Inject]
        public NavigationManager navigationManager { get; set; }
        public StudentApi studentService { get; set; }

        protected Data.Models.Student student = new Data.Models.Student();
        protected string IdString { get; set; }
        protected string DepartmentIdString { get; set; }

        protected List<Data.Models.Student> studentList = new List<Data.Models.Student>();

        private bool ToUpdate { get; set; }

        protected async override Task OnInitializedAsync()
        {
            studentService = new StudentApi(new System.Net.Http.HttpClient());

            await LoadStudentData();

            await base.OnInitializedAsync();
        }

        private async Task LoadStudentData()
        {
           this.studentList = await studentService.GetStudents();
        }

        protected async Task SaveStudent()
        {
            student.DepartmentId = Convert.ToInt32(DepartmentIdString);
            student.updated_at = DateTime.Now;

            if (ToUpdate)
            {
                await studentService.UpdateStudent(student);
            }
            else
            {
                student.created_at = DateTime.Now;
                await studentService.PostStudent(student);
            }

            ToUpdate = false;
            ClearData();
            
            await LoadStudentData();
        }

        protected void LoadTextFields(int id)
        {
            var s = studentList.Where(d => d.Id == id).ToList()[0];

            student.StudentName = s.StudentName;
            student.Major = s.Major;
            student.DepartmentId = s.DepartmentId;
            student.updated_at = DateTime.Now;
            DepartmentIdString = s.DepartmentId.ToString();

            ToUpdate = true;
        }

        protected async Task DeleteStudent(int id)
        {
            var s = studentList.Where(d => d.Id == id).ToList()[0];

            await studentService.DeleteStudent(s);

            studentList = null;
            ClearData();
            await LoadStudentData();
        }

        protected void ClearData()
        {
            DepartmentIdString = "";
            student = new Data.Models.Student();
        }

        protected async Task OnDepartmentIdChange(ChangeEventArgs args)
        {
            string searchText = args.Value.ToString();

            if (searchText.Equals(""))
            {
                ClearData();
                await LoadStudentData();
            }
            else
            {
                try
                {
                    studentList = studentList.Where(c => c.DepartmentId == Convert.ToInt32(searchText)).ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace.ToString());
                }
            }
        }

    }
}
