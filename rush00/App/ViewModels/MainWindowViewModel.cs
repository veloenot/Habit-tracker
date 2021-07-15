using System;
using System.Collections.Generic;
using System.Text;
using System.Reactive;
using ReactiveUI;

namespace App.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
		{
			Setting = new HabitSettingViewModel();
			Content = Setting;
		}

		ViewModelBase? content;

		public ViewModelBase? Content
		{
			get => content;
			set => this.RaiseAndSetIfChanged(ref content, value);
		}

		public string Greeting => "Welcome to Avalonia!";
    
		public HabitSettingViewModel Setting { get; }
	}
}
