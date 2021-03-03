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
        private ObservableCollection<int> coefficientCValues;
        private string selectedFunction;

        public string SelectedFunction
        {
            get => selectedFunction;

            set
            {                
                Set(ref selectedFunction, value);
                CoefficientCValues = CValues.GetCValues(ListPossibleFunctions.ListFunctions[SelectedFunction]);

            }
        }
        public ObservableCollection<string> ListFunctions
        {
            get => listFunctions;

            set => Set(ref listFunctions, value);
        }

        public ObservableCollection<int> CoefficientCValues
        {
            get => coefficientCValues;

            set => Set(ref coefficientCValues, value);
        }

        public MainViewModel()
        {
            ListFunctions = ListPossibleFunctions.GetListFunctions();            
        }
    }
}
