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
        private ObservableCollection<ComponentFunctionVM> componentFunctionsVM;
        private string selectedNameFunc;
        private string aCofficient = "0";
        private string bCofficient = "0";
        private int cCofficient;
        private ComponentFunctionVM selectedFunctionVM;

        public ComponentFunctionVM SelectedFunctionVM
        {
            get => selectedFunctionVM;
            set => Set(ref selectedFunctionVM, value);
        }

        public int CCoefficient
        {
            get => cCofficient;
            set => Set(ref cCofficient, value);
        }

        public ObservableCollection<ComponentFunctionVM> ComponentFunctionsVM
        {
            get => componentFunctionsVM;
            set => Set(ref componentFunctionsVM, value);
        }

        public string ACofficient
        {
            get => aCofficient;
            set
            {                
                if (double.TryParse(value, out double a))
                {
                    Set(ref aCofficient, value);                     
                }
                else if (string.IsNullOrEmpty(value))
                {
                    Set(ref aCofficient, "0");
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
                if (double.TryParse(value, out b))
                {
                    Set(ref bCofficient, value);
                }
                else if (string.IsNullOrEmpty(value))
                {
                    Set(ref bCofficient, "0");
                }
                else
                {
                    BCofficient = bCofficient;
                }

            }
        }

        public string SelectedNameFunc
        {
            get => selectedNameFunc;

            set
            {                
                Set(ref selectedNameFunc, value);
                CoefficientCValues = CValues.GetCValues(ListPossibleFunctions.ListFunctions[SelectedNameFunc]);

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
            ComponentFunctionsVM = new ObservableCollection<ComponentFunctionVM>();            
            AddElement = new LambdaCommand(OnAddElementExecute, CanAddElementExecute);
        }
        private bool CanAddElementExecute(object p) => true;

        private void OnAddElementExecute(object p)
        {
            ComponentFunctionsVM.Add(new ComponentFunctionVM() { 
                ACoefficient = double.Parse(aCofficient), 
                BCoefficient = double.Parse(bCofficient),
                CCoefficient = cCofficient,
                NameFunction = selectedNameFunc});
        }
    }
}
