using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWorkASU.Model
{
    class ComponentFuction
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
                nameFunction = value;                
                CalculateResult();
            }
        }
        public double ACoefficient
        {
            get => aCoefficient;
            set
            {
                aCoefficient = value;
                CalculateResult();
            }
        }
        public double BCoefficient
        {
            get => bCoefficient;
            set
            {
                bCoefficient = value;
                CalculateResult();
            }
        }
        public int CCoefficient
        {
            get => cCoefficient;
            set
            {
                cCoefficient = value;
                CalculateResult();
            }
        }
        public double X
        {
            get => x;
            set
            {
                x = value;
                CalculateResult();
            }
        }
        public double Y
        {
            get => y;
            set
            {
                y = value;
                CalculateResult();
            }
        }
        public double Result
        {
            get => result;            
        }

        private void CalculateResult()
        {
            if (!string.IsNullOrEmpty(nameFunction))
            result = aCoefficient * Math.Pow(x, ListPossibleFunctions.ListFunctions[nameFunction] + 1) + bCoefficient * Math.Pow(y, ListPossibleFunctions.ListFunctions[nameFunction]) + cCoefficient;
        }
    }
}
