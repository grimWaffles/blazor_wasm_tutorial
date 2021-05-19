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
    public class StudentApi
    {
        private HttpClient Http; private string AuthToken;

        public StudentApi(HttpClient client,string AuthToken)
        {
            this.Http = client;
            this.AuthToken = AuthToken;
        }

        public async Task<List<Student>> GetStudents()
        {
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthToken);
           
            var response = await Http.GetAsync("https://localhost:44313/api/students");

            if (Convert.ToInt32(response.StatusCode) == 401)
            {
                return null;
            }

            return await Http.GetFromJsonAsync<List<Student>>("https://localhost:44313/api/students");
        }

        public async Task<int> DeleteStudent(int s)
        {
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthToken);

            var responseMessage = await Http.DeleteAsync("https://localhost:44313/api/students/" + s);

            int responseCode = (int)responseMessage.StatusCode;

            return responseCode;
        }

        public async Task<int> PostStudent(Student student)
        {
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthToken);

            var responseMessage=await Http.PostAsJsonAsync("https://localhost:44313/api/students", student);

            int responseCode = (int)responseMessage.StatusCode;

            return responseCode;
        }

        public async Task<int> UpdateStudent(Student student)
        {
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthToken);

            var responseMessage = await Http.PutAsJsonAsync("https://localhost:44313/api/students/"+student.Id, student);

            int responseCode = (int)responseMessage.StatusCode;

            return responseCode;
        }
    }
}
