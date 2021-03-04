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
        private double x;
        private double y;
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
        public double X
        {
            get => x;
            set
            {
                Set(ref x, value);
                Result = CalculateResult.Result(this);
            }
        }
        public double Y
        {
            get => y;
            set
            {
                Set(ref y, value);
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
