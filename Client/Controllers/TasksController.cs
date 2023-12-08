using Microsoft.AspNetCore.Mvc;
using Client.Data;
using Client.Models;
using System.Diagnostics;

namespace Client.Controllers
{
    public class TasksController : Controller
    {

        // Метод для отображения списка задач
        public ActionResult Index()
        {
            List<AitukTask> tasks = DataBase.GetTasksFromDatabase(); // Получаем список задач из базы данных
            return View(tasks);
        }

        // Метод для отображения формы добавления задачи
        public ActionResult AddTask()
        {
            // Здесь будут дополнительные действия для отображения формы добавления задачи
            return View();
        }

        // Метод для обработки добавления задачи
        [HttpPost]
        public ActionResult AddTask(AitukTask task)
        {
            if (ModelState.IsValid)
            {
                // Здесь будут дополнительные действия для добавления задачи в базу данных
                return RedirectToAction("Index");
            }
            return View(task);
        }

        // Метод для отображения формы редактирования задачи
        public ActionResult EditTask(int id)
        {
            AitukTask task = DataBase.GetTaskByIdFromDatabase(id); // Получаем задачу из базы данных по ID
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        // Метод для обработки редактирования задачи
        [HttpPost]
        public ActionResult EditTask(AitukTask task)
        {
            if (ModelState.IsValid)
            {
                // Здесь будут дополнительные действия для редактирования задачи в базе данных
                return RedirectToAction("Index");
            }
            return View(task);
        }

        // Метод для удаления задачи
        public ActionResult DeleteTask(int id)
        {
            // Здесь будут дополнительные действия для удаления задачи из базы данных
            return RedirectToAction("Index");
        }
    }
}
