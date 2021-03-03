using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWorkASU.ViewModel.Base;
using TestWorkASU.Model;
using System.Collections.ObjectModel;

namespace TestWorkASU.ViewModel
{
    class MainViewModel : BaisViewModel
    {
        private ObservableCollection<string> listFunctions;
        public ObservableCollection<string> ListFunctions
        {
            get => listFunctions;

            set => Set(ref listFunctions, value);
        }

        public MainViewModel()
        {
            ListFunctions = new ListPossibleFunctions().ListFunctions;
        }
    }
}
