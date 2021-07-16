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
		public HabitTrackingViewModel(IEnumerable<HabitCheck> habitChecks)
		{
			HabitChecks = new ObservableCollectionExtended<HabitCheckingViewModel>(habitChecks
				.Select(x => new HabitCheckingViewModel(x)).ToList());
		}

		public ObservableCollection<HabitCheckingViewModel> HabitChecks { get; set; }
	}
}
