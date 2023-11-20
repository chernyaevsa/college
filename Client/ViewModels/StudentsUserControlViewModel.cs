using Client.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client.ViewModels
{
	public class StudentsUserControlViewModel : ViewModelBase
	{
		private HttpClient client = new HttpClient();
		private List<Student>? _students;
		public List<Student>? Students 
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
			client.BaseAddress = new Uri("http://localhost:5068/students");
			Update();
		}

		public async Task Update()
		{
			var response = await client.GetAsync("");
			if (!response.IsSuccessStatusCode)
			{
				Message = $"Ошибка сервера {response.StatusCode}";
			}
			var content = await response.Content.ReadAsStringAsync();
			if (content == null)
			{
				Message = "Пустой ответ от сервера";
			}
			Students = JsonSerializer.Deserialize<List<Student>>(content);
		}

		public void Delete() 
		{ 
		
		}

		public void Add() 
		{ 
			
		}

		public void Edit() 
		{ 
		
		}
	}
}
