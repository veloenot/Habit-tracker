using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;
using App.ViewModels;

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
			vm.StartTracking.Take(1).Subscribe(x => TrackHabit());
			Content = vm;
		}

		public void TrackHabit()
		{
			Content = new HabitTrackingViewModel();
			Title = "An hour of .NET a day";
		}
	}
}
