using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[ApiController]
	[Route("/lessons")]
	public class LessonsController : ControllerBase
	{
		[HttpGet]
		[Route("{id}")]
		public IActionResult GetById(int id)
		{
			var db = new CollegeContext();
			var lesson = db.Lessons.SingleOrDefault(s => s.Id == id);
			if (lesson == null)
				return NotFound();
			return Ok(lesson);
		}
		[HttpGet]
		public IActionResult GetAll()
		{
			var db = new CollegeContext();
			return Ok(db.Lessons);
		}
		[HttpPost]
		public IActionResult Add(Lesson lesson)
		{
			var db = new CollegeContext();
			db.Lessons.Add(lesson);
			db.SaveChanges();
			return Ok(lesson);
		}
		[HttpPut]
		public IActionResult Edit(Lesson lesson)
		{
			var db = new CollegeContext();
			db.Lessons.Update(lesson);
			db.SaveChanges();
			return Ok(lesson);
		}
		[HttpDelete]
		[Route("{id}")]
		public IActionResult Delete(int id)
		{
			var db = new CollegeContext();
			var lesson = db.Lessons.SingleOrDefault(s => s.Id == id);
			if (lesson == null)
				return NotFound();
			return Ok(lesson);
		}
	}
}
