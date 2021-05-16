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
    public class StudentApi
    {
        private HttpClient Http;
        public StudentApi(HttpClient client)
        {
            this.Http = client;
        }

        public async Task<List<Student>> GetStudents()
        {
            return await Http.GetFromJsonAsync<List<Student>>("https://localhost:44313/api/students");
        }

        public async Task DeleteStudent(Student s)
        {
            var result = await Http.DeleteAsync("https://localhost:44313/api/students/" + s.Id);
        }

        public async Task PostStudent(Student student)
        {
            string json = JsonConvert.SerializeObject(student);

            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            await Http.PostAsync("https://localhost:44313/api/students", content);
        }

        public async Task UpdateStudent(Student student)
        {
            string json = JsonConvert.SerializeObject(student);

            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            await Http.PutAsync("https://localhost:44313/api/students", content);
        }
    }
}
