using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[ApiController]
	[Route("/students")]
	public class StudentsController : ControllerBase
	{
		[HttpGet]
		[Route("{id}")]
		public IActionResult GetById(int id)
		{
			var db = new CollegeContext();
			var student = db.Students.SingleOrDefault(s => s.Id == id);
			if (student == null)
				return NotFound();
			return Ok(student);
		}
		[HttpGet]
		public IActionResult GetAll()
		{
			var db = new CollegeContext();
			return Ok(db.Students);
		}
		[HttpPost]
		public IActionResult Add(Student student)
		{
			var db = new CollegeContext();
			db.Students.Add(student);
			db.SaveChanges();
			return Ok(student);
		}
		[HttpPut]
		public IActionResult Edit(Student student) 
		{
			var db = new CollegeContext();
			db.Students.Update(student);
			db.SaveChanges();
			return Ok(student);
		}
		[HttpDelete]
		[Route("{id}")]
		public IActionResult Delete(int id)
		{
			var db = new CollegeContext();
			var student = db.Students.SingleOrDefault(s => s.Id == id);
			if (student == null)
				return NotFound();
			return Ok(student);
		}
	}
}
