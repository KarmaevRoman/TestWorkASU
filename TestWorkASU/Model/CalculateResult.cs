using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWorkASU.ViewModel;

namespace TestWorkASU.Model
{
    class CalculateResult
    {
       

        public static double Result(ComponentFunctionVM function)
        {
            if (!string.IsNullOrEmpty(function.NameFunction))
            {
                return function.ACoefficient * Math.Pow(function.X, ListPossibleFunctions.ListFunctions[function.NameFunction] + 1) + function.BCoefficient * Math.Pow(function.Y, ListPossibleFunctions.ListFunctions[function.NameFunction]) + function.CCoefficient;
            }

            else
            {
                return 0;
            }
              
        }
    }
}
