using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Reactive;
using ReactiveUI;
using DynamicData.Binding;
using App.Models;

namespace App.ViewModels
{
	public class HabitTrackingViewModel : ViewModelBase
	{
		bool _isFinished;
		
		public HabitTrackingViewModel(IEnumerable<HabitCheck> habitChecks)
		{
			HabitChecks = new ObservableCollectionExtended<HabitCheckingViewModel>(habitChecks
				.Select(x => new HabitCheckingViewModel(x)).ToList());

			foreach (var habitCheck in HabitChecks)
			{
				habitCheck.WhenPropertyChanged(x => x.IsChecked, false)
					.Subscribe(x =>
					{
						if (HabitChecks.Last().IsChecked == true)
							IsFinished = true;
					});
			}
		}

		public ObservableCollection<HabitCheckingViewModel> HabitChecks { get; set; }

		public bool IsFinished
		{
			get => _isFinished;
			set => this.RaiseAndSetIfChanged(ref _isFinished, value);
		}
	}
}
