using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWorkASU.ViewModel.Base;
using TestWorkASU.Model;

namespace TestWorkASU.ViewModel
{
    class ComponentFunctionVM : BaseViewModel
    {
        private string nameFunction;
        private double aCoefficient;
        private double bCoefficient;
        private int cCoefficient;
        private string x = "0";
        private string y = "0";
        private double result;

        public string NameFunction
        {
            get => nameFunction;
            set
            {
                Set(ref nameFunction,value);
                Result = CalculateResult.Result(this);
            }
        }
        public double ACoefficient
        {
            get => aCoefficient;
            set
            {
                Set(ref aCoefficient, value);
                Result = CalculateResult.Result(this);
            }
        }
        public double BCoefficient
        {
            get => bCoefficient;
            set
            {
                Set(ref bCoefficient, value);
                Result = CalculateResult.Result(this);
            }
        }
        public int CCoefficient
        {
            get => cCoefficient;
            set
            {
                Set(ref cCoefficient, value);
                Result = CalculateResult.Result(this);
            }
        }
        public string X
        {
            get => x;
            set
            {
                if (double.TryParse(value, out double a))
                {
                    Set(ref x, value);                    
                }
                else if (string.IsNullOrEmpty(value))
                {
                    Set(ref x, "0");                    
                }
                else
                {
                    X = x;
                }                
                Result = CalculateResult.Result(this);
            }
        }
        public string Y
        {
            get => y;
            set
            {
                if (double.TryParse(value, out double a))
                {
                    Set(ref y, value);
                }
                else if (string.IsNullOrEmpty(value))
                {
                    Set(ref y, "0");
                }
                else
                {
                    Y = y;
                }
                Result = CalculateResult.Result(this);
            }
        }
        public double Result
        {
            get => result;
            private set => Set(ref result, value);
        }
    }
}
