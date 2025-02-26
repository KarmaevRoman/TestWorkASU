﻿using TestWorkASU.ViewModel.Base;
using TestWorkASU.Model;
using System.Collections.ObjectModel;
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

        /// <summary>
        /// коллекция возможных имен функций
        /// </summary>
        public ObservableCollection<string> ListFunctions
        {
            get => listFunctions;
            set => Set(ref listFunctions, value);
        }

        /// <summary>
        /// коллекция возможных значений коэффициента C
        /// </summary>
        public ObservableCollection<int> CoefficientCValues
        {
            get => coefficientCValues;
            set => Set(ref coefficientCValues, value);
        }

        /// <summary>
        /// коллекция созданных функций
        /// </summary>
        public ObservableCollection<ComponentFunctionVM> ComponentFunctionsVM
        {
            get => componentFunctionsVM;
            set => Set(ref componentFunctionsVM, value);
        }

        /// <summary>
        /// значение выбранного имени функции
        /// </summary>
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

        /// <summary>
        /// значение коэффициента А выбранной функции
        /// </summary>
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

        /// <summary>
        /// значение коэффициента B выбранной функции
        /// </summary>
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

        /// <summary>
        /// значение коэффициента C выбранной функции
        /// </summary>
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

        /// <summary>
        /// выбранная функция в таблице
        /// </summary>
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

        /// <summary>
        /// комманда для кнопки "Добавить строчку"
        /// </summary>
        public ICommand AddElement { get; }

        /// <summary>
        /// комманда для кнопки "Удалить строчку"
        /// </summary>
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
