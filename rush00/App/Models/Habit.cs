using System;
using System.Collections.Generic;

namespace App.Models
{
	public class Habit
	{
		public string Title { get; set; }
		public string Motivation { get; set; }
		public List<HabitCheck> HabitChecks { get; set; }
		public bool IsFinished { get; set; } = true;
	}
}
