using Client.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client.ViewModels
{
	public class StudentsUserControlViewModel : ViewModelBase
	{
		private Student _selectedStudent;
		public Student SelectedStudent
		{
			get => _selectedStudent;
			set => this.RaiseAndSetIfChanged(ref _selectedStudent, value);
		}

		private HttpClient client = new HttpClient();
		private ObservableCollection<Student> _students;
		public ObservableCollection<Student> Students 
		{
			get => _students;
			set => this.RaiseAndSetIfChanged(ref _students, value);
		}

		private string _message;
		public string Message
		{
			get => _message;
			set => this.RaiseAndSetIfChanged(ref _message, value);
		}

		public StudentsUserControlViewModel() 
		{
			client.BaseAddress = new Uri("http://localhost:5068");
			Update();
		}

		public async Task Update()
		{
			var response = await client.GetAsync("/students");
			if (!response.IsSuccessStatusCode)
			{
				Message = $"Ошибка сервера {response.StatusCode}";
				return;
			}
			var content = await response.Content.ReadAsStringAsync();
			if (content == null)
			{
				Message = "Пустой ответ от сервера";
				return;
			}
			Students = JsonSerializer.Deserialize<ObservableCollection<Student>>(content);
			Message = "";
		}

		public async Task Delete() 
		{
			if (SelectedStudent == null) return;
			var response = await client.DeleteAsync($"/students/{SelectedStudent.id}");
			if (!response.IsSuccessStatusCode)
			{
				Message = "Ошибка удаления со стороны сервера";
				return;
			}
			Students.Remove(SelectedStudent);
			SelectedStudent = null;
			Message = "";
		}

		public async Task Add() 
		{
			var student = new Student();
			var response = await client.PostAsJsonAsync($"/students", student);
			if (!response.IsSuccessStatusCode)
			{
				Message = "Ошибка добавления со стороны сервера";
				return;
			}
			var content = await response.Content.ReadFromJsonAsync<Student>();
			if (content == null)
			{
				Message = "При добавлении сервер отправил пустой ответ";
				return;
			}
			student = content;
			Students.Add(student);
			SelectedStudent = student;
		}

		public void Edit() 
		{ 
		
		}
	}
}
