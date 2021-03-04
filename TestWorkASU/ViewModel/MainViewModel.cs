using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWorkASU.ViewModel.Base;
using TestWorkASU.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace TestWorkASU.ViewModel
{
    class MainViewModel : BaseViewModel
    {
        private ObservableCollection<string> listFunctions;
        private ObservableCollection<int> coefficientCValues;
        private ObservableCollection<ComponentFuction> componentFuctions;
        private string selectedFunction;
        private string aCofficient;
        private string bCofficient;

        public ObservableCollection<ComponentFuction> ComponentFuctions
        {
            get => componentFuctions;
            set => Set(ref componentFuctions, value);
        }

        public string ACofficient
        {
            get => aCofficient;

            set
            {
                double a;
                if (double.TryParse(value, out a) || string.IsNullOrEmpty(value))
                {
                    Set(ref aCofficient, value);                     
                }
                else
                {   
                    ACofficient = aCofficient;
                }

            }
        }
        public string BCofficient
        {
            get => bCofficient;

            set
            {
                double b;
                if (double.TryParse(value, out b) || string.IsNullOrEmpty(value))
                {
                    Set(ref bCofficient, value);
                }
                else
                {
                    BCofficient = bCofficient;
                }

            }
        }

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
        
        public ICommand AddElement { get; }

        public MainViewModel()
        {
            ListFunctions = ListPossibleFunctions.GetListFunctions();
            ComponentFuctions = new ObservableCollection<ComponentFuction>();            
            AddElement = new LambdaCommand(OnAddElementExecute, CanAddElementExecute);
        }
        private bool CanAddElementExecute(object p) => true;

        private void OnAddElementExecute(object p)
        {
            
        }
    }
}
