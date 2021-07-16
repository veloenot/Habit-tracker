using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;
using DynamicData.Binding;
using App.Models;

namespace App.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
		string? _title;
		ViewModelBase? _content;

        public MainWindowViewModel()
		{
			SetHabit();
		}

		public string? Title
		{
			get => _title;
			set => this.RaiseAndSetIfChanged(ref _title, value);
		}

		public ViewModelBase? Content
		{
			get => _content;
			set => this.RaiseAndSetIfChanged(ref _content, value);
		}

		public void SetHabit()
		{
			var vm = new HabitSettingViewModel();
			Title = "Set new habit to track";
			vm.StartTracking.Take(1)
				.Subscribe(model =>
				{
					model.HabitChecks.AddRange(
						Enumerable.Range(0, vm.Duration)
						.Select(offset => new HabitCheck
						{
							Date = vm.StartDate.AddDays(offset + 1)
						})
					.ToList());
					TrackHabit(model);
				});
			Content = vm;
		}

		public void TrackHabit(Habit habit)
		{
			var vm = new HabitTrackingViewModel(habit.HabitChecks.OrderBy(x => x.Date));
			Title = habit.Title;
			vm.WhenPropertyChanged(x => x.IsFinished, false)
				.Subscribe(x =>
				{
					FinishHabit();
				});
			Content = vm;
		}

		public void FinishHabit()
		{
			var vm = new CongratulationsViewModel();
			Title = "Spasibo!";
			Content = vm;
		}
	}
}
