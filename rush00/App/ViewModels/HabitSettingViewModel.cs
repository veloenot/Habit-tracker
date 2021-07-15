using System;
using System.Reactive;
using ReactiveUI;
using App.Models;

namespace App.ViewModels
{
	public class HabitSettingViewModel : ViewModelBase
	{
		string title;
		string motivation;
		DateTimeOffset startDate;
		int duration;
		
		public HabitSettingViewModel()
		{
			title = "";
			motivation = "";
			startDate = DateTimeOffset.Now;
			duration = 0;

			IObservable<bool> canStart = this.WhenAnyValue(
				x => x.Title, x => x.Motivation, x => x.Duration,
				(x, y, z) =>
				!string.IsNullOrWhiteSpace(x) &&
				!string.IsNullOrWhiteSpace(y) &&
				z > 0);
			
			StartTracking = ReactiveCommand.Create(() => new Habit
			{
				Title = Title.Trim(),
				Motivation = Motivation.Trim(),
				HabitChecks = new HabitCheck[Duration],
				IsFinished = false
			}, canStart);
		}

		public string Title
		{
			get => title;
			set => this.RaiseAndSetIfChanged(ref title, value);
		}

		public string Motivation
		{
			get => motivation;
			set => this.RaiseAndSetIfChanged(ref motivation, value);
		}

		public DateTimeOffset StartDate
		{
			get => startDate;
			set => this.RaiseAndSetIfChanged(ref startDate, value);
		}

		public int Duration
		{
			get => duration;
			set => this.RaiseAndSetIfChanged(ref duration, value);
		}

		public ReactiveCommand<Unit, Habit > StartTracking { get; }
	}
}
