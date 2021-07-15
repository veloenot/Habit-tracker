using System;

namespace App.Models
{
	public class HabitCheck
	{
		public DateTimeOffset Date { get; set; }
		public bool IsChecked { get; set; } = false;
	}
}
