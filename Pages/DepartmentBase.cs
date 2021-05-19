using BlazorWasmTutorial.Data.API;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorWasmTutorial.Pages
{
    public class DepartmentBase : ComponentBase
    {
        [Inject]
        protected Blazored.LocalStorage.ILocalStorageService storageService { get; set; }
        [Inject]
        protected NavigationManager navigation{get;set;}
        protected bool updateMode { get; set; }
        protected DepartmentApi departmentService { get; set; }
        protected string Message { get; set; }

        protected Data.Models.Department department = new Data.Models.Department();
        protected List<Data.Models.Department> deptList = new List<Data.Models.Department>();
       

        protected async override Task OnInitializedAsync()
        {
            string token = await storageService.GetItemAsync<string>("token");

            departmentService = new DepartmentApi(new HttpClient(), token);

            await LoadDepartments();

            await base.OnInitializedAsync();
        }

        protected async Task LoadDepartments()
        {
            var deptList = await departmentService.GetDepartments();

            if (deptList != null)
            {
                this.deptList = deptList;
            }
            else
            {
                this.deptList = null;
                await ClearCache();
            }

        }

        protected void ClearData()
        {
            department = new Data.Models.Department();

            updateMode = false;
        }

        protected async Task ClearCache()
        {
            await storageService.ClearAsync();

        }

        protected async Task SaveDepartment()
        {
            if (!updateMode)
            {
                int responseCode = await departmentService.PostDepartment(department);

                if (responseCode == 201 || responseCode == 200)
                {
                    Message = "**Department Saved Successfully";
                }
                else
                {
                    Message = "**Failed to save Department. Error Code: "+responseCode;

                }

            }
            else
            {
                int responseCode = await departmentService.UpdateDepartment(department);

                if (responseCode == 204 || responseCode == 200)
                {
                    Message = "Department updated Successfully";
                }
                else
                {
                    Message = "Failed to update Department. Error Code: " + responseCode;

                }
            }

            ClearData();
            deptList = new List<Data.Models.Department>();
            await LoadDepartments();
        }

        protected void LoadUpdateDataButton(int deptId)
        {
            var smallListDept = deptList.Where(d => d.Id == deptId).ToList();

            var dept = smallListDept[0];

            department.Code = dept.Code;
            department.DepartmentName = dept.DepartmentName;
            department.School = dept.School;
            department.created_at = dept.created_at;
            department.updated_at = DateTime.Now;

            updateMode = true;
        }

        protected async Task DeleteDepartment(int deptId)
        {
            int responseCode= await departmentService.DeleteDepartment(deptId);
            
            if (responseCode == 204 || responseCode == 200)
            {
                Message = "Department delete Successfully";

                deptList = new List<Data.Models.Department>();

                ClearData();
                await LoadDepartments();
            }
            else
            {
                Message = "Failed to delete Department. Error Code: " + responseCode;

            }
            
        }

        protected void ToLoginPage()
        {
            navigation.NavigateTo("/login");
        }
    }
}
