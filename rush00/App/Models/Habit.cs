using System;

namespace App.Models
{
	public class Habit
	{
		public string Title { get; set; }
		public string Motivation { get; set; }
		public HabitCheck[] HabitChecks { get; set; }
		public bool IsFinished { get; set; } = true;
	}
}
