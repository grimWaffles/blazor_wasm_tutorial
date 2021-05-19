using BlazorWasmTutorial.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasmTutorial.Data.API
{
    public class DepartmentApi
    {
        private HttpClient Http;private string AuthToken;
        public DepartmentApi(HttpClient client,string token)
        {
            this.Http = client;
            this.AuthToken = token;
        }

        public async Task<List<Department>> GetDepartments()
        {
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthToken);

            var response= await Http.GetAsync("https://localhost:44313/api/departments");

            if (Convert.ToInt32(response.StatusCode) == 401)
            {
                return null;
            }

            return await Http.GetFromJsonAsync<List<Department>>("https://localhost:44313/api/departments");
        }

        public async Task<int> PostDepartment(Department department)
        {
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthToken);

            var responseMessage = await Http.PostAsJsonAsync("https://localhost:44313/api/departments", department);

            int responseCode = (int)responseMessage.StatusCode;

            return responseCode;
        }

        public async Task<int> UpdateDepartment(Department department)
        {
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthToken);

            var responseMessage = await Http.PutAsJsonAsync("https://localhost:44313/api/departments/" + department.Id, department);

            int responseCode = (int)responseMessage.StatusCode;

            return responseCode;
        }

        public async Task<int> DeleteDepartment(int id)
        {
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthToken);

            var responseMessage = await Http.DeleteAsync("https://localhost:44313/api/departments/"+id);

            int responseCode = (int)responseMessage.StatusCode;

            return responseCode;
        }
    }
}
