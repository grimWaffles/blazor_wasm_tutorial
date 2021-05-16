using BlazorWasmTutorial.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasmTutorial.Data.API
{
    public class DepartmentApi
    {
        private HttpClient Http;
        public DepartmentApi(HttpClient client)
        {
            this.Http = client;
        }

        public async Task<List<Department>> GetDepartments()
        {
            return await Http.GetFromJsonAsync<List<Department>>("https://localhost:44313/api/departments");
        }

        public async Task PostDepartment(Department department)
        {
            string json = JsonConvert.SerializeObject(department);

            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var res=await Http.PostAsync("https://localhost:44313/api/students", content);
        }

        public async Task UpdateDepartment(Department department)
        {
            string json = JsonConvert.SerializeObject(department);

            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var res=await Http.PutAsync("https://localhost:44313/api/students", content);
        }

        public async Task DeleteDepartment(int id)
        {
            var result = await Http.DeleteAsync("https://localhost:44313/api/departments/" + id);
        }
    }
}
