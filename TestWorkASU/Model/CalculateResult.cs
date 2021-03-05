using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWorkASU.ViewModel;

namespace TestWorkASU.Model
{
    /// <summary>
    /// класс для расчета значения
    /// </summary>
    class CalculateResult
    {

        /// <summary>
        /// метод расчета значения Resalt для экземпляров класса ComponentFunctionVM
        /// </summary>
        /// <returns>
        /// значение типа duble расчитанное в соответствии с параметрами function
        /// </returns>
        /// <param name="function">Экземпляр класса ComponentFunctionVM</param>
        public static double Result(ComponentFunctionVM function)
        {
            if (!string.IsNullOrEmpty(function.NameFunction))
            {
                return function.ACoefficient * Math.Pow(double.Parse(function.X), ListPossibleFunctions.ListFunctions[function.NameFunction] + 1) + function.BCoefficient * Math.Pow(double.Parse(function.Y), ListPossibleFunctions.ListFunctions[function.NameFunction]) + function.CCoefficient;
            }

            else
            {
                return 0;
            }
              
        }
    }
}
