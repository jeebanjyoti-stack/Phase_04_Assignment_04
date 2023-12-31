﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_04_Jenkins.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private static List<Task> tasks = new List<Task>
        {
           new Task { Id = 1, Title = "Complete Project Proposal", Description = "Write and submit the project proposal document for review." },
           new Task { Id = 2, Title = "Client Meeting Preparation", Description = "Prepare presentation materials and agenda for the upcoming client meeting." },

        };

        [HttpGet]
        public ActionResult<IEnumerable<Task>> Get()
        {
            return tasks;
        }

        [HttpGet("{id}")]
        public ActionResult<Task> Get(int id)
        {
            var task = tasks.Find(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return task;
        }

        [HttpPost]
        public void Post([FromBody] Task task)
        {
            task.Id = tasks.Count + 1;
            tasks.Add(task);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Task updatedTask)
        {
            var task = tasks.Find(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            task.Title = updatedTask.Title;
            task.Description = updatedTask.Description;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var task = tasks.Find(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            tasks.Remove(task);
            return NoContent();
        }
    }
}
