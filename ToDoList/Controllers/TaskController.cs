using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class TaskController : Controller
    {
        ApplicationContext db;
        public TaskController(ApplicationContext context)
        {
            db = context;
        }

        // GET: TaskController
        public IActionResult Index()
        {
            return View(db.Tasks.Where(x => x.End == false));
        }

        // GET: TaskController/DoneList
        public IActionResult DoneList()
        {
            return View(db.Tasks.Where(x => x.End == true));
        }


        // GET: TaskController/Details/5
        public IActionResult Details(int id)
        {
            return View(db.Tasks.FirstOrDefault(x => x.Id == id));
        }

        // GET: TaskController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaskController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TaskModel taskModel)
        {
            taskModel.CreateTime = DateTime.Now;
            db.Tasks.Add(taskModel);
            db.SaveChanges();
            return  RedirectToAction("Index");
        }

        // GET: TaskController/Edit/5
        public IActionResult Edit(int id)
        {
            return View(db.Tasks.FirstOrDefault(x => x.Id == id));
        }

        // POST: TaskController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, TaskModel taskModel)
        {
            TaskModel task = db.Tasks.FirstOrDefault(x => x.Id == id);
            task.Name = taskModel.Name;
            task.Description = taskModel.Description;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: TaskController/Delete/5
        public IActionResult Delete(int id)
        {
            return View(db.Tasks.FirstOrDefault(x => x.Id == id));
        }

        // POST: TaskController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, TaskModel taskModel)
        {
            TaskModel task = db.Tasks.FirstOrDefault(x => x.Id == id);
            db.Tasks.Remove(task);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult End(int id)
        {
            TaskModel task = db.Tasks.FirstOrDefault(x => x.Id == id);
            task.End = true;
            task.EndTime = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
