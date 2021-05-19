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
        [Inject]
        public Blazored.LocalStorage.ILocalStorageService storageService { get; set; }
        public StudentApi studentService { get; set; }
        protected string IdString { get; set; }
        protected string DepartmentIdString { get; set; }
        protected bool ToUpdate { get; set; }
        protected string Message { get; set; }

        protected List<Data.Models.Student> studentList = new List<Data.Models.Student>();
        protected Data.Models.Student student = new Data.Models.Student();
       

        protected async override Task OnInitializedAsync()
        {
            string token = await storageService.GetItemAsync<string>("token");

            studentService = new StudentApi(new System.Net.Http.HttpClient(),token);

            await LoadStudentData();

            await base.OnInitializedAsync();
        }

        private async Task LoadStudentData()
        {
           var studentList = await studentService.GetStudents();

            if (studentList != null)
            {
                this.studentList = studentList;
            }
            else
            {
                this.studentList = null;
                await ClearCache();
            }

        }

        protected async Task SaveStudent()
        {
            student.DepartmentId = Convert.ToInt32(DepartmentIdString);
            student.updated_at = DateTime.Now;

            if (ToUpdate)
            {
                int responseCode=await studentService.UpdateStudent(student);

                if (responseCode == 204 || responseCode == 200)
                {
                    Message = "**Record updated successfully";
                }
                else
                {
                    Message = "**Failed to update record. Error Code: " + responseCode;

                }
            }
            else
            {
                student.created_at = DateTime.Now;
                int responseCode=await studentService.PostStudent(student);

                if (responseCode == 201 || responseCode == 200)
                {
                    Message = "**Record saved Successfully";
                }
                else
                {
                    Message = "**Failed to save record. Error Code: " + responseCode;

                }
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
            int responseCode=await studentService.DeleteStudent(id);

            if (responseCode == 204 || responseCode == 200)
            {
                Message = "**Record deleted successfully";

                studentList = new List<Data.Models.Student>();
                ClearData();
                await LoadStudentData();
            }
            else
            {
                Message = "**Failed to delete record. Error Code: " + responseCode;

            }

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

        protected async Task ClearCache()
        {
            await storageService.ClearAsync();

        }
        protected void ToLoginPage()
        {
            navigationManager.NavigateTo("/login");
        }

    }
}
