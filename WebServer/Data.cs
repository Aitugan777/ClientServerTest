using WebServer.Models;

namespace WebServer
{
    public static class Data
    {
        public static List<AitukTask> Tasks { get; set; }

        public static List<AitukStatus> Statuses
        {
            get
            {
                if (Statuses.Count == 0)
                {
                    Statuses.Add(new AitukStatus() { Id = 0, Name = "Создана" });
                    Statuses.Add(new AitukStatus() { Id = 1, Name = "В работе" });
                    Statuses.Add(new AitukStatus() { Id = 2, Name = "Завершена" });
                }
                return Statuses;
            }
            set
            {
                Statuses = value;
            }
        }

    }
}
