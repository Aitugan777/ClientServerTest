using Client.Models;
using Newtonsoft.Json;

namespace Client.Data
{
    public static class DataBase
    {
        public static List<AitukStatus> GetStatusesFromDatabase()
        {
            return new List<AitukStatus>() { 
                new AitukStatus() { Name = "Открыт", Id = 0 },
                new AitukStatus() {Name = "Закрыт", Id = 1 } };
        }

        public static List<AitukTask> GetTasksFromDatabase()
        {
            string res;
            string reqUrl = $"https://localhost:7162/tasks";
            using (var client = new HttpClient())
            {
                res = client.GetAsync(reqUrl).Result.Content.ReadAsStringAsync().Result;
            }

            List<AitukTask>? tasks = JsonConvert.DeserializeObject<List<AitukTask>>(res);

            return tasks;
        }

        public static AitukTask GetTaskByIdFromDatabase(int id)
        {
            string res;
            string reqUrl = $"https://localhost:7162/tasks/{id}";
            using (var client = new HttpClient())
            {
                res = client.GetAsync(reqUrl).Result.Content.ReadAsStringAsync().Result;
            }

            AitukTask? task = JsonConvert.DeserializeObject<AitukTask>(res);

            return task;
        }
    }
}
