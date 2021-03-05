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

        public ObservableCollection<ComponentFunctionVM> ComponentFunctionsVM
        {
            get => componentFunctionsVM;
            set => Set(ref componentFunctionsVM, value);
        }

        public string SelectedNameFunc
        {
            get => selectedNameFunc;
            set
            {
                Set(ref selectedNameFunc, value);
                if (SelectedNameFunc != null)
                CoefficientCValues = CValues.GetCValues(ListPossibleFunctions.ListFunctions[SelectedNameFunc]);
                if (componentFunctionsVM.Count >= 1 && SelectedNameFunc!=null && SelectedFunctionVM!=null)
                SelectedFunctionVM.NameFunction = value;
                if (selectedFunctionVM != null && selectedFunctionVM.CCoefficient != 0 && CoefficientCValues.Contains(selectedFunctionVM.CCoefficient))
                {
                    CCoefficient = selectedFunctionVM.CCoefficient;
                }
                else if (CoefficientCValues != null)
                {
                    CCoefficient = coefficientCValues[0];
                }                
            }
        }

        public string ACofficient
        {
            get => aCofficient;
            set
            {
                if (double.TryParse(value, out double a))
                {
                    Set(ref aCofficient, value);
                    if (ComponentFunctionsVM.Count >= 1 && selectedFunctionVM!=null)
                        selectedFunctionVM.ACoefficient = double.Parse(value);
                }
                else if (string.IsNullOrEmpty(value))
                {
                    Set(ref aCofficient, "0");
                    if (ComponentFunctionsVM.Count >= 1 && selectedFunctionVM != null)
                        selectedFunctionVM.ACoefficient = 0;
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
                    if (ComponentFunctionsVM.Count >= 1 && selectedFunctionVM != null)
                        selectedFunctionVM.BCoefficient = double.Parse(value);
                }
                else if (string.IsNullOrEmpty(value))
                {
                    Set(ref bCofficient, "0");
                    if (ComponentFunctionsVM.Count >= 1 && selectedFunctionVM != null)
                        selectedFunctionVM.BCoefficient = 0;
                }
                else
                {
                    BCofficient = bCofficient;
                }

            }
        }

        public int CCoefficient
        {
            get => cCofficient;
            set
            {
                Set(ref cCofficient, value);
                if (ComponentFunctionsVM.Count >= 1 && selectedFunctionVM != null)
                    selectedFunctionVM.CCoefficient = value;

            }

        }

        public ComponentFunctionVM SelectedFunctionVM
        {
            get => selectedFunctionVM;
            set
            {
                Set(ref selectedFunctionVM, value);
                if (selectedFunctionVM != null)
                {
                    SelectedNameFunc = selectedFunctionVM.NameFunction;
                    ACofficient = selectedFunctionVM.ACoefficient.ToString();
                    BCofficient = selectedFunctionVM.BCoefficient.ToString();
                    CCoefficient = selectedFunctionVM.CCoefficient;
                }                
            }
        }           
        
        public ICommand AddElement { get; }
        public ICommand DeletedElement { get; }

        public MainViewModel()
        {
            ListFunctions = ListPossibleFunctions.GetListFunctions();
            ComponentFunctionsVM = new ObservableCollection<ComponentFunctionVM>();            
            AddElement = new LambdaCommand(OnAddElementExecute, CanAddElementExecute);
            DeletedElement = new LambdaCommand(OnDeletedElementExecute, CanDeletedElementExecute);
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

        private bool CanDeletedElementExecute(object p) => selectedFunctionVM != null;

        private void OnDeletedElementExecute(object p)
        {
            ComponentFunctionsVM.Remove(selectedFunctionVM);     
        }
    }
}
