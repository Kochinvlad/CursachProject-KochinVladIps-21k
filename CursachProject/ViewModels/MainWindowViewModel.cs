using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursachProject.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
		private string _name;
        private string _Fullname;

        public string Name
		{
			get { return _name; }
			set { this.RaiseAndSetIfChanged(ref _name, value); }
		}

        public string FullName
        {
            get { return _Fullname; }
            set { this.RaiseAndSetIfChanged(ref _Fullname, value); }
        }

    }
}
